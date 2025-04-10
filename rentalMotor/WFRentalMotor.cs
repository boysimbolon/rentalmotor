using Newtonsoft.Json;
using rentalMotor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentalMotor
{
    public partial class WFRentalMotor : Form
    {
        private int selectedId = -1;
        private readonly HttpClient client = ApiHelper.Client;
        private List<Motor> motors = new();

        public WFRentalMotor()
        {
            InitializeComponent();
            this.Load += WFRentalMotor_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnReset.Click += (s, e) => ResetForm();
            btnMotor.Click += btnMotor_Click;
        }

        private async void WFRentalMotor_Load(object sender, EventArgs e)
        {
            await LoadMotorsAsync();
            LoadStatusSewa();
            await LoadDataAsync();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private async Task LoadMotorsAsync()
        {
            var response = await client.GetAsync("api/Motor");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                motors = JsonConvert.DeserializeObject<List<Motor>>(json);
                cmbMotor.DataSource = motors;
                cmbMotor.DisplayMember = "NamaMotor";
                cmbMotor.ValueMember = "Id";
                cmbMotor.SelectedIndex = -1;
            }
        }

        private void LoadStatusSewa()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add(StatusSewa.Disewa.ToString());
            cmbStatus.Items.Add(StatusSewa.Selesai.ToString());
            cmbStatus.SelectedIndex = -1;
        }

        private async Task LoadDataAsync()
        {
            var response = await client.GetAsync("api/DataRental");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<DataRental>>(json);

                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Nama",
                    DataPropertyName = "Nama"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Motor",
                    DataPropertyName = "NamaMotor"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "No Telpon",
                    DataPropertyName = "NoTelpon"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Status",
                    DataPropertyName = "StatusSewa"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tanggal Sewa",
                    DataPropertyName = "TanggalSewa",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MM-yyyy" }
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Lama Sewa (hari)",
                    DataPropertyName = "LamaSewa"
                });

                dataGridView1.DataSource = list;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMotor.SelectedValue == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Pilih motor dan status sewa terlebih dahulu.");
                return;
            }

            var rental = new DataRental
            {
                IdMotor = (int)cmbMotor.SelectedValue,
                Nama = txtNama.Text,
                Email = txtEmail.Text,
                NoTelpon = txtNoHp.Text,
                LamaSewa = int.TryParse(txtLama.Text, out var lama) ? lama : 0,
                TanggalSewa = dtTanggal.Value,
                StatusSewa = (StatusSewa)Enum.Parse(typeof(StatusSewa), cmbStatus.Text)
            };

            var content = new StringContent(JsonConvert.SerializeObject(rental), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/DataRental", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil ditambahkan.");
                await LoadDataAsync();
                ResetForm();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1 || cmbMotor.SelectedValue == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Pilih data yang ingin diupdate.");
                return;
            }

            var rental = new DataRental
            {
                Id = selectedId,
                IdMotor = (int)cmbMotor.SelectedValue,
                Nama = txtNama.Text,
                Email = txtEmail.Text,
                NoTelpon = txtNoHp.Text,
                LamaSewa = int.TryParse(txtLama.Text, out var lama) ? lama : 0,
                TanggalSewa = dtTanggal.Value,
                StatusSewa = (StatusSewa)Enum.Parse(typeof(StatusSewa), cmbStatus.Text)
            };

            var content = new StringContent(JsonConvert.SerializeObject(rental), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/DataRental/{selectedId}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil diperbarui.");
                await LoadDataAsync();
                ResetForm();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            var response = await client.DeleteAsync($"api/DataRental/{selectedId}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data berhasil dihapus.");
                await LoadDataAsync();
                ResetForm();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            if (e.RowIndex >= 0)
            {
                var selected = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRental;
                if (selected == null) return;

                selectedId = selected.Id;
                txtNama.Text = selected.Nama;
                txtEmail.Text = selected.Email;
                txtNoHp.Text = selected.NoTelpon;
                txtLama.Text = selected.LamaSewa.ToString();
                dtTanggal.Value = selected.TanggalSewa;
                cmbStatus.Text = selected.StatusSewa.ToString();

                if (selected.Motor != null)
                    cmbMotor.SelectedValue = selected.Motor.Id;
                else
                    cmbMotor.SelectedIndex = -1;
            }
        }

        private void ResetForm()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            selectedId = -1;
            txtNama.Text = "";
            txtEmail.Text = "";
            txtNoHp.Text = "";
            txtLama.Text = "";
            dtTanggal.Value = DateTime.Now;
            cmbStatus.SelectedIndex = -1;
            cmbMotor.SelectedIndex = -1;
        }

        private void btnMotor_Click(object sender, EventArgs e)
        {
            WFMotor formMotor = new WFMotor();
            formMotor.Show();
            this.Hide();
        }
    }
}
