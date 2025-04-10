using System.Net.Http;

namespace rentalMotor
{
    public static class ApiHelper
    {
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5050/") // ganti sesuai base URL API kamu
        };
    }
}
