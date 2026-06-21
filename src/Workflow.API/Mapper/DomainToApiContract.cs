using Workflow.API.DTOs.Requests;
using Workflow.API.DTOs.Responses;
using Workflow.Domain.Entities;

namespace Workflow.API.Mapper
{
    public static class DomainToApiContract
    {
        public static Work ToWork(this WorkRequest request)
        {
            return new Work
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
            };
        }
        public static List<Work> ToWork(this IEnumerable<WorkRequest> works)
        {
            return works.Select(w => w.ToWork()).ToList();
        }
    }
}