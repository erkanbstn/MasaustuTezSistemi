using DevExpress.XtraEditors;
using GraduateThesisSystem.Classes;
using GraduateThesisSystem.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GraduateThesisSystem.Forms
{
    public partial class LanguageForm : Form
    {
        public LanguageForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Select * from TDil", DBConnection.con);
                DataTable t = new DataTable();
                a.Fill(t);
                gridControl1.DataSource = t;
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
                TDil t = new TDil();
                t.Dil = textBox2.Text;
                DBConnection.db.TDil.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Dil Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var x = DBConnection.db.TDil.Find(id);
                DBConnection.db.TDil.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Dil Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kullanılmış Bir Dili Silmeye Çalışıyorsunuz !", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TDil.Find(id);
                x.Dil = textBox2.Text;
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Dil Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                textBox2.Text = row[1].ToString();
            }
        }

        private void LanguageForm_Load(object sender, EventArgs e)
        {
            List();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
