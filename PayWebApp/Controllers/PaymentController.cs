using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentInterfaces;
using PaymentModels;
using PayWebApp.Models;

//  Summary:
//  По требованию одного из заказчиков необходимо реализовать возможность взимать плату у клиентов за определенные услуги.
//  Для реализации этой возможности заказчик должен иметь аккаунт у одного из платежного провайдера, 
//  система которого предоставляет возможность списывать денежные средства с кредитных карт.
//  Предположим это будет PayJunction, XXX, либо на ваш выбор какой-нибудь другой.

//  Архитектура должна быть гибкой и не привязана к конкретному провайдеру. 
//  Заказчик в любой момент должен иметь возможность подключить другую реализацию. 
//  Настройки конкретного провайдера могут время от времени изменятся. 

// Функционал системы следующий: 
//    1) Hold – позволяет временно снять определенную сумму с карты клиента, провайдеры обычно возвращают TransactionID 
//    2) Charge – позволяет списать деньги как моментально, так и замороженные с помощью TransactionID      
//    3) Refund  - позволяет вернуть деньги клиенту используя TransactionID.
// 
//  На свое усмотрение можете вносить в задание аргументированные изменения.
//  Не стоит тратить время на реализацию интеграции с реальными провайдерами, 
//  а также с любыми другими источниками хранения данных.
//  При любой необходимости берите данные из виртуального репозитория и т.д.

namespace PayWebApp.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentOperations<TransactionResult> _payService;

        public PaymentController(IPaymentOperations<TransactionResult> payService)
        {
            _payService = payService;
        }
        
        /// POST api/payments/hold/
        /// <summary>
        /// create transaction
        /// </summary>
        /// <param name="req">must be: user_id/token/nonce, amonut/price </param>
        /// <returns>created transaction id</returns>
        [HttpPost("hold")]
        public async Task<IActionResult> Hold(HoldRequest req)
        {
            if (!req.IsValid())
                return StatusCode(400, new { error_message = "Model is not valid" });

            var result = await _payService.HoldAsync(req.Amount);
            if (result.IsSuccess)
            {
                return Ok(new { transaction_id = result.TransactionId });
            }
            else
            {
                return StatusCode(400, result.Message);
            }
        }

        /// POST api/payments/charge
        /// <summary>
        /// Run exist transaction or create new
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("charge")]
        public async Task<IActionResult> Charge(ChargeRequest req)
        {
            if (!req.IsValid())
                return StatusCode(400, new { error_message = "Model is not valid" });

            BaseResult result = await _payService.ChargeAsync(req.Amount, req.TransactionID);
            
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400, result.Message);
            }
        }

        /// POST api/payments/refund
        /// <summary>
        /// refund from exist transaction
        /// </summary>
        /// <param name="req">user id, trans id</param>
        /// <returns></returns>
        [HttpPost("refund")]
        public async Task<IActionResult> Refund(RefundReuest req)
        {
            if (!req.IsValid())
                return StatusCode(400, new { error_message = "Model is not valid" });

            var result = await _payService.RefundAsync(req.Amount, req.TransactionID);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400, result.Message);
            }
        }
    }
}
