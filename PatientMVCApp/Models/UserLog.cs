namespace PatientMVCApp.Models
{
    public class UserLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }
    }
}