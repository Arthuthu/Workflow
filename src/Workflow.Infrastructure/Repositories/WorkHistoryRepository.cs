using Workflow.Domain.Context;
using Workflow.Domain.Entities;

public sealed class WorkHistoryRepository : IWorkHistoryRepository
{
    private readonly WorkflowContext _context;

    public WorkHistoryRepository(WorkflowContext context)
    {
        _context = context;
    }

    public async Task<Work> Create(Work entity, CancellationToken cancellationToken)
    {
        _context.Work.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}