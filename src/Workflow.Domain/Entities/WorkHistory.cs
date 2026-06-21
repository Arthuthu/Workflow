using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities
{
    public class WorkHistory : Entity
    {
        public string Description { get; set; } = string.Empty;
        public Status FromStatus { get; set; }
        public Status ToStatus { get; set; }

        public Guid WorkId { get; set; }
        public Work Work { get; set; } = null!;
    }
}
