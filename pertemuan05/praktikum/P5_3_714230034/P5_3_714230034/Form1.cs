using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_3_714230034
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rbAndroid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            // Periksa apakah checkbox 'sudah diperbaiki' dicentang
            if (cb_ya.Checked == false)
            {
                // Jika belum dicentang, tampilkan pesan
                MessageBox.Show("Belum diperbaiki", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Jika sudah dicentang, tutup aplikasi
                this.Close();
            }
        }

        private void btnTampilan_Click(object sender, EventArgs e)
        {
            string os = "";
            string status = "";
            if (rbAndroid.Checked == true)
            {
                os = "Android";
            }
            else if (rb_ios.Checked == true)
            {
                os = "iOS";
            }

            if (cb_ya.Checked == true)
            {
                status = "Ya, sudah diperbaiki";
            }
            else
            {
                status = "Belum diperbaiki";
            }

            MessageBox.Show(
                "Merk HP: " + txtMerkHP.Text + "\nOS: " + os + "\nStatus: " + status,
                "Informasi Service HP",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
