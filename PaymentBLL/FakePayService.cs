using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentInterfaces;
using PaymentModels;

/// <summary>
/// Mock service - only for testing
/// 
/// separated on partial class for simple reading, 
/// in future will separate to different files
/// </summary>
namespace PaymentBLL.Providers
{
    /// <summary>
    /// implementation of Auth payment
    /// </summary>
    public partial class FakePayService : IAuthPayment
    {
        public async Task<TokenResult> GetTokenAsync(string customerId)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            var res = new TokenResult();
            res.Token = Guid.NewGuid().ToString();
            return res;
        }

        public async Task<BaseResult> Init(params string[] parametersForInit)
        {
            // todo: Init payment server
            await Task.Delay(500);
            return new BaseResult();
        }
    }

    /// <summary>
    /// implementation of base payment operations
    /// </summary>
    public partial class FakePayService : IPaymentOperations<TransactionResult>
    {
        public async Task<TransactionResult> HoldAsync(decimal amount, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new TransactionResult();
        }

        public async Task<TransactionResult> ChargeAsync(decimal amount, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new TransactionResult();
        }

        public async Task<TransactionResult> RefundAsync(decimal amount, string transactionId, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new TransactionResult();
        }
    }

    /// <summary>
    /// implementation of card manager
    /// </summary>
    public partial class FakePayService : ICardsMng<BaseCardModel, BaseResult>
    { 
        public async Task<IList<BaseCardModel>> GetAllCardsAsync(string customerId, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new List<BaseCardModel>();
        }

        public async Task<BaseResult> AddCardAsync(string customerId, BaseCardModel card, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResult();
        }

        public async Task<BaseResult> RemoveCardAsync(string customerId, string cardId, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResult();
        }

        public async Task<BaseResult> SetFavoriteCardAsync(string customerId, BaseCardModel card, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResult();
        }

        public async Task<BaseResult> GetFavoriteCardAsync(string customerId, params string[] parameters)
        {
            // todo: send request to payment server
            await Task.Delay(500);
            return new BaseResult();
        }
    }
}
