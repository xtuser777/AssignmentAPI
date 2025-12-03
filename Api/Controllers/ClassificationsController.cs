using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ClassificationsController(
    IClassificationsView classificationsView,
    IClassificationsService classificationsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexClassificationsParams parameters)
    {
        var classifications = await classificationsService.FindManyAsync(parameters);
        var pagination = await classificationsService.FindManyPaginationAsync(parameters);
        var data = classificationsView.FindMany(classifications);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowClassificationsParams parameters)
    {
        var classification = await classificationsService.FindOneAsync(parameters);
        var data = classificationsView.FindOne(classification);

        return Ok(new { Data = data });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteClassificationsParams parameters)
    {
        await classificationsService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexClassificationsParams : PaginationParams
{
    public string? Name { get; set; }
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public int? SubscriptionId { get; set; }
    public int? SituationId { get; set; }
    public int? PositionId { get; set; }
    public int? UnitId { get; set; }
    public int? DisciplineId { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Speciality { get; set; }
    public bool? IsRemove { get; set; }
    public bool? IsAdido { get; set; }
    public bool? IsReadapted { get; set; }
    public bool? IsReadingRoom { get; set; }
    public bool? IsComputing { get; set; }
    public bool? IsSupplementCharge { get; set; }
    public bool? IsTutoring { get; set; }
    public bool? IsAmbientalEdication { get; set; }
    public bool? IsRobotics { get; set; }
    public bool? IsMusic { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }
    [FromHeader(Name = "X-Order-By-Year")]
    public string? OrderByYear { get; set; }
    [FromHeader(Name = "X-Order-By-Teacher")]
    public string? OrderByTeacher { get; set; }
    [FromHeader(Name = "X-Order-By-Subscription")]
    public string? OrderBySubscription { get; set; }
    [FromHeader(Name = "X-Order-By-Situation")]
    public string? OrderBySituation { get; set; }
    [FromHeader(Name = "X-Order-By-Position")]
    public string? OrderByPosition { get; set; }
    [FromHeader(Name = "X-Order-By-Unit")]
    public string? OrderByUnit { get; set; }
    [FromHeader(Name = "X-Order-By-Discipline")]
    public string? OrderByDiscipline { get; set; }
    [FromHeader(Name = "X-Order-By-Phone")]
    public string? OrderByPhone { get; set; }
    [FromHeader(Name = "X-Order-By-Cellphone")]
    public string? OrderByCellphone { get; set; }
    [FromHeader(Name = "X-Order-By-Speciality")]
    public string? OrderBySpeciality { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Remove")]
    public string? OrderByIsRemove { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Adido")]
    public string? OrderByIsAdido { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Readapted")]
    public string? OrderByIsReadapted { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Reading-Room")]
    public string? OrderByIsReadingRoom { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Computing")]
    public string? OrderByIsComputing { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Supplement-Charge")]
    public string? OrderByIsSupplementCharge { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Tutoring")]
    public string? OrderByIsTutoring { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Ambiental-Edication")]
    public string? OrderByIsAmbientalEdication { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Robotics")]
    public string? OrderByIsRobotics { get; set; }
    [FromHeader(Name = "X-Order-By-Is-Music")]
    public string? OrderByIsMusic { get; set; }

    public static implicit operator FindManyServiceParams(IndexClassificationsParams indexClassificationsParams)
        => new()
        {
            FindManyProps = new FindManyClassificationsParams
            {
                Name = indexClassificationsParams.Name,
                YearId = indexClassificationsParams.YearId,
                TeacherId = indexClassificationsParams.TeacherId,
                SubscriptionId = indexClassificationsParams.SubscriptionId,
                SituationId = indexClassificationsParams.SituationId,
                PositionId = indexClassificationsParams.PositionId,
                UnitId = indexClassificationsParams.UnitId,
                DisciplineId = indexClassificationsParams.DisciplineId,
                Phone = indexClassificationsParams.Phone,
                Cellphone = indexClassificationsParams.Cellphone,
                Speciality = indexClassificationsParams.Speciality,
                IsRemove = indexClassificationsParams.IsRemove,
                IsAdido = indexClassificationsParams.IsAdido,
                IsReadapted = indexClassificationsParams.IsReadapted,
                IsReadingRoom = indexClassificationsParams.IsReadingRoom,
                IsComputing = indexClassificationsParams.IsComputing,
                IsSupplementCharge = indexClassificationsParams.IsSupplementCharge,
                IsTutoring = indexClassificationsParams.IsTutoring,
                IsAmbientalEdication = indexClassificationsParams.IsAmbientalEdication,
                IsRobotics = indexClassificationsParams.IsRobotics,
                IsMusic = indexClassificationsParams.IsMusic,
            },
            OrderByParams = new OrderByClassificationsParams
            {
                Name = indexClassificationsParams.OrderByName,
                Year = indexClassificationsParams.OrderByYear,
                Subscription = indexClassificationsParams.OrderBySubscription,
                Situation = indexClassificationsParams.OrderBySituation,
                Position = indexClassificationsParams.OrderByPosition,
                Unit = indexClassificationsParams.OrderByUnit,
                Discipline = indexClassificationsParams.OrderByDiscipline,
                Phone = indexClassificationsParams.OrderByPhone,
                Cellphone = indexClassificationsParams.OrderByCellphone,
                Speciality = indexClassificationsParams.OrderBySpeciality,
                IsRemove = indexClassificationsParams.OrderByIsRemove,
                IsAdido = indexClassificationsParams.OrderByIsAdido,
                IsReadapted = indexClassificationsParams.OrderByIsReadapted,
                IsReadingRoom = indexClassificationsParams.OrderByIsReadingRoom,
                IsComputing = indexClassificationsParams.OrderByIsComputing,
                IsSupplementCharge = indexClassificationsParams.OrderByIsSupplementCharge,
                IsTutoring = indexClassificationsParams.OrderByIsTutoring,
                IsAmbientalEdication = indexClassificationsParams.OrderByIsAmbientalEdication,
                IsRobotics = indexClassificationsParams.OrderByIsRobotics,
                IsMusic = indexClassificationsParams.OrderByIsMusic,
            },
            PaginationParams = indexClassificationsParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexClassificationsParams indexClassificationsParams)
        => new()
        {
            CountProps = new CountClassificationsParams
            {
                Name = indexClassificationsParams.Name,
                YearId = indexClassificationsParams.YearId,
                TeacherId = indexClassificationsParams.TeacherId,
                SubscriptionId = indexClassificationsParams.SubscriptionId,
                SituationId = indexClassificationsParams.SituationId,
                PositionId = indexClassificationsParams.PositionId,
                UnitId = indexClassificationsParams.UnitId,
                DisciplineId = indexClassificationsParams.DisciplineId,
                Phone = indexClassificationsParams.Phone,
                Cellphone = indexClassificationsParams.Cellphone,
                Speciality = indexClassificationsParams.Speciality,
                IsRemove = indexClassificationsParams.IsRemove,
                IsAdido = indexClassificationsParams.IsAdido,
                IsReadapted = indexClassificationsParams.IsReadapted,
                IsReadingRoom = indexClassificationsParams.IsReadingRoom,
                IsComputing = indexClassificationsParams.IsComputing,
                IsSupplementCharge = indexClassificationsParams.IsSupplementCharge,
                IsTutoring = indexClassificationsParams.IsTutoring,
                IsAmbientalEdication = indexClassificationsParams.IsAmbientalEdication,
                IsRobotics = indexClassificationsParams.IsRobotics,
                IsMusic = indexClassificationsParams.IsMusic,
            },
            PaginationParams = indexClassificationsParams
        };
}

public record ShowClassificationsParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowClassificationsParams showClassificationsParams)
        => new()
        {
            Id = showClassificationsParams.Id,
        };
}

public record DeleteClassificationsParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteClassificationsParams showClassificationsParams)
        => new()
        {
            Id = showClassificationsParams.Id,
        };
}
