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
    public partial class InstituteForm : Form
    {
        public InstituteForm()
        {
            InitializeComponent();
        }
        void List()
        {
            try
            {
                SqlDataAdapter a = new SqlDataAdapter("Exec EnstituListe", DBConnection.con);
                DataTable t = new DataTable();
                a.Fill(t);
                gridControl1.DataSource = t;

                var x = DBConnection.db.TUniversite.ToList();
                comboBox1.DataSource = x;
                comboBox1.DisplayMember = "Universite";
                comboBox1.ValueMember= "UniversiteID";

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
                TEnstitu t = new TEnstitu();
                t.Enstitu = textBox2.Text;
                t.Universite = Convert.ToInt32(comboBox1.SelectedValue);
                DBConnection.db.TEnstitu.Add(t);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Enstitü Ekleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var x = DBConnection.db.TEnstitu.Find(id);
                DBConnection.db.TEnstitu.Remove(x);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Enstitü Silme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kullanılmış Bir Enstitüyü Silmeye Çalışıyorsunuz !", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = DBConnection.db.TEnstitu.Find(id);
                x.Enstitu = textBox2.Text;
                x.Universite = Convert.ToInt32(comboBox1.SelectedValue);
                DBConnection.db.SaveChanges();
                List();
                XtraMessageBox.Show("Enstitü Güncelleme Başarılı", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                comboBox1.Text = row[2].ToString();
            }
        }

        private void InstituteForm_Load(object sender, EventArgs e)
        {
            List();
        }
    }
}
