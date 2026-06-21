using Workflow.Domain.Enums;

namespace Workflow.API.DTOs.Requests
{
	public sealed class WorkRequest
	{
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Priority Priority { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
