using PaymentBLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL
{
    public interface IPayService
    {
        Task<TokenResult> GetTokenAsync(string custmerId);

        Task<TransactionResult> HoldAsync(string nonce, decimal amount);

        Task<BaseResultModel> ChargeAsync(string nonce, decimal amount);
        Task<BaseResultModel> ChargeAsync(string nonce, string transactionId);

        Task<BaseResultModel> RefundAsync(string nonce, string transactionId, decimal amount);
    }
}
