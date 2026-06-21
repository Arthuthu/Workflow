using Workflow.Domain.Entities;
using Workflow.Domain.Enums;

namespace Workflow.Application.Interfaces.Services
{
    public interface IWorkService
    {
        Task<List<Work>> Get(CancellationToken cancellationToken);
        Task<Work?> Get(Guid id, CancellationToken cancellationToken);
        Task<Work> Create(Work entity, CancellationToken cancellationToken);
        Task<Work?> Update(Guid id, Work entity, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task ChangeStatusAsync(Guid id, Status newStatus, string? reason, CancellationToken cancellationToken);
    }
}