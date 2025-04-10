# RentalMotorApp 

Aplikasi CRUD sederhana untuk mengelola data **Rental Motor** menggunakan:
-  .NET 8 Web API (C#) + MySQL
-  Windows Form (C# WinForms) sebagai client
-  Komunikasi via REST API menggunakan `HttpClient`

---

##  Struktur Project

```bash
rentalMotor/
├── API/                # Backend Web API (ASP.NET Core)
│   ├── Controllers/
│   ├── Models/
│   ├── RentalDbContext.cs
│   └── Program.cs
├── rentalMotor/        # Windows Forms (Frontend Desktop App)
│   ├── WFRentalMotor.cs
│   ├── WFMotor.cs
│   └── ApiHelper.cs
├── README.md
```

---

##  Cara Menjalankan di Local

###  1. Clone Repo

```bash
git clone https://github.com/boysimbolon/rentalMotor.git
cd rentalMotor
```

---

### ⚙️ 2. Konfigurasi Database

1. Install **MySQL** dan buat database `rentalmotor`.
2. Jalankan SQL berikut:

```sql
-- Hapus database jika sudah ada
DROP DATABASE IF EXISTS `rentalmotor`;

-- Buat database baru
CREATE DATABASE `rentalmotor`;

-- Gunakan database
USE `rentalmotor`;

-- Buat tabel `motor`
CREATE TABLE `motor` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `NamaMotor` VARCHAR(100) NOT NULL,
  `PlatMotor` VARCHAR(20) NOT NULL,
  `HargaSewa` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Buat tabel `datarental`
CREATE TABLE `datarental` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IdMotor` INT NOT NULL,
  `Nama` VARCHAR(100) NOT NULL,
  `NoTelpon` VARCHAR(20) NOT NULL,
  `Email` VARCHAR(100) DEFAULT NULL,
  `StatusSewa` INT NOT NULL,
  `TanggalSewa` DATE NOT NULL,
  `LamaSewa` INT NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `idx_IdMotor` (`IdMotor`),
  CONSTRAINT `datarental_ibfk_1` FOREIGN KEY (`IdMotor`) REFERENCES `motor` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Atur nilai awal auto increment jika ingin
ALTER TABLE `motor` AUTO_INCREMENT = 3;
ALTER TABLE `datarental` AUTO_INCREMENT = 8;

```

---

### ��� 3. Install NuGet Packages

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

###  4. Setup API (.NET 8 Web API)

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

### 5. Jalankan Windows Form App

1. Buka folder `rentalMotor/` di **Visual Studio**
2. Pastikan `ApiHelper.cs` sudah mengarah ke URL API:

```csharp
client.BaseAddress = new Uri("http://localhost:5050/");
```

3. Set `WFRentalMotor.cs` sebagai Startup Form
4. Jalankan aplikasi

---

## Fitur

- CRUD Motor dan Rental
- Relasi antar tabel (Motor - DataRental)
- Validasi form input
- Data binding WinForm ke API
- Tampilan `NamaMotor` langsung di tabel Rental

---

## Kontribusi

Pull Request terbuka! Jangan lupa untuk `fork` dulu sebelum buat PR.


