using DevExpress.XtraEditors;
using GraduateThesisSystem.Classes;
using GraduateThesisSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraduateThesisSystem.Forms
{
    public partial class UniversityForm : Form
    {
        public UniversityForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Select * from TUniversite", DBConnection.con);
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
                TUniversite t = new TUniversite();
                t.Universite = textBox2.Text;
                DBConnection.db.TUniversite.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Üniversite Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var x = DBConnection.db.TUniversite.Find(id);
                DBConnection.db.TUniversite.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Üniversite Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kullanılmış Bir Üniversiteyi Silmeye Çalışıyorsunuz !", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TUniversite.Find(id);
                x.Universite = textBox2.Text;
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Üniversite Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol Edin", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List();
        }

        private void UniversityForm_Load(object sender, EventArgs e)
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
