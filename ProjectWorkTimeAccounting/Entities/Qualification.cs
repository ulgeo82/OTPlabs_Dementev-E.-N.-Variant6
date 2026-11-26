using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkTimeAccounting.Entities;

// Квалификация специалиста, определяющая почасовую ставку
[Table("qualifications")]
public class Qualification
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Required]
    [Column("name")]
    [DisplayName("Название")]
    public string Name { get; private set; } = string.Empty;

    [Column("hourly_rate", TypeName = "numeric(10,2)")]
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
