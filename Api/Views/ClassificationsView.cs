using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;
using System.Numerics;

namespace Assignment.Api.Views;

public class ClassificationsView : IClassificationsView
{
    public FindOneClassificationsResponse? FindOne(Classification? classification)
    {
        if (classification == null)
        {
            return null;
        }

        return new FindOneClassificationsResponse
        {
            Id = classification.Id,
            YearId = classification.YearId,
            Year = classification.Year,
            TeacherId = classification.TeacherId,
            SubscriptionId = classification.SubscriptionId,
            Name = classification.Name,
            SituationId = classification.SituationId,
            Situation = classification.Situation,
            PositionId = classification.PositionId,
            Position = classification.Position,
            UnitId = classification.UnitId,
            Unit = classification.Unit,
            DisciplineId = classification.DisciplineId,
            Discipline = classification.Discipline,
            Phone = classification.Phone,
            Cellphone = classification.Cellphone,
            Speciality = classification.Speciality,
            IsRemove = classification.IsRemove,
            IsAdido = classification.IsAdido,
            IsReadapted = classification.IsReadapted,
            IsReadingRoom = classification.IsReadingRoom,
            IsComputing = classification.IsComputing,
            IsSupplementCharge = classification.IsSupplementCharge,
            IsTutoring = classification.IsTutoring,
            IsAmbientalEdication = classification.IsAmbientalEdication,
            IsRobotics = classification.IsRobotics,
            IsMusic = classification.IsMusic,
            T1 = classification.T1,
            T2 = classification.T2,
            T3 = classification.T3,
            T4 = classification.T4,
            T5 = classification.T5,
            T6 = classification.T6,
            T7 = classification.T7,
            T8 = classification.T8,
            T9 = classification.T9,
            T10 = classification.T10,
            T11 = classification.T11,
            T12 = classification.T12,
            T13 = classification.T13,
            T14 = classification.T14,
            T15 = classification.T15,
            T16 = classification.T16,
            T17 = classification.T17,
            T18 = classification.T18,
            T19 = classification.T19,
            T20 = classification.T20,
            T21 = classification.T21,
            T22 = classification.T22,
        };
    }

    public IEnumerable<FindManyClassificationsResponse> FindMany(IEnumerable<Classification>? classifications)
    {
        if (classifications == null)
        {
            return [];
        }

        return classifications.Select(classification => new FindManyClassificationsResponse
        {
            Id = classification.Id,
            YearId = classification.YearId,
            Year = classification.Year,
            TeacherId = classification.TeacherId,
            SubscriptionId = classification.SubscriptionId,
            Name = classification.Name,
            SituationId = classification.SituationId,
            Situation = classification.Situation,
            PositionId = classification.PositionId,
            Position = classification.Position,
            UnitId = classification.UnitId,
            Unit = classification.Unit,
            DisciplineId = classification.DisciplineId,
            Discipline = classification.Discipline,
            Phone = classification.Phone,
            Cellphone = classification.Cellphone,
            Speciality = classification.Speciality,
            IsRemove = classification.IsRemove,
            IsAdido = classification.IsAdido,
            IsReadapted = classification.IsReadapted,
            IsReadingRoom = classification.IsReadingRoom,
            IsComputing = classification.IsComputing,
            IsSupplementCharge = classification.IsSupplementCharge,
            IsTutoring = classification.IsTutoring,
            IsAmbientalEdication = classification.IsAmbientalEdication,
            IsRobotics = classification.IsRobotics,
            IsMusic = classification.IsMusic,
            T1 = classification.T1,
            T2 = classification.T2,
            T3 = classification.T3,
            T4 = classification.T4,
            T5 = classification.T5,
            T6 = classification.T6,
            T7 = classification.T7,
            T8 = classification.T8,
            T9 = classification.T9,
            T10 = classification.T10,
            T11 = classification.T11,
            T12 = classification.T12,
            T13 = classification.T13,
            T14 = classification.T14,
            T15 = classification.T15,
            T16 = classification.T16,
            T17 = classification.T17,
            T18 = classification.T18,
            T19 = classification.T19,
            T20 = classification.T20,
            T21 = classification.T21,
            T22 = classification.T22,
        });
    }
}
