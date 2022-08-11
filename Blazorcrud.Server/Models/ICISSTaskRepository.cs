using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;

namespace Blazorcrud.Server.Models
{
    public interface ICISSTaskRepository
    {
        PagedResult<CISSTask> GetCISSTasks(string? name, int page);
        Task<CISSTask?> GetCISSTask(int Id);
        Task<CISSTask> AddCISSTask(CISSTask task);
        Task<CISSTask?> UpdateCISSTask(CISSTask task);
        Task<CISSTask?> DeleteCISSTask(int id);
    }
}