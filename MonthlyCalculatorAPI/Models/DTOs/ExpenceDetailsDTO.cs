namespace MonthlyCalculatorAPI.Models.DTOs
{
    public class ExpenceDetailsDTO
    {
        public string UserName { get; set; }
        public string ExpenceTypeName { get; set; }
        public decimal ExpenceAmount { get; set; }
        public DateTime ExpenceTime { get; set; }
        
    }
}
