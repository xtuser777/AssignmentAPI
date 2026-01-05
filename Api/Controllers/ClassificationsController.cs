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
}

public record IndexClassificationsParams : PaginationParams
{
    public string? Name { get; init; }
    public int? YearId { get; init; }
    public int? TeacherId { get; init; }
    public int? SubscriptionId { get; init; }
    public int? SituationId { get; init; }
    public int? PositionId { get; init; }
    public int? UnitId { get; init; }
    public int? DisciplineId { get; init; }
    public string? Phone { get; init; }
    public string? Cellphone { get; init; }
    public string? Speciality { get; init; }
    public string? Remove { get; init; }
    public string? Adido { get; init; }
    public string? Readapted { get; init; }
    public string? ReadingRoom { get; init; }
    public string? Computing { get; init; }
    public string? SupplementCharge { get; init; }
    public string? Tutoring { get; init; }
    public string? AmbientalEducation { get; init; }
    public string? Robotics { get; init; }
    public string? Music { get; init; }

    [FromHeader(Name = "X-Order-By-Name")] public string? OrderByName { get; init; }
    [FromHeader(Name = "X-Order-By-Year")] public string? OrderByYear { get; init; }

    [FromHeader(Name = "X-Order-By-Teacher")]
    public string? OrderByTeacher { get; init; }

    [FromHeader(Name = "X-Order-By-Subscription")]
    public string? OrderBySubscription { get; init; }

    [FromHeader(Name = "X-Order-By-Situation")]
    public string? OrderBySituation { get; init; }

    [FromHeader(Name = "X-Order-By-Position")]
    public string? OrderByPosition { get; init; }

    [FromHeader(Name = "X-Order-By-Unit")] public string? OrderByUnit { get; init; }

    [FromHeader(Name = "X-Order-By-Discipline")]
    public string? OrderByDiscipline { get; init; }

    [FromHeader(Name = "X-Order-By-Phone")]
    public string? OrderByPhone { get; init; }

    [FromHeader(Name = "X-Order-By-Cellphone")]
    public string? OrderByCellphone { get; init; }

    [FromHeader(Name = "X-Order-By-Speciality")]
    public string? OrderBySpeciality { get; init; }

    [FromHeader(Name = "X-Order-By-Remove")]
    public string? OrderByRemove { get; init; }

    [FromHeader(Name = "X-Order-By-Adido")]
    public string? OrderByAdido { get; init; }

    [FromHeader(Name = "X-Order-By-Readapted")]
    public string? OrderByReadapted { get; init; }

    [FromHeader(Name = "X-Order-By-Reading-Room")]
    public string? OrderByReadingRoom { get; init; }

    [FromHeader(Name = "X-Order-By-Computing")]
    public string? OrderByComputing { get; init; }

    [FromHeader(Name = "X-Order-By-Supplement-Charge")]
    public string? OrderBySupplementCharge { get; init; }

    [FromHeader(Name = "X-Order-By-Tutoring")]
    public string? OrderByTutoring { get; init; }

    [FromHeader(Name = "X-Order-By-Ambiental-Education")]
    public string? OrderByAmbientalEducation { get; init; }

    [FromHeader(Name = "X-Order-By-Robotics")]
    public string? OrderByRobotics { get; init; }

    [FromHeader(Name = "X-Order-By-Music")]
    public string? OrderByMusic { get; init; }

    [FromHeader(Name = "X-Order-By-Total")]
    public string? OrderByTotal { get; init; }

    public static implicit operator FindManyServiceParams(
        IndexClassificationsParams indexClassificationsParams)
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
                Remove = indexClassificationsParams.Remove,
                Adido = indexClassificationsParams.Adido,
                Readapted = indexClassificationsParams.Readapted,
                ReadingRoom = indexClassificationsParams.ReadingRoom,
                Computing = indexClassificationsParams.Computing,
                SupplementCharge = indexClassificationsParams.SupplementCharge,
                Tutoring = indexClassificationsParams.Tutoring,
                AmbientalEdication = indexClassificationsParams.AmbientalEducation,
            },
            OrderByParams = new OrderByClassificationsParams
            {
                Name = indexClassificationsParams.OrderByName,
                YearId = indexClassificationsParams.OrderByYear,
                Subscription = indexClassificationsParams.OrderBySubscription,
                Situation = indexClassificationsParams.OrderBySituation,
                Position = indexClassificationsParams.OrderByPosition,
                Unit = indexClassificationsParams.OrderByUnit,
                Discipline = indexClassificationsParams.OrderByDiscipline,
                Phone = indexClassificationsParams.OrderByPhone,
                Cellphone = indexClassificationsParams.OrderByCellphone,
                Speciality = indexClassificationsParams.OrderBySpeciality,
                Remove = indexClassificationsParams.OrderByRemove,
                Adido = indexClassificationsParams.OrderByAdido,
                Readapted = indexClassificationsParams.OrderByReadapted,
                ReadingRoom = indexClassificationsParams.OrderByReadingRoom,
                Computing = indexClassificationsParams.OrderByComputing,
                SupplementCharge = indexClassificationsParams.OrderBySupplementCharge,
                Tutoring = indexClassificationsParams.OrderByTutoring,
                AmbientalEdication = indexClassificationsParams.OrderByAmbientalEducation,
                Total = "d",
            },
            PaginationParams = indexClassificationsParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexClassificationsParams indexClassificationsParams)
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
                Remove = indexClassificationsParams.Remove,
                Adido = indexClassificationsParams.Adido,
                Readapted = indexClassificationsParams.Readapted,
                ReadingRoom = indexClassificationsParams.ReadingRoom,
                Computing = indexClassificationsParams.Computing,
                SupplementCharge = indexClassificationsParams.SupplementCharge,
                Tutoring = indexClassificationsParams.Tutoring,
                AmbientalEdication = indexClassificationsParams.AmbientalEducation,
            },
            PaginationParams = indexClassificationsParams
        };
}