namespace MonthlyCalculatorAPI.Utilities.Security
{
    public partial class AppSettings
    {
        public class LoginDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}