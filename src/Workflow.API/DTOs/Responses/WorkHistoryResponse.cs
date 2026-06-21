using Workflow.Domain.Enums;

namespace Workflow.API.DTOs.Responses
{
    public class WorkHistoryResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Status FromStatus { get; set; }
        public Status ToStatus { get; set; }
    }
}
