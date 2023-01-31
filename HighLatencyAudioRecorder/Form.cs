namespace stereoptic
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_toggle_visualizer_Click(object sender, EventArgs e)
        {
            btn_toggle_visualizer.Text = (btn_toggle_visualizer.Text == "Show") ? "Hide" : "Show";
        }

        private void btn_change_color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = Color.White;

            if (colorDialog.ShowDialog() == DialogResult.OK )
            {
                btn_change_color.BackColor = colorDialog.Color;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}