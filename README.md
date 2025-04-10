# RentalMotorApp íº€

Aplikasi CRUD sederhana untuk mengelola data **Rental Motor** menggunakan:
- í´§ .NET 8 Web API (C#) + MySQL
- í²» Windows Form (C# WinForms) sebagai client
- í´— Komunikasi via REST API menggunakan `HttpClient`

---

## í³ Struktur Project

```bash
rentalMotor/
â”œâ”€â”€ API/                # Backend Web API (ASP.NET Core)
â”‚   â”œâ”€â”€ Controllers/
â”‚   â”œâ”€â”€ Models/
â”‚   â”œâ”€â”€ RentalDbContext.cs
â”‚   â””â”€â”€ Program.cs
â”œâ”€â”€ rentalMotor/        # Windows Forms (Frontend Desktop App)
â”‚   â”œâ”€â”€ WFRentalMotor.cs
â”‚   â”œâ”€â”€ WFMotor.cs
â”‚   â””â”€â”€ ApiHelper.cs
â”œâ”€â”€ README.md
```

---

## í·‘â€í²» Cara Menjalankan di Local

### í³¦ 1. Clone Repo

```bash
git clone https://github.com/username/rentalMotor.git
cd rentalMotor
```

> Gantilah `username` dengan akun GitHub kamu jika sudah di-*push* ke repo publik.

---

### âš™ï¸ 2. Konfigurasi Database

1. Install **MySQL** dan buat database `rentalmotor`.
2. Jalankan SQL berikut:

```sql
DROP DATABASE IF EXISTS rentalmotor;
CREATE DATABASE rentalmotor;

USE rentalmotor;

CREATE TABLE Motor (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NamaMotor VARCHAR(100),
    PlatMotor VARCHAR(50),
    HargaSewa DECIMAL(10, 2)
);

CREATE TABLE DataRental (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdMotor INT,
    Nama VARCHAR(100),
    NoTelpon VARCHAR(20),
    Email VARCHAR(100),
    StatusSewa INT,
    TanggalSewa DATETIME,
    LamaSewa INT,
    CONSTRAINT FK_Motor FOREIGN KEY (IdMotor) REFERENCES Motor(Id)
);
```

---

### í³¦ 3. Install NuGet Packages

Masuk ke folder `API`, lalu install NuGet berikut:

```bash
dotnet add package Microsoft.EntityFrameworkCore
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
```bash
dotnet add package Swashbuckle.AspNetCore
```

---

### í·± 4. Setup API (.NET 8 Web API)

1. Masuk ke folder `API`
2. Update koneksi DB di `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=rentalmotor;user=root;password=YOUR_PASSWORD"
}
```

3. Restore dan jalankan API:

```bash
dotnet restore
dotnet run
```

> Akses Swagger: [http://localhost:5050/swagger](http://localhost:5050/swagger)

---

### í²¾ 5. Jalankan Windows Form App

1. Buka folder `rentalMotor/` di **Visual Studio**
2. Pastikan `ApiHelper.cs` sudah mengarah ke URL API:

```csharp
client.BaseAddress = new Uri("http://localhost:5050/");
```

3. Set `WFRentalMotor.cs` sebagai Startup Form
4. Jalankan aplikasi

---

## í·ª Fitur

- CRUD Motor dan Rental
- Relasi antar tabel (Motor - DataRental)
- Validasi form input
- Data binding WinForm ke API
- Tampilan `NamaMotor` langsung di tabel Rental

---

## í¹Œ Kontribusi

Pull Request terbuka! Jangan lupa untuk `fork` dulu sebelum buat PR.


