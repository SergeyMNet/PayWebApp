using System;
using System.Collections.Generic;
using System.Text;
using PaymentBLL.Models;
using System.Threading.Tasks;

namespace PaymentBLL.Providers
{
    public class FakePayService : IPayService
    {
        public async Task<TokenResult> GetTokenAsync(string custmerId)
        {
            // todo: send customerId to payment server and get nonce token
            await Task.Delay(500);
            var token = Guid.NewGuid().ToString();
            return new TokenResult()
            {
                IsSuccess = true,
                Message = "Is Success",
                Token = token
            };
        }

        public async Task<TransactionResult> HoldAsync(string nonce, decimal amount)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            var transactionId = Guid.NewGuid().ToString();
            return new TransactionResult
            {
                IsSuccess = true,
                Message = "Is Success",
                TransactionId = transactionId
            };
        }

        public async Task<BaseResultModel> ChargeAsync(string nonce, decimal amount)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResultModel
            {
                IsSuccess = true,
                Message = "Is Success"
            };
        }

        public async Task<BaseResultModel> ChargeAsync(string nonce, string transactionId)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResultModel
            {
                IsSuccess = true,
                Message = "Is Success"
            };
        }
        
        public async Task<BaseResultModel> RefundAsync(string nonce, string transactionId, decimal amount)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResultModel
            {
                IsSuccess = true,
                Message = "Is Success"
            };
        }
    }
}
