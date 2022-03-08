using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraduateThesisSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        TypeForm f;
        CounselorForm f2;
        InstituteForm f3;
        UniversityForm f4;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f == null || f.IsDisposed)
            {
                f = new TypeForm();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Focus();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new CounselorForm();
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {
                f2.Focus();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f3 == null || f3.IsDisposed)
            {
                f3 = new InstituteForm();
                f3.MdiParent = this;
                f3.Show();
            }
            else
            {
                f3.Focus();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f4 == null || f4.IsDisposed)
            {
                f4 = new UniversityForm();
                f4.MdiParent = this;
                f4.Show();
            }
            else
            {
                f4.Focus();
            }
        }
        LanguageForm f5;
        TitleForm f6;
        AuthorForm f7;
        ThesisForm f8;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f5 == null || f5.IsDisposed)
            {
                f5 = new LanguageForm();
                f5.MdiParent = this;
                f5.Show();
            }
            else
            {
                f5.Focus();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f6 == null || f6.IsDisposed)
            {
                f6 = new TitleForm();
                f6.MdiParent = this;
                f6.Show();
            }
            else
            {
                f6.Focus();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f7 == null || f7.IsDisposed)
            {
                f7 = new AuthorForm();
                f7.MdiParent = this;
                f7.Show();
            }
            else
            {
                f7.Focus();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f8 == null || f8.IsDisposed)
            {
                f8 = new ThesisForm();
                f8.MdiParent = this;
                f8.Show();
            }
            else
            {
                f8.Focus();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
