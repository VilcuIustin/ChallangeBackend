using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IRemunerationRepository
    {
        public Task<List<SalesByProductResponse>> GetRemunerationByDateAsync(int dateId);
    }
}
