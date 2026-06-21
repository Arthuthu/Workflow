using Workflow.Domain.Enums;

namespace Workflow.API.DTOs.Responses
{
	public sealed class WorkResponse
	{
		public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
