using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHTMLControls
{
    public partial class Task06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_OnClick(object sender, CommandEventArgs e)
        {
            int number;
            int firstNumber;
            int secondNumber;

            if (int.TryParse(e.CommandArgument.ToString(), out number))
            {
                this.tbxResult.Text += number.ToString();
            }
            else if (e.CommandArgument.ToString() == "+")
            {
                this.firstNumber.Value = this.tbxResult.Text;
                this.operation.Value = "+";
                this.tbxResult.Text = "";
            }
            else if (e.CommandArgument.ToString() == "-")
            {
                this.firstNumber.Value = this.tbxResult.Text;
                this.operation.Value = "-";
                this.tbxResult.Text = "";
            }
            else if (e.CommandArgument.ToString() == "X")
            {
                this.firstNumber.Value = this.tbxResult.Text;
                this.operation.Value = "X";
                this.tbxResult.Text = "";
            }
            else if (e.CommandArgument.ToString() == "/")
            {
                this.firstNumber.Value = this.tbxResult.Text;
                this.operation.Value = "/";
                this.tbxResult.Text = "";
            }
            else if (e.CommandArgument.ToString() == "Clear")
            {
                this.tbxResult.Text = "";
                this.firstNumber.Value = "";
                this.operation.Value = "";
            }
            else if (e.CommandArgument.ToString() == "√")
            {
                int.TryParse(this.tbxResult.Text, out firstNumber);

                this.tbxResult.Text = Math.Sqrt(firstNumber).ToString();
            }
            else if (e.CommandArgument.ToString() == "=")
            {

                int.TryParse(this.firstNumber.Value, out firstNumber);
                int.TryParse(this.tbxResult.Text, out secondNumber);

                switch (this.operation.Value)
                {
                    case "+":
                        this.tbxResult.Text = (firstNumber + secondNumber).ToString();
                        break;
                    case "-":
                        this.tbxResult.Text = (firstNumber - secondNumber).ToString();
                        break;
                    case "X":
                        this.tbxResult.Text = (firstNumber * secondNumber).ToString();
                        break;
                    case "/":
                        this.tbxResult.Text = (firstNumber / secondNumber).ToString();
                        break;
                }
            }
        }
    }
}