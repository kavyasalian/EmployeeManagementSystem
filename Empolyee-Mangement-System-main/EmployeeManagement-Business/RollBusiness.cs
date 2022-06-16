using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    public class RollBusiness
    {
        private readonly RollRepository RollRepository;
        public RollBusiness()
        {
            this.RollRepository = new RollRepository();
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(Roll roll)
        {
            await RollRepository.Create(roll);
            return HttpStatusCode.OK;

        }
    }
}
