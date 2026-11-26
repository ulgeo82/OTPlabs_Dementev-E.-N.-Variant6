using System.ComponentModel;

namespace ProjectWorkTimeAccounting.Entities;

// Квалификация специалиста, определяющая почасовую ставку
public class Qualification
{
    public int Id { get; private set; }

    [DisplayName("Название")]
    public string Name { get; private set; } = string.Empty;

    [DisplayName("Почасовая ставка")]
    public decimal HourlyRate { get; private set; }

    public static Qualification CreateEntity(int id, string name, decimal hourlyRate)
    {
        return new Qualification
        {
            Id = id,
            Name = name ?? string.Empty,
            HourlyRate = hourlyRate
        };
    }
}
