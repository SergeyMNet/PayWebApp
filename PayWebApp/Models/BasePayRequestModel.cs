using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayWebApp.Models
{
    public abstract class BasePayRequestModel
    {   
        [JsonProperty("user_key")]
        public string UserKey { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        

        public virtual bool IsValid()
        {
            return !String.IsNullOrEmpty(this.UserKey);
        }
    }
}
