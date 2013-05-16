using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        double num1 = double.MinValue, num2 = double.MinValue;
        Boolean cleared = true;
        string op1 = "", op2 = "";

        private Boolean checkBox() {
            char[] foo = sumBox.Text.ToArray();
            if (foo[sumBox.TextLength-1] == '+' || foo[sumBox.TextLength-1] == '-' || foo[sumBox.TextLength-1] == '/' || foo[sumBox.TextLength-1] == '*') { return true; }
            else { return false; }
        }

        private void addChar(string num) {
            if (!cleared) { sumBox.Clear(); cleared = true; }
                if (sumBox.TextLength == 0 && num.Equals(".")) { sumBox.Text = "0."; }
                else if (sumBox.TextLength > 0 && sumBox.Text.Contains(".") && num.Equals(".")) { }
                else if (sumBox.TextLength == 1 && sumBox.Text.Equals("0") && !num.Equals(".")) { sumBox.Clear(); sumBox.Text = num; }
                else { sumBox.Text = sumBox.Text + num; }
        }

        private void process(string op) {
            op2 = op1;
            op1 = op;
            if (sumBox.Text.Equals("Cannot Divide By Zero!")) {  }
            else {
            if (num2 == double.MinValue) { num2 = Convert.ToDouble(sumBox.Text); }
            else if (num2 != double.MinValue) { num1 = num2; num2 = Convert.ToDouble(sumBox.Text); }
            sumBox.Clear();
            if (num1 != double.MinValue && num2 != double.MinValue)
            {
                if (op2.Equals("+")) { sumBox.Text = (num1 + num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                else if (op1.Equals("-")) { sumBox.Text = (num1 - num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                else if (op1.Equals("*")) { sumBox.Text = (num1 * num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                else if (op1.Equals("/"))
                {
                    if (num2.ToString().Equals("0")) { sumBox.Text = "Cannot Divide By Zero!"; cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                    else { sumBox.Text = (num1 / num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                }
                else if (op1.Equals("="))
                {
                    if (op2.Equals("+")) { sumBox.Text = (num1 + num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                    else if (op2.Equals("-")) { sumBox.Text = (num1 - num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                    else if (op2.Equals("*")) { sumBox.Text = (num1 * num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                    else if (op2.Equals("/"))
                    {
                        if (num2.ToString().Equals("0")) { sumBox.Text = "Cannot Divide By Zero!"; cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                        else { sumBox.Text = (num1 / num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                    }
                }
            }
        }
        }

        private void zeroBtn_Click(object sender, EventArgs e) { addChar("0"); }

        private void eightBtn_Click(object sender, EventArgs e) { addChar("8"); }

        private void sevenBtn_Click(object sender, EventArgs e) { addChar("7"); }

        private void nineBtn_Click(object sender, EventArgs e) { addChar("9"); }

        private void sixBtn_Click(object sender, EventArgs e) { addChar("6"); }

        private void fiveBtn_Click(object sender, EventArgs e) { addChar("5"); }

        private void fourBtn_Click(object sender, EventArgs e) { addChar("4"); }

        private void threeBtn_Click(object sender, EventArgs e) { addChar("3"); }

        private void twoBtn_Click(object sender, EventArgs e) { addChar("2"); }

        private void oneBtn_Click(object sender, EventArgs e) { addChar("1"); }

        private void backspcBtn_Click(object sender, EventArgs e) {
            char[] foo = sumBox.Text.ToArray();
            string bar = "";
            for (int i = 0; i < (sumBox.TextLength - 1); i++) { bar = bar + foo[i].ToString(); }
            sumBox.Text = bar;
        }

        private void clearBtn_Click(object sender, EventArgs e) { sumBox.Clear(); cleared = true; num1 = double.MinValue; num2 = double.MinValue; }

        private void multiplyBtn_Click(object sender, EventArgs e) { process("*"); }

        private void divideBtn_Click(object sender, EventArgs e) { process("/"); }

        private void subtractBtn_Click(object sender, EventArgs e) {
            if (sumBox.TextLength.Equals(0)) { addChar("-"); }
            else if (sumBox.TextLength == 1 && !sumBox.Text.Equals("-")) { process("-"); }
            else if (sumBox.TextLength > 1) { process("-"); }
        }

        private void addBtn_Click(object sender, EventArgs e) { process("+"); }

        private void equalsBtn_Click(object sender, EventArgs e) { if (num2 != double.MinValue) { process("="); } }

        private void periodBtn_Click(object sender, EventArgs e) { addChar("."); }
    }
}
