using Workflow.Domain.Enums;

namespace Workflow.API.DTOs.Requests
{
	public sealed class ChangeStatusRequest
	{
        public string? Reason { get; set; } = null;
        public Status Status { get; set; } = Status.InProgress;
    }
}
