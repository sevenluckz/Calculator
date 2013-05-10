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

        int num1, num2, outp;
        Boolean cleared = true;

        private Boolean checkBox() {
            char[] foo = sumBox.Text.ToArray();
            if (foo[sumBox.TextLength-1] == '+' || foo[sumBox.TextLength-1] == '-' || foo[sumBox.TextLength-1] == '/' || foo[sumBox.TextLength-1] == '*') { return true; }
            else { return false; }
        }

        private void addChar(string num) {
            if (!cleared) { sumBox.Clear(); cleared = true; }
                if (sumBox.TextLength == 0 && (num.Equals("0"))) { }
                else { sumBox.Text = sumBox.Text + num; }
        }

        private void process(string op) {
            if (num1 == null) { num1 = Convert.ToInt32(sumBox.Text); }
            else { num2 = Convert.ToInt32(sumBox.Text); }
            sumBox.Clear();
            if (num1 != null && num2 != null) {
                sumBox.Text = (num1 + num2).ToString();
                num1 = Convert.ToInt32(null);
                num2 = Convert.ToInt32(null);
                cleared = false;
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

        private void clearBtn_Click(object sender, EventArgs e) { sumBox.Clear(); }

        private void multiplyBtn_Click(object sender, EventArgs e) { process("+"); }

        private void divideBtn_Click(object sender, EventArgs e) { addChar("/"); }

        private void subtractBtn_Click(object sender, EventArgs e) { addChar("-"); }

        private void addBtn_Click(object sender, EventArgs e) { addChar("+"); }
    }
}
