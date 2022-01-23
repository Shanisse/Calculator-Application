using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Application
{
    public partial class Calculator : Form
    {
        Double resultVal = 0;
        String operationPerform = "";
        bool aOperationPerform = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if((textBox_Result.Text == "0") || (aOperationPerform))
                textBox_Result.Clear();

            aOperationPerform = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            } else
            textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultVal != 0)
            {
                button20.PerformClick();
                operationPerform = button.Text;
                labelOperationValue.Text = resultVal + "  " + operationPerform;
                aOperationPerform = true;
            }
            else
            {
                operationPerform = button.Text;
                resultVal = Double.Parse(textBox_Result.Text);
                labelOperationValue.Text = resultVal + "  " + operationPerform;
                aOperationPerform = true;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultVal = 0;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            switch(operationPerform)
            {
                case "+":
                    textBox_Result.Text = (resultVal + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultVal - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "X":
                    textBox_Result.Text = (resultVal * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultVal / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "x^y":
                    textBox_Result.Text = Math.Pow(Double.Parse(textBox_Result.Text),resultVal).ToString();
                    break;
                default:
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(textBox_Result.Text.Length > 0)
            {
                textBox_Result.Text = textBox_Result.Text.Remove(textBox_Result.Text.Length - 1, 1);
            }
            
            if(textBox_Result.Text == "")
            {
                textBox_Result.Text = "0";
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox_Result.Text);
            textBox_Result.Text = Convert.ToString(-1 * x);
        }

        private void btn1overX_Click(object sender, EventArgs e)
        {
            Double x;
            x = Convert.ToDouble(1.0 / Convert.ToDouble(textBox_Result.Text));
            textBox_Result.Text = System.Convert.ToString(x);
        }

       private void btnXraise2_Click(object sender, EventArgs e)
        {
            Double x;
            x = Convert.ToDouble(textBox_Result.Text) * Convert.ToDouble(textBox_Result.Text);
            textBox_Result.Text = System.Convert.ToString(x);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sr = Double.Parse(textBox_Result.Text);
            textBox_Result.Text = System.Convert.ToString(textBox_Result.Text);
            sr = Math.Sqrt(sr);
            textBox_Result.Text = System.Convert.ToString(sr);
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
