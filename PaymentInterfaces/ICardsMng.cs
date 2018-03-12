using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentModels;

namespace PaymentInterfaces
{
    public interface ICardsMng<TCard, TResult> 
            where TCard : BaseCardModel 
            where TResult : BaseResult
    {
        Task<IList<TCard>> GetAllCardsAsync(string customerId, params string[] parameters);
        Task<TResult> AddCardAsync(string customerId, TCard card, params string[] parameters);
        Task<TResult> RemoveCardAsync(string customerId, string cardId, params string[] parameters);

        Task<TResult> SetFavoriteCardAsync(string customerId, TCard card, params string[] parameters);
        Task<TResult> GetFavoriteCardAsync(string customerId, params string[] parameters);
    }
}
