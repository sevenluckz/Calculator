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

        /// <summary>
        /// Declares & Initialises the num1, num2, cleared, op1 and op2 variables.
        /// </summary>
        /// <remarks>
        /// Doubles num1 & num2 hold the numbers while working with them.
        /// Boolean cleared say if the form needs to be cleared when adding a number to the sumBox.
        /// Strings op1 & op2 hold the operators selected while working with them.
        /// </remarks>
        double num1 = double.MinValue, num2 = double.MinValue;
        Boolean cleared = true;
        string op1 = "", op2 = "";

        /// <summary>
        /// This adds the supplied character to the text contained in sumBox.
        /// </summary>
        /// <remarks>
        /// This checks if sumBox needs clearing. If it does then it puts num2 into num1 and puts what is currently in sumBox into num2 before clearing sumBox.
        /// It then checks if sumBox is empty and if the supplied num parameter is a period. If so it puts "0." into sumBox.
        /// If the previous didn't match then it checks if the length of the text in sumBox is greater then 0 and the num parameter is a period. If so it puts a "." into sumBox.
        /// Next, if the previous condition also didn't match, it checks to see if the sumBox text length is 1, the contents equals "0" and the num parameter doesn't equal a period. If so it clears sumBox and just adds the num parameter.
        /// If none of the conditions match then it just adds the num parameter to the end of what is currently displayed.
        /// </remarks>
        /// <param name="num">string This is the char to add to sumBox</param>
        private void addChar(string num) {
            if (!cleared) { num1 = num2; num2 = Convert.ToDouble(sumBox.Text); sumBox.Clear(); cleared = true; }
            if (sumBox.TextLength == 0 && num.Equals(".")) { sumBox.Text = "0."; }
            else if (sumBox.TextLength > 0 && sumBox.Text.Contains(".") && num.Equals(".")) { }
            else if (sumBox.TextLength == 1 && sumBox.Text.Equals("0") && !num.Equals(".")) { sumBox.Clear(); sumBox.Text = num; }
            else { sumBox.Text = sumBox.Text + num; }
        }

        /// <summary>
        /// This processes the contents of sumBox, num1 & num2 vars.
        /// </summary>
        /// <remarks>
        /// First it puts the last operator used into op2, then places the current operator into op1.
        /// Next it checks that sumBox doesn't say "Cannot Divide By Zero!" which is the text shown when a user tries to divide by zero.
        /// If this is false it runs the rest of the meathod.
        /// Next it checks if num2 is set to it's default value (which is the mimimun value a double can be set.) If so it places what is currently in sumBox into num2, after converting it to a double.
        /// If this condition is not met it checks if num2 doesn't equal the default value. If this is the case then num2 gets put into num1 and the current text in sumBox gets places into num2, after converting into a double.
        /// If none of these two conditions are met then nothing will happen as no else statement is used. This should hopefully never happen though.
        /// Then it clears sumBox.
        /// After this it checks if num1 & num2 aren't set to their default values. If this is true then it will check which operator is supplied and execute the relevant code.
        /// While checking the operator used, if it is equal to a equals sign (=) then it will check what the previous operator was and execute the relevant code for that operator.
        /// If the operator is a divide sign (/) then it will check if num2 is equal to zero. If this is the case then "Cannot Divide By Zero!" will show in sumBox.
        /// Otherwise it will execute the divide code as normal.
        /// </remarks>
        /// <param name="op">string The operator (+, -, *, / or =) to use while processing.</param>
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
                else if (op2.Equals("-")) { sumBox.Text = (num1 - num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                else if (op2.Equals("*")) { sumBox.Text = (num1 * num2).ToString(); cleared = false; num1 = double.MinValue; num2 = double.MinValue; }
                else if (op2.Equals("/"))
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

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void zeroBtn_Click(object sender, EventArgs e) { addChar("0"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void eightBtn_Click(object sender, EventArgs e) { addChar("8"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void sevenBtn_Click(object sender, EventArgs e) { addChar("7"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void nineBtn_Click(object sender, EventArgs e) { addChar("9"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void sixBtn_Click(object sender, EventArgs e) { addChar("6"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void fiveBtn_Click(object sender, EventArgs e) { addChar("5"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void fourBtn_Click(object sender, EventArgs e) { addChar("4"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void threeBtn_Click(object sender, EventArgs e) { addChar("3"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void twoBtn_Click(object sender, EventArgs e) { addChar("2"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds the relevant number to sumBox when the button is pressed.
        /// </remarks>
        private void oneBtn_Click(object sender, EventArgs e) { addChar("1"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This removes the last character added from sumBox when the backspace button is pressed. (Left Arrow)
        /// </remarks>
        private void backspcBtn_Click(object sender, EventArgs e) {
            char[] foo = sumBox.Text.ToArray();
            string bar = "";
            for (int i = 0; i < (sumBox.TextLength - 1); i++) { bar = bar + foo[i].ToString(); }
            sumBox.Text = bar;
        }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This clears sumBox and sets the num1 & num2 variables to their default.
        /// </remarks>
        private void clearBtn_Click(object sender, EventArgs e) { sumBox.Clear(); cleared = true; num1 = double.MinValue; num2 = double.MinValue; }
        
        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This runs the process meathod, passing through the relevant operator.
        /// </remarks>
        private void multiplyBtn_Click(object sender, EventArgs e) { process("*"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This runs the process meathod, passing through the relevant operator.
        /// </remarks>
        private void divideBtn_Click(object sender, EventArgs e) { process("/"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This first checks if the length of the text in sumBox is equal to zero or not equal to "-". If so it adds the "-" character to sumBox.
        /// If the first condition isn't met it then checks if the length of text in sumBox is equal to 1 and that the first char is not equal to "-". If so it will run the process meathod with the minus operator.
        /// Finally, if the first two conditions aren't met it will check on the text length is greater then 1. If so it will again run the process meathod with the minus operator.
        /// </remarks>
        private void subtractBtn_Click(object sender, EventArgs e) {
            if (sumBox.TextLength.Equals(0) || op1 != "-" ) { addChar("-"); }
            else if (sumBox.TextLength == 1 && !sumBox.Text.Equals("-")) { process("-"); }
            else if (sumBox.TextLength > 1) { process("-"); }
        }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This runs the process meathod, passing through the relevant operator.
        /// </remarks>
        private void addBtn_Click(object sender, EventArgs e) { process("+"); }

        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This runs the process meathod, passing through the relevant operator.
        /// </remarks>
        private void equalsBtn_Click(object sender, EventArgs e) { if (num2 != double.MinValue) { process("="); } }
        
        /// <summary>
        /// Event Handler code for a button press.
        /// </summary>
        /// <remarks>
        /// This adds a period to sumBox when the button is pressed.
        /// </remarks>
        private void periodBtn_Click(object sender, EventArgs e) { addChar("."); }
    }
}
