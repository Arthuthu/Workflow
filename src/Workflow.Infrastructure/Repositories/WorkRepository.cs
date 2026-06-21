using Microsoft.EntityFrameworkCore;
using Workflow.Application.Interfaces.Repositories;
using Workflow.Domain.Context;
using Workflow.Domain.Entities;

namespace Workflow.Infrastructure.Repositories
{
    public sealed class WorkRepository : IWorkRepository
    {
        private readonly WorkContext _context;

        public WorkRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<Work?> Get(Guid id, CancellationToken cancellationToken)
        {
            Work? work = await _context.Work.FindAsync(id, cancellationToken);
            return work;
        }

        public async Task<List<Work>> Get(CancellationToken cancellationToken)
        {
            List<Work> works = await _context.Work.ToListAsync(cancellationToken);
            return works;
        }

        public async Task<Work> Create(Work entity, CancellationToken cancellationToken)
        {
            _context.Work.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<Work?> Update(Guid id, Work entity, CancellationToken cancellationToken)
        {
            int affected = await _context.Work
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Title, entity.Title)
                    .SetProperty(x => x.Description, entity.Description)
                    .SetProperty(x => x.Histories, entity.Histories)
                    .SetProperty(x => x.Priority, entity.Priority)
                    .SetProperty(x => x.CompletedAt, entity.CompletedAt),
                    cancellationToken);

            return affected > 0 ? entity : null;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            Work? entity = await _context.Work.FindAsync(id) ?? throw new Exception("Ocorreu um erro ao deletar o work: Work não encontrado");

            int affectedRows = await _context.Work.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
            return affectedRows > 0;
        }
    }
}
