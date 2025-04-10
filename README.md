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
CREATE DATABASE IF NOT EXISTS `rentalmotor` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `rentalmotor`;

CREATE TABLE `datarental` (
  `Id` int NOT NULL,
  `IdMotor` int NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `NoTelpon` varchar(20) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `StatusSewa` int NOT NULL,
  `TanggalSewa` date NOT NULL,
  `LamaSewa` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `motor` (
  `Id` int NOT NULL,
  `NamaMotor` varchar(100) NOT NULL,
  `PlatMotor` varchar(20) NOT NULL,
  `HargaSewa` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

ALTER TABLE `datarental`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdMotor` (`IdMotor`);
ALTER TABLE `motor`
  ADD PRIMARY KEY (`Id`);
ALTER TABLE `datarental`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
ALTER TABLE `motor`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
ALTER TABLE `datarental`
  ADD CONSTRAINT `datarental_ibfk_1` FOREIGN KEY (`IdMotor`) REFERENCES `motor` (`Id`) ON DELETE CASCADE;
COMMIT;
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


