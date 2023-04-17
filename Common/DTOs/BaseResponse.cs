using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class BaseResponse<T>
    {
        public T Content { get; set; } = default;
        public string? Error { get; set; } = null;

        public BaseResponse()
        {

        }

        public BaseResponse(T value)
        {
            Content = value;
        }
    }
}
