namespace MonthlyCalculatorAPI.Utilities.Security
{
    public partial class AppSettings
    {
        public class LoginResponseDTO
        {
            public string Access_Token { get; set; }


            public LoginResponseDTO(string token)
            {
                Access_Token = token;
            }
        }
    }
}