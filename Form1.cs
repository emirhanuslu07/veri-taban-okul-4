using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows.Forms;
using WinFormsApp_EF_iliskiliTablolar.Modeller;

namespace WinFormsApp_EF_iliskiliTablolar
{
    public partial class Form1 : Form
    {
        Veritabani vt = new Veritabani();
        public Form1()
        {
            InitializeComponent();
        }






        private void Form1_Load(object sender, EventArgs e)
        {

            vt.Ogrenciler.Load();
            vt.Siniflar.Load();

            Sinif tumlist = new Sinif();

            tumlist.Sube = "tüm ögrenci";
            tumlist.Seviye = 0;
            tumlist.Id = 0;
            comboBox_SnfSec.Items.Add(tumlist);






            //Combobox'ý dolduruyorum            
            comboBox_SnfSec.DataSource = vt.Siniflar.Local.ToBindingList();
            comboBox_SnfSec.DisplayMember = "SinifAd";
            //Ayarlardaki 
            comboBox_Ayar_Snf.DataSource = vt.Siniflar.Local.ToBindingList();
            comboBox_Ayar_Snf.DisplayMember = "SinifAd";

            //datagridi dolduruyorum


            dataGridView1.DataSource = vt.Siniflar.Local.ToBindingList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            dataGridView_OgrListe.DataSource = vt.Ogrenciler.Local.ToBindingList();

            dataGridView_OgrListe.Columns[0].Visible = false;
            dataGridView_OgrListe.Columns[4].Visible = false;

            //özel combobox sutunu oluþturuyorum
            DataGridViewComboBoxColumn _ozelColumnCombobox = new DataGridViewComboBoxColumn();

            foreach (var item in vt.Siniflar.Local)
            {
                _ozelColumnCombobox.Items.Add(item);
            }
            _ozelColumnCombobox.DataPropertyName = "Sinif";
            _ozelColumnCombobox.DisplayMember = "SinifAd";
            _ozelColumnCombobox.ValueMember = "Kendisi";

            dataGridView_OgrListe.Columns.Add(_ozelColumnCombobox);

        }

        private void dataGridView_OgrListe_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            vt.SaveChanges();
        }

        private void comboBox_SnfSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            vt.Ogrenciler.Load();
            Sinif secilensinf = (Sinif)comboBox_SnfSec.SelectedItem;
            if (comboBox_SnfSec.SelectedIndex != 0)
                dataGridView_OgrListe.DataSource = vt.Ogrenciler.Local.Where(x => x.Sinif.SinifAd == secilensinf.SinifAd).ToList();
            else
                dataGridView_OgrListe.DataSource = vt.Ogrenciler.Local.ToBindingList();
        }

        private void button_Ogr_Kaydet_Click(object sender, EventArgs e)
        {

            Ogrenci urun = new Ogrenci();

            urun.Ad = textBox_Ogr_Ad.Text;
            urun.Soyad = textBox_Ogr_Soyad.Text;
            urun.Okulno = Convert.ToInt32(textBox_Ogr_Okulno.Text);
            urun.Sinif = (Sinif)comboBox_Ayar_Snf.SelectedItem;
            vt.Ogrenciler.Add(urun);
            vt.SaveChanges();











        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Ayar_Snf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_OgrListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selecdIndex = dataGridView_OgrListe.CurrentCell.RowIndex;
            if (selecdIndex > -1)
                dataGridView_OgrListe.Rows.RemoveAt(selecdIndex);
            dataGridView_OgrListe.Refresh();
            vt.SaveChanges();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            int selecdIndex = dataGridView_OgrListe.CurrentCell.RowIndex;
            if (selecdIndex > -1)
                dataGridView_OgrListe.Rows.RemoveAt(selecdIndex);
            dataGridView_OgrListe.Refresh();

            vt.SaveChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl_ana.SelectedIndex = 1;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Sinif ekle = new Sinif();

            ekle.Seviye = Convert.ToInt32(textBox1.Text); ;
            ekle.Sube = textBox2.Text;



            vt.Siniflar.Add(ekle);
            vt.SaveChanges();







        }

        private void tabPage_Ayar_Snf_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl_Ayarlar.SelectedIndex = 1;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            tabControl_Ayarlar.SelectedIndex = 1;
        }

        private void tabControl_ana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selecdIndex = dataGridView1.CurrentCell.RowIndex;
            if (selecdIndex > -1)
                dataGridView1.Rows.RemoveAt(selecdIndex);
            dataGridView1.Refresh();
            vt.SaveChanges();
        }

        private void tabPage_Ayar_Snf_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl_Ayarlar.SelectedIndex = 1;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}        