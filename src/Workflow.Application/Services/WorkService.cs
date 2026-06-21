using Workflow.Application.Interfaces.Repositories;
using Workflow.Application.Interfaces.Services;
using Workflow.Domain.Entities;
using Workflow.Domain.Enums;

namespace Workflow.Application.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _repository;

        public WorkService(IWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Work?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.Get(id, cancellationToken);
        }

        public async Task<List<Work>> Get(CancellationToken cancellationToken)
        {
            return await _repository.Get(cancellationToken);
        }

        public async Task<Work> Create(Work entity, CancellationToken cancellationToken)
        {
            return await _repository.Create(entity, cancellationToken);
        }

        public async Task<Work?> Update(Guid id, Work entity, CancellationToken cancellationToken)
        {
            return await _repository.Update(id, entity, cancellationToken);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.Delete(id, cancellationToken);
        }

        public async Task ChangeStatusAsync(Guid id, Status newStatus, string? reason, CancellationToken cancellationToken)
        {
            await _repository.ChangeStatus(id, newStatus, reason, cancellationToken);
        }
    }
}
