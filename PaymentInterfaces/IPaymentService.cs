using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentModels;

namespace PaymentInterfaces
{
    public interface IPaymentOperations<T> where T : TransactionResult
    {   
        Task<T> HoldAsync(decimal amount, params string[] optional_parameters);
        Task<T> ChargeAsync(decimal amount, params string[] optional_parameters);
        Task<T> RefundAsync(decimal amount, string transactionId, params string[] optional_parameters);
    }
}
