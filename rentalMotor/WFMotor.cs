using Newtonsoft.Json;
using System;
using rentalMotor.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentalMotor
{
    public partial class WFMotor : Form
    {
        private int selectedId = -1;
        private readonly HttpClient client = ApiHelper.Client;
     
        public WFMotor()
        {
            InitializeComponent();
            this.Load += WFMotor_Load;
            ViewMotor.CellClick += dataGridView1_CellClick;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnReset.Click += (s, e) => ResetForm();
        }

        private async void WFMotor_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var response = await client.GetAsync("api/Motor");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Motor>>(json);
                    ViewMotor.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Gagal memuat data dari server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var motor = new Motor
            {
                NamaMotor = txtNamaMotor.Text,
                PlatMotor = txtPlatMotor.Text,
                HargaSewa = decimal.TryParse(txtHargaSewa.Text, out var harga) ? harga : 0
            };

            var content = new StringContent(JsonConvert.SerializeObject(motor), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Motor", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil ditambahkan.");
                await LoadDataAsync();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Gagal menambahkan data.");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu.");
                return;
            }

            var motor = new Motor
            {
                Id = selectedId,
                NamaMotor = txtNamaMotor.Text,
                PlatMotor = txtPlatMotor.Text,
                HargaSewa = decimal.TryParse(txtHargaSewa.Text, out var harga) ? harga : 0
            };

            var content = new StringContent(JsonConvert.SerializeObject(motor), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Motor/{selectedId}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil diupdate.");
                await LoadDataAsync();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Gagal update data.");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu.");
                return;
            }

            var response = await client.DeleteAsync($"api/Motor/{selectedId}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil dihapus.");
                await LoadDataAsync();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Gagal menghapus data.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            if (e.RowIndex >= 0)
            {
                var row = ViewMotor.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNamaMotor.Text = row.Cells["NamaMotor"].Value.ToString();
                txtPlatMotor.Text = row.Cells["PlatMotor"].Value.ToString();
                txtHargaSewa.Text = row.Cells["HargaSewa"].Value.ToString();
            }
        }

        private void ResetForm()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            selectedId = -1;
            txtNamaMotor.Text = "";
            txtPlatMotor.Text = "";
            txtHargaSewa.Text = "";
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            WFRentalMotor formRental = new WFRentalMotor();
            formRental.Show();
            this.Hide();
        }
    }
    
}
