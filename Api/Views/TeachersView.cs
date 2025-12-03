using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class TeachersView : ITeachersView
{
    public CreateTeachersResponse? Create(Teacher? teacher)
    {
        if (teacher == null)
        {
            return null;
        }

        return new CreateTeachersResponse
        {
            Id = teacher.Id,
        };
    }

    public FindOneTeachersResponse? FindOne(Teacher? teacher)
    {
        if (teacher == null)
        {
            return null;
        }

        return new FindOneTeachersResponse
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Identity = teacher.Identity,
            Document = teacher.Document,
            Dependents = teacher.Dependents,
            BirthAt = teacher.BirthAt,
            Address = teacher.Address,
            Neighborhood = teacher.Neighborhood,
            City = teacher.City,
            PostalCode = teacher.PostalCode,
            Phone = teacher.Phone,
            Cellphone = teacher.Cellphone,
            Email = teacher.Email,
            Observations = teacher.Observations,
            YearId = teacher.YearId,
            UnitId = teacher.UnitId,
            CivilStatusId = teacher.CivilStatusId,
            PositionId = teacher.PositionId,
            DisciplineId = teacher.DisciplineId,
            SituationId = teacher.SituationId,
            Speciality = teacher.Speciality,
            IsRemove = teacher.IsRemove,
            IsAdido = teacher.IsAdido,
            IsReadapted = teacher.IsReadapted,
            IsReadingRoom = teacher.IsReadingRoom,
            IsComputing = teacher.IsComputing,
            IsSupplementCharge = teacher.IsSupplementCharge,
            IsTutoring = teacher.IsTutoring,
            IsAmbientalEdication = teacher.IsAmbientalEdication,
            IsRobotics = teacher.IsRobotics,
            IsMusic = teacher.IsMusic,
        };
    }

    public IEnumerable<FindManyTeachersResponse> FindMany(IEnumerable<Teacher>? teachers)
    {
        if (teachers == null)
        {
            return [];
        }

        return teachers.Select(teacher => new FindManyTeachersResponse
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Identity = teacher.Identity,
            Document = teacher.Document,
            Dependents = teacher.Dependents,
            BirthAt = teacher.BirthAt,
            Address = teacher.Address,
            Neighborhood = teacher.Neighborhood,
            City = teacher.City,
            PostalCode = teacher.PostalCode,
            Phone = teacher.Phone,
            Cellphone = teacher.Cellphone,
            Email = teacher.Email,
            Observations = teacher.Observations,
            YearId = teacher.YearId,
            UnitId = teacher.UnitId,
            UnitName = teacher.Unit?.Name,
            CivilStatusId = teacher.CivilStatusId,
            CivilStatusName = teacher.CivilStatus?.Name,
            PositionId = teacher.PositionId,
            PositionName = teacher.Position?.Name,
            DisciplineId = teacher.DisciplineId,
            DisciplineName = teacher.Discipline?.Name,
            SituationId = teacher.SituationId,
            SituationName = teacher.Situation?.Name,
            Speciality = teacher.Speciality,
            IsRemove = teacher.IsRemove,
            IsAdido = teacher.IsAdido,
            IsReadapted = teacher.IsReadapted,
            IsReadingRoom = teacher.IsReadingRoom,
            IsComputing = teacher.IsComputing,
            IsSupplementCharge = teacher.IsSupplementCharge,
            IsTutoring = teacher.IsTutoring,
            IsAmbientalEdication = teacher.IsAmbientalEdication,
            IsRobotics = teacher.IsRobotics,
            IsMusic = teacher.IsMusic,
        });
    }
}
