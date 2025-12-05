using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

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
                    YearId = ano.idano,
                    Record = ano.ficha,
                    Resolution = ano.resolucao,
                    IsBlocked = ano.bloqueado
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
                    UnitId = unidade.idunidade,
                    Name = unidade.nome
                };
                units.Add(unit);
            }
            await unitOfWork.UnitsRepository.CreateManyAsync(units);
            await unitOfWork.Commit(transation, "Units");
        }
        return Ok();
    }

    [HttpPost("positions")]
    public async Task<IActionResult> ImportPositions(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var positions = new List<Position>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var cargo in csv.GetRecords<Cargo>())
            {
                var position = new Position()
                {
                    PositionId = cargo.idcargo,
                    Name = cargo.nome,
                    Active = cargo.ativo
                };
                positions.Add(position);
            }
            await unitOfWork.PositionsRepository.CreateManyAsync(positions);
            await unitOfWork.Commit(transation, "Positions");
        }
        return Ok();
    }

    [HttpPost("disciplines")]
    public async Task<IActionResult> ImportDisciplines(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var disciplines = new List<Discipline>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var disciplina in csv.GetRecords<Disciplina>())
            {
                var discipline = new Discipline()
                {
                    DisciplineId = disciplina.iddisciplina,
                    Name = disciplina.nome,
                };
                disciplines.Add(discipline);
            }
            await unitOfWork.DisciplinesRepository.CreateManyAsync(disciplines);
            await unitOfWork.Commit(transation, "Disciplines");
        }
        return Ok();
    }

    [HttpPost("civilstatuses")]
    public async Task<IActionResult> ImportCivilStatuses(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var civilstatuses = new List<CivilStatus>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var estado_civil in csv.GetRecords<EstadoCivil>())
            {
                var civilStatus = new CivilStatus()
                {
                    CivilStatusId = estado_civil.idestado_civil,
                    Name = estado_civil.nome,
                };
                civilstatuses.Add(civilStatus);
            }
            await unitOfWork.CivilStatusesRepository.CreateManyAsync(civilstatuses);
            await unitOfWork.Commit(transation, "CivilStatuses");
        }
        return Ok();
    }

    [HttpPost("preferences")]
    public async Task<IActionResult> ImportPreferences(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var preferences = new List<Preference>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var preferencia in csv.GetRecords<Preferencia>())
            {
                var preference = new Preference()
                {
                    PreferenceId = preferencia.idpreferencia,
                    Name = preferencia.nome,
                };
                preferences.Add(preference);
            }
            await unitOfWork.PreferencesRepository.CreateManyAsync(preferences);
            await unitOfWork.Commit(transation, "Preferences");
        }
        return Ok();
    }

    [HttpPost("situations")]
    public async Task<IActionResult> ImportSituations(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var situations = new List<Situation>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var situacao in csv.GetRecords<Situacao>())
            {
                var situation = new Situation()
                {
                    SituationId = situacao.idsituacao,
                    Name = situacao.nome,
                };
                situations.Add(situation);
            }
            await unitOfWork.SituationsRepository.CreateManyAsync(situations);
            await unitOfWork.Commit(transation, "Situations");
        }
        return Ok();
    }

    [HttpPost("titles")]
    public async Task<IActionResult> ImportTitles(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        var titles = new List<Title>();
        using (var transation = unitOfWork.BeginTransaction)
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            foreach (var titulo in csv.GetRecords<Titulo>())
            {
                var title = new Title()
                {
                    TitleId = titulo.idtitulo,
                    YearId = titulo.idano,
                    Description = titulo.descricao,
                    Alias = titulo.sigla,
                    Weight = titulo.peso,
                    Max = titulo.maximo,
                    Order = titulo.ordem,
                    Type = titulo.tipo,
                    Active = titulo.ativo
                };
                titles.Add(title);
            }
            await unitOfWork.TitlesRepository.CreateManyAsync(titles);
            await unitOfWork.Commit(transation);

        }
        return Ok();
    }
}

public record Ano(int idano, string ficha, string resolucao, char bloqueado);

public record Unidade(int idunidade, string nome);

public record Cargo(int idcargo, string nome, char? ativo);

public record Disciplina(int iddisciplina, string nome);

public record EstadoCivil(int idestado_civil, string nome);

public record Preferencia(int idpreferencia, string nome);

public record Situacao(int idsituacao, string nome);

public record Titulo(int idano, int idtitulo, string descricao, string sigla, decimal peso, decimal maximo, int ordem, char tipo, char ativo);
