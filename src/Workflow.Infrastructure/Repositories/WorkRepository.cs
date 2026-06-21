using Microsoft.EntityFrameworkCore;
using Workflow.Application.Interfaces.Repositories;
using Workflow.Domain.Context;
using Workflow.Domain.Entities;
using Workflow.Domain.Enums;

public sealed class WorkRepository : IWorkRepository
{
    private readonly WorkflowContext _context;

    public WorkRepository(WorkflowContext context)
    {
        _context = context;
    }

    public async Task<Work?> Get(Guid id, CancellationToken cancellationToken)
    {
        Work? entity = await _context.Work.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<List<Work>> Get(CancellationToken cancellationToken)
    {
        List<Work> entities = await _context.Work
            .Include(entities => entities.Histories)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task<Work> Create(Work entity, CancellationToken cancellationToken)
    {
        _context.Work.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Work?> Update(Guid id, Work entity, CancellationToken cancellationToken)
    {
        var existing = await _context.Work.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        if (existing is null) return null;

        existing.Title = entity.Title;
        existing.Description = entity.Description;
        existing.Priority = entity.Priority;
        existing.UpdatedAt = DateTimeOffset.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return existing;
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Work.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        if (entity is null) return false;

        _context.Work.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task ChangeStatus(Guid id, Status newStatus, string? reason, CancellationToken cancellationToken)
    {
        Work work = await _context.Work.FindAsync([id, cancellationToken], cancellationToken: cancellationToken) ?? throw new InvalidOperationException($"Work with id {id} not found");

        if (work.Status == newStatus) return;

        Status oldStatus = work.Status;
        work.Status = newStatus;

        var history = new WorkHistory
        {
            WorkId = id,
            FromStatus = oldStatus,
            ToStatus = newStatus,
            Description = reason ?? string.Empty
        };

        _context.WorkHistory.Add(history); 
        await _context.SaveChangesAsync(cancellationToken);
    }
}