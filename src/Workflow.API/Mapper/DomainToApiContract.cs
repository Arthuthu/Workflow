using Workflow.API.DTOs.Requests;
using Workflow.API.DTOs.Responses;
using Workflow.Domain.Entities;

namespace Workflow.API.Mapper
{
    public static class DomainToApiContract
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
                Histories = work.Histories.Select(x => new WorkHistoryResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    FromStatus = x.FromStatus,
                    ToStatus = x.ToStatus
                }).ToList()
            };
        }

        public static List<WorkResponse> ToWorkResponse(this IEnumerable<Work> works)
        {
            return works.Select(w => w.ToWorkResponse()).ToList();
        }
    }
}