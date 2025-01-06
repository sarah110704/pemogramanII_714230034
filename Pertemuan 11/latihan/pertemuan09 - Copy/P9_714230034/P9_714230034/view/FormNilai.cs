using MySql.Data.MySqlClient;
using P9_714230034.controller;
using P9_714230034.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P9_714230034.view
{
    public partial class FormNilai : Form
    {
        Koneksi koneksi = new Koneksi();
        M_nilai m_nilai = new M_nilai();
        string id_nilai;

        public void Tampil()
        {
            DataNilai.DataSource = koneksi.ShowData("SELECT id_nilai, matkul, kategori, t_nilai.npm, nama, nilai " + "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm");
            DataNilai.Columns[0].HeaderText = "ID";
            DataNilai.Columns[1].HeaderText = "Matkul";
            DataNilai.Columns[2].HeaderText = "Kategori";
            DataNilai.Columns[3].HeaderText = "NPM";
            DataNilai.Columns[4].HeaderText = "Nama";
            DataNilai.Columns[5].HeaderText = "Nilai";
        }
        public FormNilai()
        {
            InitializeComponent();
        }

        private void FormNilai_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataMhs();
        }
        public void GetDataMhs()
        {
            // ambil data NPM dari table (t_mahasiswa) untuk mengisi data padacombobox NPM

            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_mahasiswa");
            while (reader.Read())
            {
                int npm = reader.GetInt32("npm");
                checkBoxNpm.Items.Add(npm);
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        private void DataNilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_nilai = DataNilai.Rows[e.RowIndex].Cells[0].Value.ToString();
            checkBoxMatkul.Text = DataNilai.Rows[e.RowIndex].Cells[1].Value.ToString();
            checkBoxKategori.Text = DataNilai.Rows[e.RowIndex].Cells[2].Value.ToString();
            checkBoxNpm.Text = DataNilai.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxNilai.Text = DataNilai.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            // Query search data
            DataNilai.DataSource = koneksi.ShowData(
                "SELECT id_nilai, matkul, kategori, t_nilai.npm, nama, nilai " +
                "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm " +
                "WHERE t_nilai.npm LIKE '%" + textBoxCariData.Text + "%' " +
                "OR nama LIKE '%" + textBoxCariData.Text + "%' " +
                "OR matkul LIKE '%" + textBoxCariData.Text + "%'"
            );
        }
        public void GetNamaMhs()
        {
            // Ambil data nama ketika combobox npm dipilih
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT nama FROM t_mahasiswa WHERE npm = '" + checkBoxNpm.Text + "'");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxNama.Text = reader.GetString(0);
                }
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        private void checkBoxNpm_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNamaMhs();
        }
        public void ResetForm()
        {
            checkBoxMatkul.SelectedIndex = -1;
            checkBoxKategori.SelectedIndex = -1;
            checkBoxNpm.SelectedIndex = -1;
            textBoxNilai.Text = "";
            textBoxNama.Text = "";
            textBoxCariData.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ResetForm();
            Tampil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBoxMatkul.SelectedIndex == -1 || checkBoxKategori.SelectedIndex == -1 || checkBoxNpm.SelectedIndex == -1 || textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                m_nilai.Matkul = checkBoxMatkul.Text;
                m_nilai.Kategori = checkBoxKategori.Text;
                m_nilai.Npm = checkBoxNpm.Text;
                m_nilai.Nilai = textBoxNilai.Text;

                nilai.Update(m_nilai, id_nilai);

                ResetForm();
                Tampil();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?",
    "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pesan == DialogResult.Yes)
            {
                Nilai nilai = new Nilai();
                nilai.Delete(id_nilai);

                ResetForm();
                Tampil();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBoxMatkul.SelectedIndex == -1 || checkBoxKategori.SelectedIndex == -1 || checkBoxNpm.SelectedIndex == -1 || textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Nilai nilai = new Nilai();
                m_nilai.Matkul = checkBoxMatkul.Text;
                m_nilai.Kategori = checkBoxKategori.Text;
                m_nilai.Npm = checkBoxNpm.Text;
                m_nilai.Nilai = textBoxNilai.Text;

                nilai.Update(m_nilai, id_nilai);

                ResetForm();
                Tampil();
            }

        }
    }

    internal class checkBoxNpm
    {
    }
}
