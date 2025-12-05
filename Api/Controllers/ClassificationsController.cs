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
    public char? Remove { get; set; }
    public char? Adido { get; set; }
    public char? Readapted { get; set; }
    public char? ReadingRoom { get; set; }
    public char? Computing { get; set; }
    public char? SupplementCharge { get; set; }
    public char? Tutoring { get; set; }
    public char? AmbientalEdication { get; set; }
    public char? Robotics { get; set; }
    public char? Music { get; set; }

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
    [FromHeader(Name = "X-Order-By--Remove")]
    public string? OrderByRemove { get; set; }
    [FromHeader(Name = "X-Order-By--Adido")]
    public string? OrderByAdido { get; set; }
    [FromHeader(Name = "X-Order-By--Readapted")]
    public string? OrderByReadapted { get; set; }
    [FromHeader(Name = "X-Order-By--Reading-Room")]
    public string? OrderByReadingRoom { get; set; }
    [FromHeader(Name = "X-Order-By--Computing")]
    public string? OrderByComputing { get; set; }
    [FromHeader(Name = "X-Order-By--Supplement-Charge")]
    public string? OrderBySupplementCharge { get; set; }
    [FromHeader(Name = "X-Order-By--Tutoring")]
    public string? OrderByTutoring { get; set; }
    [FromHeader(Name = "X-Order-By--Ambiental-Edication")]
    public string? OrderByAmbientalEdication { get; set; }
    [FromHeader(Name = "X-Order-By--Robotics")]
    public string? OrderByRobotics { get; set; }
    [FromHeader(Name = "X-Order-By--Music")]
    public string? OrderByMusic { get; set; }

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
                AmbientalEdication = indexClassificationsParams.AmbientalEdication,
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
                AmbientalEdication = indexClassificationsParams.OrderByAmbientalEdication,
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
                AmbientalEdication = indexClassificationsParams.AmbientalEdication,
            },
            PaginationParams = indexClassificationsParams
        };
}
