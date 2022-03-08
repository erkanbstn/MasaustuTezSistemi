using DevExpress.XtraEditors;
using GraduateThesisSystem.Classes;
using GraduateThesisSystem.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GraduateThesisSystem.Forms
{
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Select * from TYazar", DBConnection.con);
                DataTable t = new DataTable();
                a.Fill(t);
                gridControl1.DataSource = t;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void AuthorForm_Load(object sender, EventArgs e)
        {
            List();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TYazar t = new TYazar();
                t.Yazar = textBox2.Text;
                DBConnection.db.TYazar.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Yazar Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "System Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TYazar.Find(id);
                DBConnection.db.TYazar.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Yazar Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kullanılmış Bir Yazarı Silmeye Çalışıyorsunuz !", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TYazar.Find(id);
                x.Yazar = textBox2.Text;
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Yazar Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Ediniz.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List();
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
    }
}
