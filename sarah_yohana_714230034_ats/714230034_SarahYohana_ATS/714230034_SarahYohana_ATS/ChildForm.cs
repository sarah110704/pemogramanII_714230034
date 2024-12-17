using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _714230034_SarahYohana_ATS
{
    public partial class ChildForm : Form
    {
        private string radioButton1Laki_lakiText;

        public ChildForm()
        {
            InitializeComponent();

            this.Size = new Size(935, 271);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Form Pilihan Matkul";


            DisableMataKuliahPilihan();
        }

        private void labelProgram_Studi_Click(object sender, EventArgs e)
        {

        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

        }


        private void btnPilihMataKuliah_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(textBoxNPM.Text, @"^\d+$"))
            {
                MessageBox.Show("NPM harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else if (!Regex.IsMatch(textBoxNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh berisi huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else if (!Regex.IsMatch(textBoxTahunAkademik.Text, @"^\d{4}/\d{4}$"))
            {
                MessageBox.Show("Tahun Akademik harus dalam format nnnn/nnnn!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (string.IsNullOrEmpty(textBoxNPM.Text) ||
                string.IsNullOrEmpty(textBoxNama.Text) ||
                string.IsNullOrEmpty(textBoxAlamat.Text) ||
                string.IsNullOrEmpty(textBoxTahunAkademik.Text) ||
                string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Semua data wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            MessageBox.Show("Lengkap!", "Informasi Data Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Size = new Size(819, 549);


            DisableMataKuliahPilihan();
        }

        private void textBoxNPM_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxNPM.Text, @"^\d+$"))
            {
                epwrong.SetError(textBoxNPM, "NPM harus berupa angka!");
                epcorrect.SetError(textBoxNPM, "");
            }
            else
            {
                epcorrect.SetError(textBoxNPM, "Benar!");
                epwrong.SetError(textBoxNPM, "");
            }
        }

        private void textBoxNama_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxNama.Text, @"^[a-zA-Z\s]+$"))
            {
                epwrong.SetError(textBoxNama, "Nama hanya boleh berisi huruf!");
                epcorrect.SetError(textBoxNama, "");
            }
            else
            {
                epcorrect.SetError(textBoxNama, "Benar!");
                epwrong.SetError(textBoxNama, "");
            }
        }


        private void textBoxTahunAkademik_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxTahunAkademik.Text, @"^\d{4}/\d{4}$"))
            {
                epwrong.SetError(textBoxTahunAkademik, "Format salah! Contoh: 2024/2025");
                epcorrect.SetError(textBoxTahunAkademik, "");
            }
            else
            {
                epcorrect.SetError(textBoxTahunAkademik, "Benar!");
                epwrong.SetError(textBoxTahunAkademik, "");
            }
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {

            bool mataKuliahDipilih = groupBoxMataKuliah.Controls.OfType<CheckBox>().Any(cb => cb.Checked);
            if (!mataKuliahDipilih)
            {
                MessageBox.Show("Pilih minimal satu mata kuliah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string jenisKelamin = radioButton1Laki_laki.Checked ? radioButton1Laki_lakiText : radioButtonPerempuan.Text;

            string semester = groupBoxSemester
                .Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            string mataKuliah = string.Join(
                ", ",
                groupBoxMataKuliah.Controls.OfType<CheckBox>()
                    .Where(r => r.Checked)
                    .Select(r => r.Text)
            );

            StringBuilder informasi = new StringBuilder();
            informasi.AppendLine("NPM:" + textBoxNPM.Text);
            informasi.AppendLine("Nama:" + textBoxNama.Text);
            informasi.AppendLine("Jenis Kelamin: " + jenisKelamin);
            informasi.AppendLine("Alamat: " + textBoxAlamat.Text);
            informasi.AppendLine("Program Studi: " + comboBox1.SelectedText);
            informasi.AppendLine("Kelas: " + textBoxKelas.Text);
            informasi.AppendLine("==================================");
            informasi.AppendLine("Kurikulum: " + semester);
            informasi.AppendLine("Mata Kuliah: " + mataKuliah);

            MessageBox.Show(
                informasi.ToString(),
                "Informasi Data Submit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            textBoxNPM.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            textBoxTahunAkademik.Clear();
            comboBox1.SelectedIndex = -1;


            DisableMataKuliahPilihan();


            epwrong.Clear();
            epcorrect.Clear();
        }


        private void EnableMataKuliahPilihan()
        {
            foreach (Control control in groupBoxMataKuliah.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Enabled = true;
                }
            }
        }


        private void DisableMataKuliahPilihan()
        {
            foreach (Control control in groupBoxMataKuliah.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Enabled = false;
                    checkBox.Checked = false;
                }
            }
        }

        private void buttonPilihMataKuliah_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxNPM.Text, @"^\d+$"))
            {
                MessageBox.Show("NPM harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else if (!Regex.IsMatch(textBoxNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh berisi huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else if (!Regex.IsMatch(textBoxTahunAkademik.Text, @"^\d{4}/\d{4}$"))
            {
                MessageBox.Show("Tahun Akademik harus dalam format nnnn/nnnn!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (string.IsNullOrEmpty(textBoxNPM.Text) ||
                string.IsNullOrEmpty(textBoxNama.Text) ||
                string.IsNullOrEmpty(textBoxAlamat.Text) ||
                string.IsNullOrEmpty(textBoxTahunAkademik.Text) ||
                string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Semua data wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show("Lengkap!", "Informasi Data Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Size = new Size(935, 511);

            DisableMataKuliahPilihan();
        }

        private void textBoxNPM_TextChanged_1(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxNPM.Text, @"^\d+$"))
            {
                epwrong.SetError(textBoxNPM, "NPM harus berupa angka!");
                epcorrect.SetError(textBoxNPM, "");
            }
            else
            {
                epcorrect.SetError(textBoxNPM, "Benar!");
                epwrong.SetError(textBoxNPM, "");
            }
        }

        private void textBoxNama_TextChanged_1(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxNama.Text, @"^[a-zA-Z\s]+$"))
            {
                epwrong.SetError(textBoxNama, "Nama hanya boleh berisi huruf!");
                epcorrect.SetError(textBoxNama, "");
            }
            else
            {
                epcorrect.SetError(textBoxNama, "Benar!");
                epwrong.SetError(textBoxNama, "");
            }
        }

        private void textBoxTahunAkademik_TextChanged_1(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxTahunAkademik.Text, @"^\d{4}/\d{4}$"))
            {
                epwrong.SetError(textBoxTahunAkademik, "Format salah! Contoh: 2024/2025");
                epcorrect.SetError(textBoxTahunAkademik, "");
            }
            else
            {
                epcorrect.SetError(textBoxTahunAkademik, "Benar!");
                epwrong.SetError(textBoxTahunAkademik, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mataKuliahDipilih = groupBoxMataKuliah.Controls.OfType<CheckBox>().Any(cb => cb.Checked);
            if (!mataKuliahDipilih)
            {
                MessageBox.Show("Pilih minimal satu mata kuliah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show($"Data berhasil disimpan:\nNama: {textBoxNama.Text}\nNPM: {textBoxNPM.Text}\n...",
                            "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNPM.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            textBoxTahunAkademik.Clear();
            comboBox1.SelectedIndex = -1;
            this.Size = new Size(819, 260);

            DisableMataKuliahPilihan();


            epwrong.Clear();
            epcorrect.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DisableMataKuliahPilihan();
            EnableCheckBoxes(new[] {
                    checkBox8,
                    checkBox11,
                    checkBox1,
                    checkBox3,
                    checkBox9,
   });
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DisableMataKuliahPilihan();
            EnableCheckBoxes(new[] {
                    checkBox2,
                    checkBox5,
                    checkBox6,
                    checkBox12,
   });

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DisableMataKuliahPilihan();
            EnableCheckBoxes(new[] {
                    checkBox4,
                    checkBox7,
                    checkBox10,
   });

        }
        private void EnableCheckBoxes(CheckBox[] subjects)
        {
            foreach (CheckBox checkBox in groupBoxMataKuliah.Controls)
            {
                foreach (CheckBox subject in subjects)
                {

                    if (checkBox.Text == subject.Text)
                    {
                        checkBox.Enabled = true;
                    }

                }
            }
        }
    }
}
