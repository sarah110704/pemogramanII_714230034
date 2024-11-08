using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_4_714230034
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ComboBoxJenisKelamin.Items.Add("Laki-Laki");
            ComboBoxJenisKelamin.Items.Add("Perempuan");

            ButtonTampilkan.Click += ButtonTampilkan_Click;
            ButtonSelesai.Click += ButtonSelesai_Click;
        }

        private void ButtonTampilkan_Click(object sender, EventArgs e)
        {
            if (!RadioButtonJadwal1.Checked && !RadioButtonJadwal2.Checked && !RadioButtonJadwal3.Checked && !RadioButtonJadwal4.Checked)
            {
                MessageBox.Show("Silakan pilih jadwal terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            if (!CheckBoxKelas1.Checked && !CheckBoxKelas2.Checked && !CheckBoxKelas3.Checked && !CheckBoxKelas4.Checked &&
                !CheckBoxKelas5.Checked && !CheckBoxKelas6.Checked && !CheckBoxKelas7.Checked && !CheckBoxKelas8.Checked)
            {
                MessageBox.Show("Silakan pilih kelas terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> kelasList = new List<string>();
            if (CheckBoxKelas1.Checked) kelasList.Add("Sepak Bola");
            if (CheckBoxKelas2.Checked) kelasList.Add("Basket");
            if (CheckBoxKelas3.Checked) kelasList.Add("Renang");
            if (CheckBoxKelas4.Checked) kelasList.Add("Bulu Tangkis");
            if (CheckBoxKelas5.Checked) kelasList.Add("Tenis");
            if (CheckBoxKelas6.Checked) kelasList.Add("Voli");
            if (CheckBoxKelas7.Checked) kelasList.Add("Yoga");
            if (CheckBoxKelas8.Checked) kelasList.Add("Panahan");

            string kelas = string.Join(", ", kelasList);

            
            string jadwal = "";
            if (RadioButtonJadwal1.Checked) jadwal = "Senin s/d Rabu, 14.00 - 16.00";
            if (RadioButtonJadwal2.Checked) jadwal = "Selasa s/d Kamis, 14.00 - 16.00";
            if (RadioButtonJadwal3.Checked) jadwal = "Jumat s/d Minggu, 09.00 - 11.00";
            if (RadioButtonJadwal4.Checked) jadwal = "Minggu, 13.00 - 20.00";

            MessageBox.Show(
                "Nama : " + textBox1.Text +
                "\nJenis Kelamin : " + ComboBoxJenisKelamin.SelectedItem?.ToString() +
                "\nTanggal Lahir : " + dateTimePicker1.Value.ToString("dd MMMM yyyy") +
                "\nPilihan Kelas : " + kelas +
                "\nPilihan Jadwal : " + jadwal,
                "Informasi Pendaftaran",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
