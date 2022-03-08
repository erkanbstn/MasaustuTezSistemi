using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GraduateThesisSystem.Classes;
using GraduateThesisSystem.Entity;

namespace GraduateThesisSystem.Forms
{
    public partial class TypeForm : Form
    {
        public TypeForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Select * from TTip", DBConnection.con);
                DataTable t = new DataTable();
                a.Fill(t);
                gridControl1.DataSource = t;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Sunucuya Bağlanılamıyor Lütfen Bağlantınızı Kontrol Edin.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
            if (row != null)
            {
                textBox1.Text = Convert.ToInt32(row[0]).ToString();
                textBox2.Text = row[1].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TTip t = new TTip();
                t.Tip = textBox2.Text;
                DBConnection.db.TTip.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tip Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Edin", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        private void TypeForm_Load(object sender, EventArgs e)
        {
            List();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TTip.Find(id);
                DBConnection.db.TTip.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tip Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kullanılmış Bir Tipi Silmeye Çalışıyorsunuz !", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TTip.Find(id);
                x.Tip = textBox2.Text;
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Tip Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Edin", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
