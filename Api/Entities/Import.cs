using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table(name: "importacao")]
[PrimaryKey(nameof(ImportId), nameof(YearId))]
public class Import : ImportProps
{
    public Import()
    { }

    public Import(ImportProps props)
    {
        Assign(props);
    }

    public void Update(ImportProps props)
    {
        AssignUpdate(props);
    }
}

public class ImportProps : Entity
{
    [Column(name:"idimportacao")]
    public int? ImportId { get; set; }

    [Column(name:"idano")]
    public int? YearId { get; set; }

    [Column(name:"data")]
    public DateOnly ?Date { get; set; }

    [Column(name:"hora")]
    public TimeOnly? Time { get; set; }

    [Column(name:"tipo")]
    public string? Type { get; set; }

    [Column(name:"login")]
    public string? Login { get; set; }

    [ForeignKey(nameof(YearId))]
    public virtual Year? Year { get; set; }

    [ForeignKey(nameof(Login))]
    public virtual User? User { get; set; }
}