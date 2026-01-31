using Azure.Core;
using backend.DTOs;
using backend.Services;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IstudentService _studentService;
        private readonly IEmailService _emailService;

        public LibraryController(IstudentService studentService, IEmailService emailservice)
        {
            _studentService = studentService;
            _emailService = emailservice;
        }
        [HttpPost("register")]
        public IActionResult RegisterStudent([FromBody] StudentRegister studentRegister)
        {
            var registeredStudent = _studentService.Register(studentRegister);
            return Ok(registeredStudent);
        }
        [HttpPost("Login")]
        public IActionResult LoginStudent([FromBody] StudentRequest studentRequest)
        {
            var studentResponse = _studentService.Login(studentRequest);
            return Ok(studentResponse);
        }
        [HttpPost("payment")]
        public async Task<IActionResult> makePayment([FromBody] paymentRequest paymentRequest)
        {
            // Fix: Call the synchronous payment method without await
           await  _studentService.payment(paymentRequest);
            await _emailService.SendPaymentSuccessEmail(
                paymentRequest.Email,
                paymentRequest.Amount
            );

            return Ok(new { message = "Payment successful" });
        }
        //[HttpPost("booking")]
        //public async Task<IActionResult> makeBooking([FromBody] BookRequest bookingrequest)
        //{
        //    await _studentService.booking(bookingrequest);
        //    await _emailService.SendBookingConfirmationEmail(
        //        bookingrequest.Email,
        //        bookingrequest.booked
        //    );
        //    return Ok(new { message = "Booking successful" });
        //}
    }
}
