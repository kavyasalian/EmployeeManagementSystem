using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository.Entities
{
    public class RollRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public RollRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }
        public async Task Create(Roll roll)
        {
            _dbContext.Rolls.Add(roll);
            await _dbContext.SaveChangesAsync();
        }

    }
}
