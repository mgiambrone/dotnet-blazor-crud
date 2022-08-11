using Blazorcrud.Client.Shared;
using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;

namespace Blazorcrud.Client.Services
{
    public class CISSTaskService: ICISSTaskService
    {
        private readonly IHttpService _httpService;

        public CISSTaskService(IHttpService httpService)
        {
            _httpService=httpService;
        }

        public async Task<PagedResult<CISSTask>> GetCISSTasks(string? name, string page)
        {
            return await _httpService.Get<PagedResult<CISSTask>>("api/CISSTask" + "?page=" + page + "&name=" + name);
        }

        public async Task<CISSTask> GetCISSTask(int id)
        {
            return await _httpService.Get<CISSTask>($"api/CISSTask/{id}");
        }

        public async Task DeleteCISSTask(int id)
        {
            await _httpService.Delete($"api/CISSTask/{id}");
        }

        public async Task AddCISSTask(CISSTask task)
        {
            await _httpService.Post($"api/CISSTask", task);
        }

        public async Task UpdateCISSTask(CISSTask task)
        {
            await _httpService.Put($"api/CISSTask", task);
        }
    }
}