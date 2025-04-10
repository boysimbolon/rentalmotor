# RentalMotorApp νΊ

Aplikasi CRUD sederhana untuk mengelola data **Rental Motor** menggunakan:
- ν΄§ .NET 8 Web API (C#) + MySQL
- ν²» Windows Form (C# WinForms) sebagai client
- ν΄ Komunikasi via REST API menggunakan `HttpClient`

---

## ν³ Struktur Project

```bash
rentalMotor/
βββ API/                # Backend Web API (ASP.NET Core)
β   βββ Controllers/
β   βββ Models/
β   βββ RentalDbContext.cs
β   βββ Program.cs
βββ rentalMotor/        # Windows Forms (Frontend Desktop App)
β   βββ WFRentalMotor.cs
β   βββ WFMotor.cs
β   βββ ApiHelper.cs
βββ README.md
```

---

## ν·βν²» Cara Menjalankan di Local

### ν³¦ 1. Clone Repo

```bash
git clone https://github.com/username/rentalMotor.git
cd rentalMotor
```

> Gantilah `username` dengan akun GitHub kamu jika sudah di-*push* ke repo publik.

---

### βοΈ 2. Konfigurasi Database

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

### ν³¦ 3. Install NuGet Packages

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

### ν·± 4. Setup API (.NET 8 Web API)

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

### ν²Ύ 5. Jalankan Windows Form App

1. Buka folder `rentalMotor/` di **Visual Studio**
2. Pastikan `ApiHelper.cs` sudah mengarah ke URL API:

```csharp
client.BaseAddress = new Uri("http://localhost:5050/");
```

3. Set `WFRentalMotor.cs` sebagai Startup Form
4. Jalankan aplikasi

---

## ν·ͺ Fitur

- CRUD Motor dan Rental
- Relasi antar tabel (Motor - DataRental)
- Validasi form input
- Data binding WinForm ke API
- Tampilan `NamaMotor` langsung di tabel Rental

---

## νΉ Kontribusi

Pull Request terbuka! Jangan lupa untuk `fork` dulu sebelum buat PR.


