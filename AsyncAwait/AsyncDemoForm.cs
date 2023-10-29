using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AsyncAwait
{
    public partial class AsyncDemoForm : Form
    {

        public AsyncDemoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace("\r\n", "");
            int number = Convert.ToInt32(textBox1.Text);
            var result = Factorial(number);
            textBox1.Text = result.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace("\r\n", "");
            int number = Convert.ToInt32(textBox1.Text);
            var result =  await Task<int>.Factory.StartNew(Factorial, number);
            textBox1.Text = result.ToString();
        }

        private int Factorial(object obj)
        {
            Thread.Sleep(2000);
            int number = (int)obj;
            if (number == 0)
                return 1;
            return number * Factorial(--number);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
