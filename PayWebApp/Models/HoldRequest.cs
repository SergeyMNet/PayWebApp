using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayWebApp.Models
{
    public class HoldRequest : BasePayRequestModel
    {
        public override bool IsValid()
        {
            return base.IsValid() && this.Amount > 0;
        }
    }
}
