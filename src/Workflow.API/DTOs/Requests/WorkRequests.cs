using Workflow.Domain.Enums;

namespace Workflow.API.DTOs.Requests
{
	public sealed class WorkRequest
	{
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Status Status { get; set; } = Status.Open;
        public Priority Priority { get; set; } = Priority.Low;
    }
}
