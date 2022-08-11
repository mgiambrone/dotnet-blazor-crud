using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazorcrud.Server.Models
{
    public class CISSTaskRepository : ICISSTaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public CISSTaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CISSTask> AddCISSTask(CISSTask task)
        {
            var result = await _appDbContext.CISSTasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CISSTask?> DeleteCISSTask(int Id)
        {
            var result = await _appDbContext.CISSTasks.FirstOrDefaultAsync(u => u.Id==Id);
            if (result!=null)
            {
                _appDbContext.CISSTasks.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("CISSTask not found");
            }
            return result;
        }

        public async Task<CISSTask?> GetCISSTask(int Id)
        {
            var result = await _appDbContext.CISSTasks.FirstOrDefaultAsync(u => u.Id==Id);
            if(result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("CISSTask not found");
            }
        }

        public PagedResult<CISSTask> GetCISSTasks(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.CISSTasks
                    .Where(u => u.UserName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(u => u.StartTimestamp)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.CISSTasks
                    .OrderBy(u => u.EndTimestamp)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<CISSTask?> UpdateCISSTask(CISSTask task)
        {
            var result = await _appDbContext.CISSTasks.FirstOrDefaultAsync(u => u.Id==task.Id);
            if (result!=null)
            {
                // Update existing CISSTask
                _appDbContext.Entry(result).CurrentValues.SetValues(task);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("CISSTask not found");
            }
            return result;
        }
    }
}