using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Challenge_20210221.Domain.Models;

public class Orbit
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Abbrev { get; set; }
}
