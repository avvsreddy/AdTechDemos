namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // draw red rectangles
            Thread t1 = new Thread(() =>
            {
                Graphics red = panel1.CreateGraphics();
                Random rnd = new Random();
                for (int i = 1; i <= 500; i++)
                {
                    int x = rnd.Next(panel1.Height);
                    int y = rnd.Next(panel1.Width);
                    red.DrawRectangle(Pens.Red, x, y, 20, 20);
                    Thread.Sleep(100);
                }
            });
            t1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                // draw blue rectangles
                Graphics blue = panel2.CreateGraphics();
                Random rnd = new Random();
                for (int i = 1; i <= 500; i++)
                {
                    int x = rnd.Next(panel2.Height);
                    int y = rnd.Next(panel2.Width);
                    blue.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}
