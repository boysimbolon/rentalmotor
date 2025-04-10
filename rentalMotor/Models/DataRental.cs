namespace rentalMotor.Models
{
    public class DataRental
    {
        public int Id { get; set; }
        public int IdMotor { get; set; }
        public string Nama { get; set; } = "";
        public string NoTelpon { get; set; } = "";
        public string? Email { get; set; }
        public StatusSewa StatusSewa { get; set; }
        public DateTime TanggalSewa { get; set; }
        public int LamaSewa { get; set; }

        public Motor? Motor { get; set; }

        // Properti tambahan untuk tampilan
        public string? NamaMotor => Motor?.NamaMotor;
    }
    public enum StatusSewa
    {
        Disewa,
        Selesai
    }
}
