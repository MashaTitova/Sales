namespace WinFormsAppSales
{
    public partial class Form_Sales : Form
    {
        public Form_Sales()
        {
            InitializeComponent();
        }
        private void button_LoadBase_Click(object sender, EventArgs e)
        {

        }

        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите закрыть приложение?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            panel_Processing.Visible = true;
            button_Apply.Visible = true;
            button_Remove.Visible = true;
            ViewTable();
            label_Name.Text = "Обработка данных";

        }

        private void button_DataViewing_Click(object sender, EventArgs e)
        {
            label_Name.Text = "Просмотр данных";
            ViewTable();
        }
        private void button_RemakeData_Click(object sender, EventArgs e)
        {
            label_Name.Text = "Изменение данных";
            ViewTable();
        }
        private void ViewTable()
        {
            button_Return.Visible = true;
            panel_ChooseTable.Visible = true;
            button_Info.Visible = false;
            panel_StatInfo.Visible = true;
            panel_Base.Visible = true;
            flowLayoutPanel_HomeButtons.Visible = false;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            button_Return.Visible = false;
            panel_ChooseTable.Visible = false;
            button_Info.Visible = true;
            panel_StatInfo.Visible = false;
            panel_Base.Visible = false;
            flowLayoutPanel_HomeButtons.Visible = true;
            label_Name.Text = "Данные о продажах";
            if (panel_Processing.Visible == true)
            {
                panel_Processing.Visible = false;
                button_Apply.Visible = false;
                button_Remove.Visible = false;
            }
        }
    }
}
