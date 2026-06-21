using Workflow.Domain.Entities;

namespace Workflow.Application.Interfaces.Repositories
{
    public interface IWorkRepository
    {
        Task<List<Work>> Get(CancellationToken cancellationToken);
        Task<Work?> Get(Guid id, CancellationToken cancellationToken);
        Task<Work> Create(Work entity, CancellationToken cancellationToken);
        Task<Work?> Update(Guid id, Work entity, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    }
}