using DocumentFormat.OpenXml.Wordprocessing;
using FastReport;
using FastReport.Preview;
using FastReport.Table;
using PresentationLayer;
using System.Collections;
using System.Data;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WinFormsAppSales
{
    public partial class ReportForm : Form
    {
        private DataTable _data;
        private string _nameOfBase;

        public ReportForm()
        {
            InitializeComponent();
        }
        public void SetData(DataTable dt, string name)
        {
            _data = dt;
            _nameOfBase = name;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Txt_Click(object sender, EventArgs e)
        {
            TxtReportForm form = new TxtReportForm();
            form.SetData(_data, _nameOfBase);
            this.Hide();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button_Excel_Click(object sender, EventArgs e)
        {
            ExcelReportForm form = new ExcelReportForm();
            form.SetData(_data, _nameOfBase);
            this.Hide();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button_Word_Click(object sender, EventArgs e)
        {
            WordReportForm form = new WordReportForm();
            form.SetData(_data, _nameOfBase);
            this.Hide();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}