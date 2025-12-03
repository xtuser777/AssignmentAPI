using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ImportsController(
    IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpPost("years")]
    public async Task<IActionResult> ImportYears(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var years = new List<Year>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var ano in csv.GetRecords<Ano>())
            {
                var year = new Year()
                {
                    Id = ano.idano,
                    Record = ano.ficha,
                    Resolution = ano.resolucao,
                    IsBlocked = ano.bloqueado == "S"
                };
                years.Add(year);
            }
            await unitOfWork.YearsRepository.CreateManyAsync(years);
            await unitOfWork.Commit(transation, "Years");
        }
        return Ok();
    }

    [HttpPost("units")]
    public async Task<IActionResult> ImportUnits(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var units = new List<Unit>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var unidade in csv.GetRecords<Unidade>())
            {
                var unit = new Unit()
                {
                    Id = unidade.idunidade,
                    Name = unidade.nome
                };
                units.Add(unit);
            }
            await unitOfWork.UnitsRepository.CreateManyAsync(units);
            await unitOfWork.Commit(transation, "Units");
        }
        return Ok();
    }
}

public record Ano(int idano, string ficha, string resolucao, string bloqueado);

public record Unidade(int idunidade, string nome);
