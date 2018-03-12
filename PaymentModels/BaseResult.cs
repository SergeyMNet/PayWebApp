using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentModels
{
    public class BaseResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
