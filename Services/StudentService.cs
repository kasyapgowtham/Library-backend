using backend.Services.Interfaces;
using backend.DTOs;
using backend.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using backend.Models;

namespace backend.Services
{
    public class StudentService : IstudentService
    {
        private readonly StudentDb _context;
        private readonly PasswordHasher<StudentModel> _passwordHasher = new PasswordHasher<StudentModel>();

        public StudentService(StudentDb context )
        {
            _context = context;
            _passwordHasher = new PasswordHasher<StudentModel>();
        }

        public StudentRegister Register(StudentRegister studentRegister)
        {
            var user = new StudentModel
            {
                studentId = studentRegister.StudentId,
                studentName = studentRegister.StudentName,
                Email= studentRegister.StudentEmail,
                Created= studentRegister.created
            };
            user.password = _passwordHasher.HashPassword(user, studentRegister.password);
            _context.Students.Add( user );
            _context.SaveChanges();
            return studentRegister;
        }
        public studentResponse Login(StudentRequest studentRequest)
        {
            var user = _context.Students.FirstOrDefault(u => u.studentId == studentRequest.studentId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.password, studentRequest.StudentPassword);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password");
            }
            return new studentResponse
            {
                StudentId = user.studentId,
                StudentName = user.studentName,
                StudentEmail=user.Email
            };
        }
        public async Task  payment(paymentRequest paymentRequest)
        {
            var payment = new Payment
            {
                Email = paymentRequest.Email,
                Amount = paymentRequest.Amount,
                cardnumber = paymentRequest.cardnumber,
                cardholdernname = paymentRequest.cardholdernname,
                Expiry = paymentRequest.Expiry,
                CVV = paymentRequest.CVV
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            //return new paymentResponse
            //{
            //    Email = payment.Email,                
            //};
        }
        public async Task booking(BookRequest bookingRequest)
        {
            var booking = new booking
            {
                studentId = bookingRequest.studentId,
                Email = bookingRequest.Email,
                booked = bookingRequest.booked
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            //return new bookingResponse
            //{
            //    studentId = booking.studentId,
            //    Email = booking.Email,
            //};
        }
    }
}
