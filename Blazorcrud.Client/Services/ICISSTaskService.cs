using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;

namespace Blazorcrud.Client.Services
{
    public interface ICISSTaskService
    {
        Task<PagedResult<CISSTask>> GetCISSTasks(string? name, string page);
        Task<CISSTask> GetCISSTask(int id);

        Task DeleteCISSTask(int id);

        Task AddCISSTask(CISSTask task);

        Task UpdateCISSTask(CISSTask task);
    }
}