using System.Security.Cryptography;

namespace Montana
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        Rectangle rec = new Rectangle(0, 0, 0, 0);

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, rec);

            int hgt = 50;
            int incr = 1;
            while (true)
            {
                if (hgt < 50)
                {
                    incr = 1;
                }
                else if (hgt > 100)
                {
                    incr = -1;
                }

                rec = new Rectangle(10, 10, 50, hgt);
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
        }

    }
}