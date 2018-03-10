using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayWebApp.Models
{
    public class RefundReuest : BasePayRequestModel
    {
        [JsonProperty("transaction_id")]
        public string TransactionID { get; set; }

        public override bool IsValid()
        {
            return base.IsValid() && this.Amount > 0 && !String.IsNullOrEmpty(this.TransactionID);
        }
    }
}
