using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities
{
    public class Work : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Status Status { get; set; } = Status.Open;
        public Priority Priority { get; set; }
        public DateTime? CompletedAt { get; set; }

        public List<WorkHistory> Histories { get; set; } = [];
    }
}
