using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Response
{
    public class BaseResponse
    {

        public BaseResponse()
        {
            IsSuccess = true;
        }

        public BaseResponse(string message = null)
        {
            Message = message;
        }

        public BaseResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<string> ValidationErros { get; set; }
    }
}
