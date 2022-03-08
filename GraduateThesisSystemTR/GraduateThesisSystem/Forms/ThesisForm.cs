using DevExpress.XtraEditors;
using GraduateThesisSystem.Classes;
using GraduateThesisSystem.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GraduateThesisSystem.Forms
{
    public partial class ThesisForm : Form
    {
        public ThesisForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Execute TezListesi", DBConnection.con);
                DataTable t = new DataTable();
                a.Fill(t);
                gridControl1.DataSource = t;


                // ALL UNIVERSITIES
                var x = DBConnection.db.TUniversite.ToList();
                cmbUniversity.DataSource = x;
                cmbUniversity.DisplayMember = "Universite";
                cmbUniversity.ValueMember = "UniversiteID";

                // ALL INSTITUTES
                var x2 = DBConnection.db.TEnstitu.ToList();
                cmbInstitute.DataSource = x2;
                cmbInstitute.DisplayMember = "Enstitu";
                cmbInstitute.ValueMember = "EnstituID";

                // ALL TİTLES
                var x3 = DBConnection.db.TBaslik.ToList();
                cmbTitle.DataSource = x3;
                cmbTitle.DisplayMember = "Baslik";
                cmbTitle.ValueMember = "BaslikID";


                // ALL AUTHORS
                var x4 = DBConnection.db.TYazar.ToList();
                cmbAuthor.DataSource = x4;
                cmbAuthor.DisplayMember = "Yazar";
                cmbAuthor.ValueMember = "YazarID";


                // ALL TYPES
                var x5 = DBConnection.db.TTip.ToList();
                cmbType.DataSource = x5;
                cmbType.DisplayMember = "Tip";
                cmbType.ValueMember = "TipID";


                // ALL COUNSELORS
                var x6 = DBConnection.db.TDanisman.ToList();
                cmbCounselor.DataSource = x6;
                cmbCounselor.DisplayMember = "Danisman";
                cmbCounselor.ValueMember = "DanismanID";


                // ALL LANGUAGES
                var x7 = DBConnection.db.TDil.ToList();
                cmbLanguage.DataSource = x7;
                cmbLanguage.DisplayMember = "Dil";
                cmbLanguage.ValueMember = "DilID";

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TTez t = new TTez();
                t.Enstitu = Convert.ToInt32(cmbInstitute.SelectedValue);
                t.Universite = Convert.ToInt32(cmbUniversity.SelectedValue);
                t.Baslik = Convert.ToInt32(cmbTitle.SelectedValue);
                t.Yazar = Convert.ToInt32(cmbAuthor.SelectedValue);
                t.Danisman = Convert.ToInt32(cmbCounselor.SelectedValue);
                t.Tip = Convert.ToInt32(cmbType.SelectedValue);
                t.Tez = richTextBox1.Text;
                t.SayfaSayisi = txtPages.Text;
                t.Dil = Convert.ToInt32(cmbLanguage.SelectedValue);
                t.Yil = txtYear.Text;
                t.TeslimTarih = maskedTextBox1.Text;
                DBConnection.db.TTez.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tez Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Edin", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TTez.Find(id);
                DBConnection.db.TTez.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tez Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("İlişkili Değerleri Silmeye Çalışıyorsunuz Lütfen Önce İlişkilerinizi Kaldırın.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var t = DBConnection.db.TTez.Find(id);
                t.Enstitu = Convert.ToInt32(cmbInstitute.SelectedValue);
                t.Universite = Convert.ToInt32(cmbUniversity.SelectedValue);
                t.Baslik = Convert.ToInt32(cmbTitle.SelectedValue);
                t.Yazar = Convert.ToInt32(cmbAuthor.SelectedValue);
                t.Danisman = Convert.ToInt32(cmbCounselor.SelectedValue);
                t.Tip = Convert.ToInt32(cmbType.SelectedValue);
                t.Tez = richTextBox1.Text;
                t.SayfaSayisi = txtPages.Text;
                t.Dil = Convert.ToInt32(cmbLanguage.SelectedValue);
                t.Yil = txtYear.Text;
                t.TeslimTarih = maskedTextBox1.Text;
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tez Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Edin", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
            if (row != null)
            {
                textBox1.Text = row[0].ToString();
                cmbTitle.Text = row[1].ToString();
                richTextBox1.Text = row[2].ToString();
                cmbAuthor.Text = row[3].ToString();
                txtYear.Text = row[4].ToString();
                cmbType.Text = row[5].ToString();
                cmbUniversity.Text = row[6].ToString();
                cmbInstitute.Text = row[7].ToString();
                txtPages.Text = row[8].ToString();
                cmbLanguage.Text = row[9].ToString();
                maskedTextBox1.Text = row[10].ToString();
                cmbCounselor.Text = row[11].ToString();
            }
        }

        private void ThesisForm_Load(object sender, EventArgs e)
        {
            List();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
