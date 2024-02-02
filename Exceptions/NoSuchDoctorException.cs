namespace DoctorApplication.Exceptions
{
    public class NoSuchDoctorException:ApplicationException
    {

        string message;
        public NoSuchDoctorException()
        {
            message = "No such doctor exists";
        }
        public override string Message => base.Message;
    }
}
