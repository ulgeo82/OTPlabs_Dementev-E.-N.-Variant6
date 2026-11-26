namespace ProjectWorkTimeAccounting.Entities.Enums;

// Виды работ, выполненных за рабочий день (можно сочетать несколько)
[Flags]
public enum WorkKind
{
    None = 0,

    Management = 1,

    Development = 2,

    Testing = 4,

    Support = 8,

    Documentation = 16
}
