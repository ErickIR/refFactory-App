using CitizenApp.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class HttpResult<T>
    {
        public T Result { get; set; }
        public ResponseCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
