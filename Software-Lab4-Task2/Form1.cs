namespace Software_Lab4_Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double CalculateEquation1(double X, double Y, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                double term;
                if (i % 2 == 1)
                {
                    if (i == 1)
                    {
                        term = -1.0 / i;
                    }
                    else
                    {
                        term = -Math.Pow(X, i - 1) / i;
                    }
                }
                else
                {
                    term = Math.Pow(Y, i - 1) / i;
                }
                result += term;
            }
            return result;
        }

        private double CalculateEquation2(int N, int R, double h, double c)
        {
            double result = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= R; j++)
                {
                    result += (j * j + h * i) / (Math.Pow(i, j) + c * j);
                }
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxX.Text) || string.IsNullOrWhiteSpace(textBoxY.Text) ||
                    string.IsNullOrWhiteSpace(textBoxNn.Text) || string.IsNullOrWhiteSpace(textBoxH.Text) ||
                    string.IsNullOrWhiteSpace(textBoxC.Text) || comboBoxN.SelectedItem == null ||
                    comboBoxR.SelectedItem == null)
                {
                    throw new ArgumentException("Все поля должны быть заполнены");
                }

                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    throw new ArgumentException("Выберите уравнение для расчета");
                }

                double X = Convert.ToDouble(textBoxX.Text);
                double Y = Convert.ToDouble(textBoxY.Text);
                int n = Convert.ToInt32(textBoxNn.Text);
                int N = Convert.ToInt32(comboBoxN.SelectedItem);
                int R = Convert.ToInt32(comboBoxR.SelectedItem);
                double h = Convert.ToDouble(textBoxH.Text);
                double c = Convert.ToDouble(textBoxC.Text);
                double Z = 0;

                if (radioButton1.Checked)
                {
                    Z = CalculateEquation1(X, Y, n);
                }
                else if (radioButton2.Checked)
                {
                    Z = CalculateEquation2(N, R, h, c);
                }
                textBoxZ.Text = Z.ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата данных. Проверьте правильность введенных числовых значений.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
