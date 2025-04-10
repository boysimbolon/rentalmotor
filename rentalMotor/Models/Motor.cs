namespace rentalMotor.Models
{
    public class Motor
    {
        public int Id { get; set; }
        public string NamaMotor { get; set; } = string.Empty;
        public string PlatMotor { get; set; } = string.Empty;
        public decimal HargaSewa { get; set; }
    }
}
