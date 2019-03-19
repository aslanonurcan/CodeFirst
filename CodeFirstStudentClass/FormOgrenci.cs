using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstStudentClass
{
    public partial class FormOgrenci : Form
    {
        OgrenciSinif ctx = new OgrenciSinif();
        public FormOgrenci()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.AdSoyad = txtAdSoyad.Text;
            ogr.SinifID = (int)cmbSinif.SelectedValue;
            ctx.Ogrenciler.Add(ogr);
            ctx.SaveChanges();
            Doldur();
        }
        private void sinifDoldur()
        {
            var slist = ctx.Siniflar.ToList();           
            cmbSinif.DisplayMember = "Aciklama";
            cmbSinif.ValueMember = "SinifID";
            cmbSinif.DataSource = slist;
        }
        private void Doldur()
        {
            dataGridView1.DataSource = ctx.Ogrenciler.Select(x => new
            {
                x.TcKimlikID,
                x.AdSoyad,
                x.sinif.Aciklama
            }).ToList();
        }
        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            sinifDoldur();
            Doldur();
        }
    }
}
