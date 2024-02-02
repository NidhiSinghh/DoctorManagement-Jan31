namespace DoctorApplication.Exceptions
{
    public class NoSuchPatientException:ApplicationException
    {
        string message;
        public NoSuchPatientException()
        {
            message = "No such patient exists";
        }
        public override string Message => base.Message;
    }
}
