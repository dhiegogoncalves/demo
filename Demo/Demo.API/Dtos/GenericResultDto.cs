using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Dtos
{
    public class GenericResultDto
    {
        public GenericResultDto() { }

        public GenericResultDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public GenericResultDto(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
