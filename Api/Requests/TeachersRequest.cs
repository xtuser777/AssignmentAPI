using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateTeachersRequest
{
    [RequiredField]
    [StringMaxLength(200)]
    [UniqueField<Teacher>(typeof(ITeachersRepository), typeof(ExistsTeachersParams))]
    public string? Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(12)]
    public string? Identity { get; set; }

    [RequiredField]
    [StringMaxLength(11)]
    [DocumentValue]
    public string? Document { get; set; }

    [RequiredField]
    public int? Dependents { get; set; }

    [RequiredField]
    [DateValue]
    public DateOnly? BirthAt { get; set; }

    [RequiredField]
    [StringMaxLength(100)]
    public string? Address { get; set; }

    [RequiredField]
    [StringMaxLength(50)]
    public string? Neighborhood { get; set; }

    [RequiredField]
    [StringMaxLength(50)]
    public string? City { get; set; }

    [RequiredField]
    [StringMaxLength(8)]
    public string? PostalCode { get; set; }

    [RequiredField]
    [StringMaxLength(10)]
    public string? Phone { get; set; }

    [RequiredField]
    [StringMaxLength(11)]
    public string? Cellphone { get; set; }

    [RequiredField]
    [EmailAddress]
    [StringMaxLength(100)]
    public string? Email { get; set; }

    [StringMaxLength(255)]
    public string? Observations { get; set; }

    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    public int? YearId { get; set; }

    [RequiredField]
    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
    public int? UnitId { get; set; }

    [RequiredField]
    [Connection<CivilStatus>(typeof(ICivilStatusesRepository), typeof(ExistsCivilStatusesParams))]
    public int? CivilStatusId { get; set; }

    [RequiredField]
    [Connection<Position>(typeof(IPositionsRepository), typeof(ExistsPositionsParams))]
    public int? PositionId { get; set; }

    [Connection<Discipline>(typeof(IDisciplinesRepository), typeof(ExistsDisciplinesParams))]
    public int? DisciplineId { get; set; }

    [RequiredField]
    [Connection<Situation>(typeof(ISituationsRepository), typeof(ExistsSituationsParams))]
    public int? SituationId { get; set; }

    [StringMaxLength(50)]
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

    public static implicit operator TeacherProps(CreateTeachersRequest request)
    {
        return new TeacherProps
        {
            Name = request.Name,
            Identity = request.Identity,
            Document = request.Document,
            Dependents = request.Dependents,
            BirthAt = request.BirthAt,
            Address = request.Address,
            Neighborhood = request.Neighborhood,
            City = request.City,
            PostalCode = request.PostalCode,
            Phone = request.Phone,
            Cellphone = request.Cellphone,
            Email = request.Email,
            Observations = request.Observations,
            YearId = request.YearId,
            UnitId = request.UnitId,
            CivilStatusId = request.CivilStatusId,
            PositionId = request.PositionId,
            DisciplineId = request.DisciplineId,
            SituationId = request.SituationId,
            Speciality = request.Speciality,
            Remove = request.Remove,
            Adido = request.Adido,
            Readapted = request.Readapted,
            ReadingRoom = request.ReadingRoom,
            Computing = request.Computing,
            SupplementCharge = request.SupplementCharge,
            Tutoring = request.Tutoring,
            AmbientalEdication = request.AmbientalEducation,
            Robotics = request.Robotics,
            Music = request.Music,
        };
    }
}

public record UpdateTeachersRequest
{
    [StringMinLength(1)]
    [StringMaxLength(200)]
    [UniqueField<Teacher>(typeof(ITeachersRepository), typeof(ExclusiveTeachersParams))]
    public string? Name { get; set; } = string.Empty;

    [StringMinLength(1)]
    [StringMaxLength(12)]
    public string? Identity { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(11)]
    [DocumentValue]
    public string? Document { get; set; }

    [Range(0, 100)]
    public int? Dependents { get; set; }

    [DateValue]
    public DateOnly? BirthAt { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(100)]
    public string? Address { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(50)]
    public string? Neighborhood { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(50)]
    public string? City { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(8)]
    public string? PostalCode { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(10)]
    public string? Phone { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(11)]
    public string? Cellphone { get; set; }

    [StringMinLength(1)]
    [EmailAddress]
    [StringMaxLength(100)]
    public string? Email { get; set; }

    [StringMaxLength(255)]
    public string? Observations { get; set; }

    [Connection<Year>(typeof(IYearsRepository), typeof(ExclusiveYearParams))]
    public int? YearId { get; set; }

    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExclusiveUnitsParams))]
    public int? UnitId { get; set; }

    [Connection<CivilStatus>(typeof(ICivilStatusesRepository), typeof(ExclusiveCivilStatusesParams))]
    public int? CivilStatusId { get; set; }

    [Connection<Position>(typeof(IPositionsRepository), typeof(ExclusivePositionsParams))]
    public int? PositionId { get; set; }

    [Connection<Discipline>(typeof(IDisciplinesRepository), typeof(ExclusiveDisciplinesParams))]
    public int? DisciplineId { get; set; }

    [Connection<Situation>(typeof(ISituationsRepository), typeof(ExclusiveSituationsParams))]
    public int? SituationId { get; set; }

    [StringMaxLength(50)]
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

    public static implicit operator TeacherProps(UpdateTeachersRequest request)
    {
        return new TeacherProps
        {
            Name = request.Name,
            Identity = request.Identity,
            Document = request.Document,
            Dependents = request.Dependents,
            BirthAt = request.BirthAt,
            Address = request.Address,
            Neighborhood = request.Neighborhood,
            City = request.City,
            PostalCode = request.PostalCode,
            Phone = request.Phone,
            Cellphone = request.Cellphone,
            Email = request.Email,
            Observations = request.Observations,
            YearId = request.YearId,
            UnitId = request.UnitId,
            CivilStatusId = request.CivilStatusId,
            PositionId = request.PositionId,
            DisciplineId = request.DisciplineId,
            SituationId = request.SituationId,
            Speciality = request.Speciality,
            Remove = request.Remove,
            Adido = request.Adido,
            Readapted = request.Readapted,
            ReadingRoom = request.ReadingRoom,
            Computing = request.Computing,
            SupplementCharge = request.SupplementCharge,
            Tutoring = request.Tutoring,
            AmbientalEdication = request.AmbientalEducation,
            Robotics = request.Robotics,
            Music = request.Music,
        };
    }
}

public record ImportTeachersRequest
{
    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    public int? YearId { get; set; }

    public static implicit operator int(ImportTeachersRequest request)
    {
        return request.YearId ?? 0;
    }
}
