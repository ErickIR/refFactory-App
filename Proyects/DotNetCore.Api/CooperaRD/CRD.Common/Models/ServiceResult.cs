using CRD.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CRD.Common.Models
{
    public class ServiceResult<T>
    {
        [JsonIgnore]
        public bool Success { get; private set; } = true;

        [JsonIgnore]
        public ResponseCode Code { get; private set; }

        public T Result { get; private set; }

        public string ErrorCode { get; private set; }

        public string ErrorMessage { get; private set; }

        public ServiceResult(T value)
        {
            Code = ResponseCode.Ok;
            ErrorCode = ((int)Code).ToString();
            ErrorMessage = ResponseCode.Ok.ToString();
            Result = value;
        }

        public ServiceResult(ResponseCode code, string message)
        {
            Code = code;
            ErrorMessage = message;
            ErrorCode = ((int)Code).ToString();
            Success = false;
        }

        public static ServiceResult<T> ResultOk(T value) => new ServiceResult<T>(value);

        public static ServiceResult<T> ResultFailed(ResponseCode code, string message) => new ServiceResult<T>(code, message);
    }
}
