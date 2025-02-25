﻿using P12_714230034.controller;
using P12_714230034.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P12_714230034.view
{
    public partial class FormBarang : Form
    {
        Koneksi koneksi = new Koneksi();
        M_barang m_barang = new M_barang();
        Barang barang = new Barang();

        public FormBarang()
        {
            InitializeComponent();
        }

        public void Tampil()
        {
            dataBarang.DataSource = koneksi.ShowData("SELECT * FROM t_barang");
            dataBarang.Columns[0].HeaderText = "ID";
            dataBarang.Columns[1].HeaderText = "Nama Barang";
            dataBarang.Columns[2].HeaderText = "Harga";
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxBarang.Text == "" || textBoxHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_barang.Nama_barang = textBoxBarang.Text;
                m_barang.Harga = textBoxHarga.Text;
                barang.Insert(m_barang);
                Reset();
                Tampil();
            }
        }

        public void Reset()
        {
            textBoxBarang.Text = "";
            textBoxHarga.Text = "";
            textBoxID.Text = "";
        }

        private void dataBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxBarang.Text = dataBarang.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxHarga.Text = dataBarang.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxID.Text = dataBarang.Rows[e.RowIndex].Cells[0].Value.ToString(); // Add this line to get the ID
        }

        private void buttonRubah_Click(object sender, EventArgs e)
        {
            if (textBoxBarang.Text == "" || textBoxHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_barang.Nama_barang = textBoxBarang.Text;
                m_barang.Harga = textBoxHarga.Text;
                barang.Update(m_barang, textBoxID.Text);
                Reset();
                Tampil();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            Tampil();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                barang.Delete(textBoxID.Text);
                Reset();
                Tampil();
            }
        }

        private void textBoxPencarian_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM t_barang WHERE id_barang LIKE '%" + textBoxPencarian.Text + "%' OR nama_barang LIKE '%" + textBoxPencarian.Text + "%' OR harga LIKE '%" + textBoxPencarian.Text + "%'";
            dataBarang.DataSource = koneksi.ShowData(query);
        }
    }
}
