using Workflow.API.DTOs.Responses;
using Workflow.Domain.Entities;

namespace Workflow.API.Mapper
{
    public static class ApiContractToDomain
    {
        public static WorkResponse ToWorkResponse(this Work work)
        {
            return new WorkResponse
            {
                Id = work.Id,
                Title = work.Title,
                Description = work.Description,
                Status = work.Status,
                Priority = work.Priority,
                CompletedAt = work.CompletedAt
            };
        }

        public static List<WorkResponse> ToWorkResponse(this IEnumerable<Work> works)
        {
            return works.Select(w => w.ToWorkResponse()).ToList();
        }
    }
}