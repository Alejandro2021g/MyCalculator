using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_App
{
    public partial class Form1 : Form
    {
        bool memFlag = false;
        bool operandPerformed = false;
        string operand = "";
        double result = 0;
        double memory = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Num_Click(object sender, EventArgs e)
        {
            if(DisplayResult.Text == "0" || operandPerformed)
            {
                DisplayResult.Clear();
            }
            Button btn = (Button)sender;
           // DisplayResult.Text += btn.Text;
            operandPerformed = false;

            if (btn.Text == ".")
            {
                if (!DisplayResult.Text.Contains("."))
                    DisplayResult.Text = DisplayResult.Text + btn.Text;
            }
            else
            {
                DisplayResult.Text = DisplayResult.Text + btn.Text;
            }
        }

        private void Operand_Click(object sender, EventArgs e)
        {
            operandPerformed = true;
            Button btn = (Button)sender;
            string newOperand = btn.Text;

            lbResult.Text = lbResult.Text + " " + DisplayResult.Text + " " + newOperand;

            switch (operand)
            {
                case "+": DisplayResult.Text = (result + Double.Parse(DisplayResult.Text)).ToString(); break;
                case "-": DisplayResult.Text = (result - Double.Parse(DisplayResult.Text)).ToString(); break;
                case "X": DisplayResult.Text = (result * Double.Parse(DisplayResult.Text)).ToString(); break;
                case "/": DisplayResult.Text = (result / Double.Parse(DisplayResult.Text)).ToString(); break;
                case "Sqrt": DisplayResult.Text = (Double.Parse(DisplayResult.Text) * Double.Parse(DisplayResult.Text)).ToString();break;
                default: break;
            }

            result = Double.Parse(DisplayResult.Text);
            operand = newOperand;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            DisplayResult.Text = "0";
            lbResult.Text = "";
            result = 0;
            operand = "";
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            lbResult.Text = "";
            operandPerformed = true;

            switch (operand)
            {
                case "+": DisplayResult.Text = (result + Double.Parse(DisplayResult.Text)).ToString(); break;
                case "-": DisplayResult.Text = (result - Double.Parse(DisplayResult.Text)).ToString(); break;
                case "*": DisplayResult.Text = (result * Double.Parse(DisplayResult.Text)).ToString(); break;
                case "/": DisplayResult.Text = (result / Double.Parse(DisplayResult.Text)).ToString(); break;
                default: break;
            }

            result = Double.Parse(DisplayResult.Text);
            DisplayResult.Text = result.ToString();
            result = 0;
            operand = "";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            DisplayResult.Text = memory.ToString();
            memFlag = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            DisplayResult.Text = "0";
            memory = 0;
            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(DisplayResult.Text);
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(DisplayResult.Text);
        }
    }
}
