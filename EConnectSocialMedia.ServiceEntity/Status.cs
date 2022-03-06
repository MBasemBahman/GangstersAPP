namespace GangstersAPP.ServiceEntity
{
    public class Status
    {
        public Status()
        {
        }

        public Status(bool Success)
        {
            this.Success = Success;
            ErrorMessage = "";
        }

        public bool Success { get; private set; } = default;

        public string ErrorMessage { get; set; } = "Error Message!";

        public string ExceptionMessage { get; set; } = "Exception Message!";
    }

    public class Set_Refresh
    {
        public string RefreshToken { get; set; }

        public string Expires { get; set; }
    }
}
