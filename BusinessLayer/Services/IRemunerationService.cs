using Common.DTOs;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IRemunerationService
    {
        public Task<BaseResponse<List<SalesByProductResponse>>> GetRemunerationByDateAsync(int month, int year);
    }
}
