namespace DoctorApplication.Exceptions
{
    public class NoSuchAppointmentException:ApplicationException
    {
        string message;
        public NoSuchAppointmentException()
        {
            message = "No such appointment exists";
        }
        public override string Message => base.Message;
    }

}
