using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core.BaseResponse
{
    public class ApiResponse<T>
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse<T> Success(string message = "İşlem Başarılı")
        {
            this.isSuccess = true;
            this.Message = message;
            return this;
        }

        public ApiResponse<T> Error(string message = "İşlem Başarısız")
        {
            this.isSuccess = false;
            this.Message = message;
            return this;
        }
    }
}
