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
            YearId = teacher.YearId,
            TeacherId = teacher.TeacherId,
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
            TeacherId = teacher.TeacherId,
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
            Remove = teacher.Remove,
            Adido = teacher.Adido,
            Readapted = teacher.Readapted,
            ReadingRoom = teacher.ReadingRoom,
            Computing = teacher.Computing,
            SupplementCharge = teacher.SupplementCharge,
            Tutoring = teacher.Tutoring,
            AmbientalEdication = teacher.AmbientalEdication,
            Robotics = teacher.Robotics,
            Music = teacher.Music,
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
            TeacherId = teacher.TeacherId,
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
            Remove = teacher.Remove,
            Adido = teacher.Adido,
            Readapted = teacher.Readapted,
            ReadingRoom = teacher.ReadingRoom,
            Computing = teacher.Computing,
            SupplementCharge = teacher.SupplementCharge,
            Tutoring = teacher.Tutoring,
            AmbientalEdication = teacher.AmbientalEdication,
            Robotics = teacher.Robotics,
            Music = teacher.Music,
        });
    }
}
