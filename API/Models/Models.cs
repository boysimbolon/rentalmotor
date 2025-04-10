using System;
using System.Collections.Generic;

namespace RentalMotorApp.Models
{
    public enum StatusSewa
    {
        Disewa,
        Selesai
    }

    public class Motor
    {
        public int Id { get; set; }

        public string NamaMotor { get; set; } = string.Empty;

        public string PlatMotor { get; set; } = string.Empty;

        public decimal HargaSewa { get; set; }

        // Navigasi ke DataRental (relasi satu ke banyak)
        public ICollection<DataRental>? DataRentals { get; set; }
    }

    public class DataRental
    {
        public int Id { get; set; }

        public int IdMotor { get; set; }

        public string Nama { get; set; } = string.Empty;

        public string NoTelpon { get; set; } = string.Empty;

        public string? Email { get; set; }

        public StatusSewa StatusSewa { get; set; }

        public DateTime TanggalSewa { get; set; }

        public int LamaSewa { get; set; }

        // Navigasi ke Motor (relasi ke satu)
        public Motor? Motor { get; set; }
    }
}
