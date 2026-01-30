using backend.DTOs;
namespace backend.Services.Interfaces
{
    public interface IstudentService
    {
        StudentRegister Register(StudentRegister studentRegister);

        studentResponse Login(StudentRequest studentRequest);

        Task payment(paymentRequest paymentRequest);

        Task booking(BookRequest bookingRequest);

    }
}
