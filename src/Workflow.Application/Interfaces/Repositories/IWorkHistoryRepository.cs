using Workflow.Domain.Entities;

public interface IWorkHistoryRepository
{
    Task<Work> Create(Work entity, CancellationToken cancellationToken);
}