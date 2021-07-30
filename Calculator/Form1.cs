using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.FlatAppearance.BorderSize = 1;
                btn.BackColor = Color.DeepSkyBlue;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.Blue;
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Text)
                {
                    case "0":
                        txt.Text += "0";
                        break;
                    case "1":
                        txt.Text += "1";
                        break;
                    case "2":
                        txt.Text += "2";
                        break;
                    case "3":
                        txt.Text += "3";
                        break;
                    case "4":
                        txt.Text += "4";
                        break;
                    case "5":
                        txt.Text += "5";
                        break;
                    case "6":
                        txt.Text += "6";
                        break;
                    case "7":
                        txt.Text += "7";
                        break;
                    case "8":
                        txt.Text += "8";
                        break;
                    case "9":
                        txt.Text += "9";
                        break;
                    default:
                        break;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public char? Operator { get; set; }
        public double? NumberOne { get; set; } = null;
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (txt.Text != "")
                {
                    if (!(NumberOne is null))
                    {
                        switch (Operator)
                        {
                            case '+':
                                NumberOne += Convert.ToDouble(txt.Text);
                                break;
                            case '-':
                                NumberOne -= Convert.ToDouble(txt.Text);
                                break;
                            case '*':
                                NumberOne *= Convert.ToDouble(txt.Text);
                                break;
                            case '/':
                                if (NumberOne.ToString()[0] == '0')
                                    MessageBox.Show("You Cant Divide Zero");
                                else
                                    NumberOne /= Convert.ToDouble(txt.Text);
                                break;
                        }
                        Operator = btn.Text[0];
                        txt.Text = "";
                        label1.Text = NumberOne.ToString();
                    }
                    else
                    {
                        Operator = btn.Text[0];
                        NumberOne = Convert.ToDouble(txt.Text);
                        if (NumberOne.ToString().StartsWith("0") && Operator != '-' && Operator != '+')
                        {
                            Operator = null;
                            label1.Text = "";
                            NumberOne = null;
                            MessageBox.Show("You Cannot Divide Or Multiply Zero");
                        }
                        else
                        {

                            txt.Text = "";
                            label1.Text = NumberOne.ToString();
                        }
                    }
                }
            }
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (Operator)
            {
                case '+':
                    txt.Text = (NumberOne + Convert.ToDouble(txt.Text)).ToString();
                    break;
                case '-':
                    txt.Text = (NumberOne - Convert.ToDouble(txt.Text)).ToString();
                    break;
                case '*':
                    txt.Text = (NumberOne * Convert.ToDouble(txt.Text)).ToString();
                    break;
                case '/':
                    txt.Text = (NumberOne / Convert.ToDouble(txt.Text)).ToString();
                    break;
            }
            NumberOne = null;
            Operator = null;
            label1.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            NumberOne = null;
            Operator = null;
            label1.Text = "";
            txt.Text = "";
        }
        private void btnSingleClear_Click(object sender, EventArgs e)
        {
            if (txt.Text != "")
                if (txt.Text.Contains('-') && txt.Text.Length == 2)
                    txt.Text = txt.Text.Substring(0, txt.Text.Length - 2);
                else
                    txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
        }
        public bool IsPositive { get; set; }
        private void btnPositiveNegative_Click(object sender, EventArgs e)
        {
            if (txt.Text != "")
            {
                if (txt.Text[0] == '-')
                {
                    txt.Text = txt.Text.Split('-')[1];
                }
                else
                {
                    string temp = $"-{txt.Text}";
                    txt.Text = temp;
                }
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt.Text != ""&&!txt.Text.Contains(','))
                txt.Text += ",";
        }
    }
}

