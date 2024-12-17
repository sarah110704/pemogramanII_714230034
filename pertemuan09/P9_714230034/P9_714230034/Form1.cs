using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714230034
{
    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();

        public void Tampil()
        {
            //Query DB Get MGS
            DataMahasiswa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa WHERE 1");
            //Mengubah Nama Kolom Tabel
            DataMahasiswa.Columns[0].HeaderText = "NPM";
            DataMahasiswa.Columns[0].HeaderText = "Nama";
            DataMahasiswa.Columns[0].HeaderText = "Angkatan";
            DataMahasiswa.Columns[0].HeaderText = "Alamat";
            DataMahasiswa.Columns[0].HeaderText = "Email";
            DataMahasiswa.Columns[0].HeaderText = "No HP";
        }
          
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Memanggil method Tampil
            Tampil();   
        }
    }
}
