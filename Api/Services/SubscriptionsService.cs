using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class SubscriptionsService(IUnitOfWork unitOfWork) : ISubscriptionsService
{
    public async Task<Subscription> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .SubscriptionsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Subscription>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.SubscriptionsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.SubscriptionsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Subscription> CreateAsync(CreateServiceParams parameters)
    {
        var props = (SubscriptionProps)parameters.Props;
        var subscription = new Subscription(props);
        var titles = props.Titles?.ToList() ?? [];
        titles.ForEach(t => t.SubscriptionId = subscription.Id);
        var points = props.Points?.ToList() ?? [];
        points.ForEach(p => p.SubscriptionId = subscription.Id);
        var year = await unitOfWork
            .YearsRepository
            .FindOneAsync(new() { Where = new () { Id = props.YearId } });
        var teacher = await unitOfWork
            .TeachersRepository
            .FindOneAsync(
            new() 
            { 
                Where = new() { Id = props.TeacherId }, 
                Includes = new IncludesTeachersParams 
                { Unit = true, Discipline = true, Situation = true, Position = true } 
            });
        var classification = new Classification()
        {
            YearId = props.YearId,
            SubscriptionId = subscription.Id,
            TeacherId = teacher?.Id,
            Name = teacher?.Name,
            Phone = teacher?.Phone,
            Cellphone = teacher?.Cellphone,
            UnitId = teacher?.UnitId,
            Unit = teacher?.Unit?.Name,
            DisciplineId = teacher?.DisciplineId,
            Discipline = teacher?.Discipline?.Name,
            PositionId = teacher?.PositionId,
            Position = teacher?.Position?.Name,
            SituationId = teacher?.SituationId,
            Situation = teacher?.Situation?.Name,
            Speciality = teacher?.Speciality,
            IsAdido = teacher?.IsAdido,
            IsAmbientalEdication = teacher?.IsAmbientalEdication,
            IsComputing = teacher?.IsComputing,
            IsMusic = teacher?.IsMusic,
            IsReadapted = teacher?.IsReadapted,
            IsReadingRoom = teacher?.IsReadingRoom,
            IsRemove = teacher?.IsRemove,
            IsRobotics = teacher?.IsRobotics,
            IsSupplementCharge = teacher?.IsSupplementCharge,
            IsTutoring = teacher?.IsTutoring,
            T1 = points[0].Points,
            T2 = points[1].Points,
            T3 = points[2].Points,
            T4 = points[3].Points,
            T5 = points[4].Points,
            T6 = points[5].Points,
            T7 = points[6].Points,
            T8 = points[7].Points,
            T9 = points[8].Points,
            T10 = points[9].Points,
            T11 = points[10].Points,
        };
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SubscriptionsRepository.CreateAsync(subscription);
        await unitOfWork.TitlesBySubscriptionsRepository.CreateManyAsync([.. titles]);
        await unitOfWork.PointsBySubscriptionsRepository.CreateManyAsync([.. points]);
        await unitOfWork.ClassificationsRepository.CreateAsync(classification);
        await unitOfWork.Commit(transaction);
        return subscription;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (SubscriptionProps)parameters.Props;
        var subscription = await FindOneAsync(parameters);
        subscription.Update(props);
        var titles = props.Titles?.ToList() ?? [];
        titles.ForEach(t => t.SubscriptionId = subscription.Id);
        var points = props.Points?.ToList() ?? [];
        points.ForEach(p => p.SubscriptionId = subscription.Id);
        var year = await unitOfWork
            .YearsRepository
            .FindOneAsync(new() { Where = new() { Id = props.YearId } });
        var teacher = await unitOfWork
            .TeachersRepository
            .FindOneAsync(
            new()
            {
                Where = new() { Id = props.TeacherId },
                Includes = new IncludesTeachersParams
                { Unit = true, Discipline = true, Situation = true, Position = true }
            });
        var classificationProps = new ClassificationProps()
        {
            YearId = props.YearId,
            SubscriptionId = subscription.Id,
            TeacherId = teacher?.Id,
            Name = teacher?.Name,
            Phone = teacher?.Phone,
            Cellphone = teacher?.Cellphone,
            UnitId = teacher?.UnitId,
            Unit = teacher?.Unit?.Name,
            DisciplineId = teacher?.DisciplineId,
            Discipline = teacher?.Discipline?.Name,
            PositionId = teacher?.PositionId,
            Position = teacher?.Position?.Name,
            SituationId = teacher?.SituationId,
            Situation = teacher?.Situation?.Name,
            Speciality = teacher?.Speciality,
            IsAdido = teacher?.IsAdido,
            IsAmbientalEdication = teacher?.IsAmbientalEdication,
            IsComputing = teacher?.IsComputing,
            IsMusic = teacher?.IsMusic,
            IsReadapted = teacher?.IsReadapted,
            IsReadingRoom = teacher?.IsReadingRoom,
            IsRemove = teacher?.IsRemove,
            IsRobotics = teacher?.IsRobotics,
            IsSupplementCharge = teacher?.IsSupplementCharge,
            IsTutoring = teacher?.IsTutoring,
            T1 = points[0].Points,
            T2 = points[1].Points,
            T3 = points[2].Points,
            T4 = points[3].Points,
            T5 = points[4].Points,
            T6 = points[5].Points,
            T7 = points[6].Points,
            T8 = points[7].Points,
            T9 = points[8].Points,
            T10 = points[9].Points,
            T11 = points[10].Points,
        };
        var classification = await unitOfWork.
            ClassificationsRepository.
            FindOneAsync(
            new() 
            { Where = new FindManyClassificationsParams { SubscriptionId = subscription.Id } 
            }) ?? throw new NotFoundException(Errors.UserNotFound);
        classification.Update(classificationProps);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork
            .TitlesBySubscriptionsRepository
            .DeleteManyAsync(
            new FindManyTitleBySubscriptionsParams
            { SubscriptionId = subscription.Id });
        await unitOfWork
            .PointsBySubscriptionsRepository
            .DeleteManyAsync(
            new FindManyPointsBySubscriptionsParams
            { SubscriptionId = subscription.Id });
        await unitOfWork.TitlesBySubscriptionsRepository.CreateManyAsync([.. titles]);
        await unitOfWork.PointsBySubscriptionsRepository.CreateManyAsync([.. points]);
        unitOfWork.SubscriptionsRepository.Update(subscription);
        unitOfWork.ClassificationsRepository.Update(classification);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var subscription = await FindOneAsync(parameters);
        var classification = await unitOfWork.
            ClassificationsRepository.
            FindOneAsync(
            new()
            {
                Where = new FindManyClassificationsParams { SubscriptionId = subscription.Id }
            }) ?? throw new NotFoundException(Errors.UserNotFound);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork
            .TitlesBySubscriptionsRepository
            .DeleteManyAsync(
            new FindManyTitleBySubscriptionsParams 
            { SubscriptionId = parameters.Id });
        await unitOfWork
            .PointsBySubscriptionsRepository
            .DeleteManyAsync(
            new FindManyPointsBySubscriptionsParams
            { SubscriptionId = parameters.Id });
        unitOfWork.ClassificationsRepository.Delete(classification);
        unitOfWork.SubscriptionsRepository.Delete(subscription);
        await unitOfWork.Commit(transaction);
    }
}
