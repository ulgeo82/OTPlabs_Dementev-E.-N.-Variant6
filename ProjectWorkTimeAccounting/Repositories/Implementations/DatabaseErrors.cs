using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ProjectWorkTimeAccounting.Repositories.Implementations;

// Ошибка работы с базой данных с сообщением на русском языке
public class DatabaseException : Exception
{
    public DatabaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

// Перевод ошибок базы данных в понятные сообщения на русском языке
public static class DatabaseErrors
{
    public static DatabaseException Translate(Exception ex)
    {
        var postgresException = FindInner<PostgresException>(ex);
        if (postgresException != null)
        {
            return new DatabaseException(postgresException.SqlState switch
            {
                PostgresErrorCodes.ForeignKeyViolation when postgresException.MessageText.Contains("update or delete") =>
                    "Нельзя удалить запись: на неё ссылаются другие данные. Сначала удалите связанные записи.",
                PostgresErrorCodes.ForeignKeyViolation =>
                    "Указана ссылка на несуществующую запись. Обновите список и выберите значение заново.",
                PostgresErrorCodes.UniqueViolation =>
                    "Такая запись уже существует.",
                PostgresErrorCodes.NotNullViolation =>
                    "Не заполнено обязательное поле.",
                PostgresErrorCodes.StringDataRightTruncation =>
                    "Введено слишком длинное значение.",
                PostgresErrorCodes.NumericValueOutOfRange =>
                    "Введено слишком большое число.",
                PostgresErrorCodes.InvalidPassword or PostgresErrorCodes.InvalidAuthorizationSpecification =>
                    "Не удалось войти в базу данных: неверное имя пользователя или пароль.",
                PostgresErrorCodes.InvalidCatalogName =>
                    "База данных не найдена. Выполните миграцию (Update-Database).",
                PostgresErrorCodes.UndefinedTable =>
                    "Таблица не найдена. Выполните миграцию (Update-Database).",
                _ => "Ошибка базы данных при выполнении операции."
            }, ex);
        }

        if (FindInner<NpgsqlException>(ex) != null || FindInner<System.Net.Sockets.SocketException>(ex) != null)
        {
            return new DatabaseException("Не удалось подключиться к базе данных. Проверьте, что сервер PostgreSQL запущен.", ex);
        }

        if (ex is DbUpdateConcurrencyException)
        {
            return new DatabaseException("Запись была изменена или удалена. Обновите список и повторите действие.", ex);
        }

        if (ex is InvalidOperationException && ex.Message.Contains("Sequence contains no"))
        {
            return new DatabaseException("Запись не найдена. Возможно, она уже удалена.", ex);
        }

        return new DatabaseException("Не удалось выполнить операцию с базой данных.", ex);
    }

    public static string GetMessage(Exception ex)
    {
        var databaseException = FindInner<DatabaseException>(ex);
        if (databaseException != null)
        {
            return databaseException.Message;
        }

        return ex is Unity.ResolutionFailedException
            ? "Не удалось открыть форму. " + Translate(ex).Message
            : ex.Message;
    }

    private static T? FindInner<T>(Exception? ex) where T : Exception
    {
        while (ex != null)
        {
            if (ex is T found)
            {
                return found;
            }
            ex = ex.InnerException;
        }
        return null;
    }
}
