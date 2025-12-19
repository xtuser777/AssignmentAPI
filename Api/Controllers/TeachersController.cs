using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TeachersController(
    ITeachersView teachersView,
    ITeachersService teachersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexTeachersParams parameters)
    {
        var teachers = await teachersService.FindManyAsync(parameters);
        var pagination = await teachersService.FindManyPaginationAsync(parameters);
        var data = teachersView.FindMany(teachers);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{teacherId:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowTeachersParams parameters)
    {
        var teacher = await teachersService.FindOneAsync(parameters);
        var data = teachersView.FindOne(teacher);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateTeachersParams parameters)
    {
        var teacher = await teachersService.CreateAsync(parameters);
        var data = teachersView.Create(teacher);

        return Created($"teachers/{teacher.TeacherId}", new { Data = data });
    }

    [HttpPut("{teacherId:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateTeachersParams parameters)
    {
        await teachersService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{teacherId:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteTeachersParams parameters)
    {
        await teachersService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexTeachersParams : PaginationParams
{
    public string? Name { get; set; }
    public string? Identity { get; set; }
    public string? Document { get; set; }
    public int? Dependents { get; set; }
    public DateOnly? BirthAt { get; set; }
    public string? Address { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Observations { get; set; }
    public int? YearId { get; set; }
    public int? UnitId { get; set; }
    public int? CivilStatusId { get; set; }
    public int? PositionId { get; set; }
    public int? DisciplineId { get; set; }
    public int? SituationId { get; set; }
    public string? Speciality { get; set; }
    public char? Remove { get; set; }
    public char? Adido { get; set; }
    public char? Readapted { get; set; }
    public char? ReadingRoom { get; set; }
    public char? Computing { get; set; }
    public char? SupplementCharge { get; set; }
    public char? Tutoring { get; set; }
    public char? AmbientalEducation { get; set; }
    public char? Robotics { get; set; }
    public char? Music { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }
    [FromHeader(Name = "X-Order-By-Identity")]
    public string? OrderByIdentity { get; set; }
    [FromHeader(Name = "X-Order-By-Document")]
    public string? OrderByDocument { get; set; }
    [FromHeader(Name = "X-Order-By-Dependents")]
    public string? OrderByDependents { get; set; }
    [FromHeader(Name = "X-Order-By-Birth-At")]
    public string? OrderByBirthAt { get; set; }
    [FromHeader(Name = "X-Order-By-Address")]
    public string? OrderByAddress { get; set; }
    [FromHeader(Name = "X-Order-By-Neighborhood")]
    public string? OrderByNeighborhood { get; set; }
    [FromHeader(Name = "X-Order-By-City")]
    public string? OrderByCity { get; set; }
    [FromHeader(Name = "X-Order-By-Postal-Code")]
    public string? OrderByPostalCode { get; set; }
    [FromHeader(Name = "X-Order-By-Phone")]
    public string? OrderByPhone { get; set; }
    [FromHeader(Name = "X-Order-By-Cellphone")]
    public string? OrderByCellphone { get; set; }
    [FromHeader(Name = "X-Order-By-Email")]
    public string? OrderByEmail { get; set; }
    [FromHeader(Name = "X-Order-By-Observations")]
    public string? OrderByObservations { get; set; }
    [FromHeader(Name = "X-Order-By-Year-Id")]
    public string? OrderByYearId { get; set; }
    [FromHeader(Name = "X-Order-By-Unit")]
    public string? OrderByUnit { get; set; }
    [FromHeader(Name = "X-Order-By-Civil-Status")]
    public string? OrderByCivilStatus { get; set; }
    [FromHeader(Name = "X-Order-By-Position")]
    public string? OrderByPosition { get; set; }
    [FromHeader(Name = "X-Order-By-Discipline")]
    public string? OrderByDiscipline { get; set; }
    [FromHeader(Name = "X-Order-By-Situation")]
    public string? OrderBySituation { get; set; }
    [FromHeader(Name = "X-Order-By-Speciality")]
    public string? OrderBySpeciality { get; set; }
    [FromHeader(Name = "X-Order-By-Remove")]
    public string? OrderByRemove { get; set; }
    [FromHeader(Name = "X-Order-By-Adido")]
    public string? OrderByAdido { get; set; }
    [FromHeader(Name = "X-Order-By-Readapted")]
    public string? OrderByReadapted { get; set; }
    [FromHeader(Name = "X-Order-By-Reading-Room")]
    public string? OrderByReadingRoom { get; set; }
    [FromHeader(Name = "X-Order-By-Computing")]
    public string? OrderByComputing { get; set; }
    [FromHeader(Name = "X-Order-By-Supplement-Charge")]
    public string? OrderBySupplementCharge { get; set; }
    [FromHeader(Name = "X-Order-By-Tutoring")]
    public string? OrderByTutoring { get; set; }
    [FromHeader(Name = "X-Order-By-Ambiental-Education")]
    public string? OrderByAmbientalEducation { get; set; }
    [FromHeader(Name = "X-Order-By-Robotics")]
    public string? OrderByRobotics { get; set; }
    [FromHeader(Name = "X-Order-By-Music")]
    public string? OrderByMusic { get; set; }

    public static implicit operator FindManyServiceParams(
        IndexTeachersParams indexTeachersParams)
        => new()
        {
            FindManyProps = new FindManyTeachersParams
            {
                Name = indexTeachersParams.Name,
                Identity = indexTeachersParams.Identity,
                Document = indexTeachersParams.Document,
                Dependents = indexTeachersParams.Dependents,
                BirthAt = indexTeachersParams.BirthAt,
                Address = indexTeachersParams.Address,
                Neighborhood = indexTeachersParams.Neighborhood,
                City = indexTeachersParams.City,
                PostalCode = indexTeachersParams.PostalCode,
                Phone = indexTeachersParams.Phone,
                Cellphone = indexTeachersParams.Cellphone,
                Email = indexTeachersParams.Email,
                Observations = indexTeachersParams.Observations,
                YearId = indexTeachersParams.YearId,
                UnitId = indexTeachersParams.UnitId,
                CivilStatusId = indexTeachersParams.CivilStatusId,
                PositionId = indexTeachersParams.PositionId,
                DisciplineId = indexTeachersParams.DisciplineId,
                SituationId = indexTeachersParams.SituationId,
                Speciality = indexTeachersParams.Speciality,
                Remove = indexTeachersParams.Remove,
                Adido = indexTeachersParams.Adido,
                Readapted = indexTeachersParams.Readapted,
                ReadingRoom = indexTeachersParams.ReadingRoom,
                Computing = indexTeachersParams.Computing,
                SupplementCharge = indexTeachersParams.SupplementCharge,
                Tutoring = indexTeachersParams.Tutoring,
                AmbientalEdication = indexTeachersParams.AmbientalEducation,
                Robotics = indexTeachersParams.Robotics,
                Music = indexTeachersParams.Music,
            },
            OrderByParams = new OrderByTeachersParams
            {
                Name = indexTeachersParams.OrderByName,
                Identity = indexTeachersParams.OrderByIdentity,
                Document = indexTeachersParams.OrderByDocument,
                Dependents = indexTeachersParams.OrderByDependents,
                BirthAt = indexTeachersParams.OrderByBirthAt,
                Address = indexTeachersParams.OrderByAddress,
                Neighborhood = indexTeachersParams.OrderByNeighborhood,
                City = indexTeachersParams.OrderByCity,
                PostalCode = indexTeachersParams.OrderByPostalCode,
                Phone = indexTeachersParams.OrderByPhone,
                Cellphone = indexTeachersParams.OrderByCellphone,
                Email = indexTeachersParams.OrderByEmail,
                Observations = indexTeachersParams.OrderByObservations,
                YearId = indexTeachersParams.OrderByYearId,
                Unit = indexTeachersParams.OrderByUnit,
                CivilStatus = indexTeachersParams.OrderByCivilStatus,
                Position = indexTeachersParams.OrderByPosition,
                Discipline = indexTeachersParams.OrderByDiscipline,
                Situation = indexTeachersParams.OrderBySituation,
                Speciality = indexTeachersParams.OrderBySpeciality,
                Remove = indexTeachersParams.OrderByRemove,
                Adido = indexTeachersParams.OrderByAdido,
                Readapted = indexTeachersParams.OrderByReadapted,
                ReadingRoom = indexTeachersParams.OrderByReadingRoom,
                Computing = indexTeachersParams.OrderByComputing,
                SupplementCharge = indexTeachersParams.OrderBySupplementCharge,
                Tutoring = indexTeachersParams.OrderByTutoring,
                AmbientalEdication = indexTeachersParams.OrderByAmbientalEducation,
                Robotics = indexTeachersParams.OrderByRobotics,
                Music = indexTeachersParams.OrderByMusic,
            },
            Includes = new IncludesTeachersParams
            {
                Unit = true,
                Position = true,
                Situation = true,
                CivilStatus = true,
            },
            PaginationParams = indexTeachersParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexTeachersParams indexTeachersParams)
        => new()
        {
            CountProps = new CountTeachersParams
            {
                Name = indexTeachersParams.Name,
                Identity = indexTeachersParams.Identity,
                Document = indexTeachersParams.Document,
                Dependents = indexTeachersParams.Dependents,
                BirthAt = indexTeachersParams.BirthAt,
                Address = indexTeachersParams.Address,
                Neighborhood = indexTeachersParams.Neighborhood,
                City = indexTeachersParams.City,
                PostalCode = indexTeachersParams.PostalCode,
                Phone = indexTeachersParams.Phone,
                Cellphone = indexTeachersParams.Cellphone,
                Email = indexTeachersParams.Email,
                Observations = indexTeachersParams.Observations,
                YearId = indexTeachersParams.YearId,
                UnitId = indexTeachersParams.UnitId,
                CivilStatusId = indexTeachersParams.CivilStatusId,
                PositionId = indexTeachersParams.PositionId,
                DisciplineId = indexTeachersParams.DisciplineId,
                SituationId = indexTeachersParams.SituationId,
                Speciality = indexTeachersParams.Speciality,
                Remove = indexTeachersParams.Remove,
                Adido = indexTeachersParams.Adido,
                Readapted = indexTeachersParams.Readapted,
                ReadingRoom = indexTeachersParams.ReadingRoom,
                Computing = indexTeachersParams.Computing,
                SupplementCharge = indexTeachersParams.SupplementCharge,
                Tutoring = indexTeachersParams.Tutoring,
                AmbientalEdication = indexTeachersParams.AmbientalEducation,
                Robotics = indexTeachersParams.Robotics,
                Music = indexTeachersParams.Music,
            },
            PaginationParams = indexTeachersParams
        };
}

public record ShowTeachersParams
{
    [FromRoute]
    public int TeacherId { get; set; }
    [FromRoute]
    public bool? IncludeUnit { get; set; } = true;
    [FromRoute]
    public bool? IncludeCivilStatus { get; set; } = true;
    [FromRoute]
    public bool? IncludePosition { get; set; } = true;
    [FromRoute]
    public bool? IncludeDiscipline { get; set; } = true;
    [FromRoute]
    public bool? IncludeSituation { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowTeachersParams showTeachersParams)
        => new()
        {
            Where = new FindManyTeachersParams
            {
                TeacherId = showTeachersParams.TeacherId,
            },
            Includes = new IncludesTeachersParams
            {
                Unit = showTeachersParams.IncludeUnit,
                CivilStatus = showTeachersParams.IncludeCivilStatus,
                Position = showTeachersParams.IncludePosition,
                Discipline = showTeachersParams.IncludeDiscipline,
                Situation = showTeachersParams.IncludeSituation,
            },
        };
}

public record CreateTeachersParams
{
    [FromBody]
    public CreateTeachersRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateTeachersParams createTeachersParams)
        => new()
        {
            Props = createTeachersParams.Request,
        };
}

public record UpdateTeachersParams
{
    [FromRoute]
    public int TeacherId { get; set; }

    [FromBody]
    public UpdateTeachersRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateTeachersParams updateTeachersParams)
        => new()
        {
            Where = new FindManyTeachersParams
            {
                TeacherId = updateTeachersParams.TeacherId,
            },
            Props = updateTeachersParams.Request,
        };
}

public record DeleteTeachersParams
{
    [FromRoute]
    public int TeacherId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteTeachersParams deleteTeachersParams)
        => new()
        {
            Where = new FindManyTeachersParams
            {
                TeacherId = deleteTeachersParams.TeacherId,
            },
        };
}
