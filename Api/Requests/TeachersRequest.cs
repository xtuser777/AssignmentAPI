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
    [StringMaxLength(11)]
    public string? Email { get; set; }

    [StringMaxLength(255)]
    public string? Observations { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<Year>(typeof(IYearsRepository))]
    public Guid? YearId { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<Unit>(typeof(IUnitsRepository))]
    public Guid? UnitId { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<CivilStatus>(typeof(ICivilStatusesRepository))]
    public Guid? CivilStatusId { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<Position>(typeof(IPositionsRepository))]
    public Guid? PositionId { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<Discipline>(typeof(IDisciplinesRepository))]
    public Guid? DisciplineId { get; set; }

    [RequiredField]
    [GuidValue]
    [Connection<Situation>(typeof(ISituationsRepository))]
    public Guid? SituationId { get; set; }

    [StringMaxLength(50)]
    public string? Speciality { get; set; }

    [BoolValue]
    public bool? IsRemove { get; set; }

    [BoolValue]
    public bool? IsAdido { get; set; }

    [BoolValue]
    public bool? IsReadapted { get; set; }

    [BoolValue]
    public bool? IsReadingRoom { get; set; }

    [BoolValue]
    public bool? IsComputing { get; set; }

    [BoolValue]
    public bool? IsSupplementCharge { get; set; }

    [BoolValue]
    public bool? IsTutoring { get; set; }

    [BoolValue]
    public bool? IsAmbientalEdication { get; set; }

    [BoolValue]
    public bool? IsRobotics { get; set; }

    [BoolValue]
    public bool? IsMusic { get; set; }

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
            IsRemove = request.IsRemove,
            IsAdido = request.IsAdido,
            IsReadapted = request.IsReadapted,
            IsReadingRoom = request.IsReadingRoom,
            IsComputing = request.IsComputing,
            IsSupplementCharge = request.IsSupplementCharge,
            IsTutoring = request.IsTutoring,
            IsAmbientalEdication = request.IsAmbientalEdication,
            IsRobotics = request.IsRobotics,
            IsMusic = request.IsMusic,
        };
    }
}

public record UpdateTeachersRequest
{
    [StringMinLength(1)]
    [StringMaxLength(200)]
    [UniqueField<Teacher>(typeof(ITeachersRepository), typeof(ExistsTeachersParams))]
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
    [StringMaxLength(11)]
    public string? Email { get; set; }

    [StringMaxLength(255)]
    public string? Observations { get; set; }

    [GuidValue]
    [Connection<Year>(typeof(IYearsRepository))]
    public Guid? YearId { get; set; }

    [GuidValue]
    [Connection<Unit>(typeof(IUnitsRepository))]
    public Guid? UnitId { get; set; }

    [GuidValue]
    [Connection<CivilStatus>(typeof(ICivilStatusesRepository))]
    public Guid? CivilStatusId { get; set; }

    [GuidValue]
    [Connection<Position>(typeof(IPositionsRepository))]
    public Guid? PositionId { get; set; }

    [GuidValue]
    [Connection<Discipline>(typeof(IDisciplinesRepository))]
    public Guid? DisciplineId { get; set; }

    [GuidValue]
    [Connection<Situation>(typeof(ISituationsRepository))]
    public Guid? SituationId { get; set; }

    [StringMaxLength(50)]
    public string? Speciality { get; set; }

    [BoolValue]
    public bool? IsRemove { get; set; }

    [BoolValue]
    public bool? IsAdido { get; set; }

    [BoolValue]
    public bool? IsReadapted { get; set; }

    [BoolValue]
    public bool? IsReadingRoom { get; set; }

    [BoolValue]
    public bool? IsComputing { get; set; }

    [BoolValue]
    public bool? IsSupplementCharge { get; set; }

    [BoolValue]
    public bool? IsTutoring { get; set; }

    [BoolValue]
    public bool? IsAmbientalEdication { get; set; }

    [BoolValue]
    public bool? IsRobotics { get; set; }

    [BoolValue]
    public bool? IsMusic { get; set; }

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
            IsRemove = request.IsRemove,
            IsAdido = request.IsAdido,
            IsReadapted = request.IsReadapted,
            IsReadingRoom = request.IsReadingRoom,
            IsComputing = request.IsComputing,
            IsSupplementCharge = request.IsSupplementCharge,
            IsTutoring = request.IsTutoring,
            IsAmbientalEdication = request.IsAmbientalEdication,
            IsRobotics = request.IsRobotics,
            IsMusic = request.IsMusic,
        };
    }
}
