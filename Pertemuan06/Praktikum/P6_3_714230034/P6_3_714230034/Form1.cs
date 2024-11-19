using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace P6_3_714230034
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetErrorMessages(TextBox textBox, string warningMessage, string wrongMessage, string correctMessage)
        {
            epWarning.SetError(textBox, warningMessage);
            epWrong.SetError(textBox, wrongMessage);
            epCorrect.SetError(textBox, correctMessage);
        }

        private void txtHuruf_Leave(object sender, EventArgs e)
        {
            if (Huruf.Text == "")
            {
                SetErrorMessages(Huruf, "Text Box Huruf tidak boleh kosong!", "", "");
            }
            else if (Huruf.Text.All(Char.IsLetter))
            {
                SetErrorMessages(Huruf, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(Huruf, "", "Inputan hanya boleh huruf!", "");
            }
        }

        private void txtAngka_TextChanged(object sender, EventArgs e)
        {
            if (Angka.Text == "")
            {
                SetErrorMessages(Angka, "Text Box Angka tidak boleh kosong!", "", "");
            }
            else if (Angka.Text.All(Char.IsNumber))
            {
                SetErrorMessages(Angka, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(Angka, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                SetErrorMessages(txtEmail, "Text Box Email tidak boleh kosong!", "", "");
            }
            else if (Regex.IsMatch(txtEmail.Text, @"^^[^@\s]+@[^@\s]+(\.[^@\s]+)+$"))
            {
                SetErrorMessages(txtEmail, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtEmail, "", "Format Email salah!\nContoh : a@b.c", "");
            }
        }

        private void txtAngka1_TextChanged(object sender, EventArgs e)
        {
            if (Angka1.Text == "")
            {
                SetErrorMessages(Angka1, "Textbox Angka tidak boleh kosong!", "", "");
            }
            else if (Angka1.Text.All(Char.IsNumber))
            {
                SetErrorMessages(Angka1, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(Angka1, "", "Inputan hanya boleh angka!", "");
            }

        }

        private void txtAngka2_TextChanged(object sender, EventArgs e)
        {
            if (txtAngka2.Text == "")
            {
                SetErrorMessages(txtAngka2, "Textbox Angka tidak boleh kosong!", "", "");
            }
            else if (txtAngka2.Text.All(Char.IsNumber))
            {
                SetErrorMessages(txtAngka2, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtAngka2, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtAngka1_Leave(object sender, EventArgs e)
        {
            // Check if Angka2 is filled when leaving Angka1
            if (string.IsNullOrEmpty(txtAngka2.Text))
            {
                SetErrorMessages(txtAngka2, "Textbox Angka 2 tidak boleh kosong!", "", "");
            }
        }

        private void txtAngka2_Leave(object sender, EventArgs e)
        {
            // Ensure Angka1 and Angka2 are both filled
            if (string.IsNullOrEmpty(Angka1.Text) || string.IsNullOrEmpty(txtAngka2.Text))
            {
                SetErrorMessages(txtAngka2, "Kedua textbox Angka harus diisi!", "", "");
                return;
            }

            // Convert to numbers for comparison
            if (int.TryParse(Angka1.Text, out int angka1) && int.TryParse(txtAngka2.Text, out int angka2))
            {
                if (angka1 > angka2)
                {
                    SetErrorMessages(txtAngka2, "", "", "Betul!");
                    SetErrorMessages(Angka1, "", "", "Betul!");
                }
                else
                {
                    SetErrorMessages(txtAngka2, "", "Angka 1 harus lebih besar dari Angka 2!", "");
                    SetErrorMessages(Angka1, "", "Angka 1 harus lebih besar dari Angka 2!", "");
                }
            }
            else
            {
                SetErrorMessages(txtAngka2, "", "Inputan harus berupa angka!", "");
            }
        }
    }
}