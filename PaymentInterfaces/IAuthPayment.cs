using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentModels;

namespace PaymentInterfaces
{
    public interface IAuthPayment
    {
        Task<BaseResult> Init(params string[] parametersForInit);
        Task<TokenResult> GetTokenAsync(string customerId);
    }
}
