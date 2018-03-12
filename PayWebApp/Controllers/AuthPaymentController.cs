using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayWebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthPaymentController : Controller
    {
        private readonly IAuthPayment _payService;

        public AuthPaymentController(IAuthPayment payService)
        {
            _payService = payService;
        }

       // TODO: Add methods for authorization payment

    }
}
