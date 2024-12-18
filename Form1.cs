using static System.Net.Mime.MediaTypeNames;

namespace CalculatorClassic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxBottomEntry.Text = "0";
        }

        string textTopDisplay;
        decimal firstNumInput;
        decimal secondNumInput;
        decimal resultNum;
        string modePrevOperation = "";
        string modeCurrentOperation = "";
        bool isDecimalPointPlaced = false;
        bool isNegativeSignPlaced = false;
        bool isEqualDisplayed = false;
        bool isTextBoxEntrytoClear = false;
        bool isToReInitialize = false;

        private void Calculator_Init()
        {
            textBoxBottomEntry.Text = "0";
            textBoxTopDisplay.Text = "";
            textTopDisplay = "";
            firstNumInput = 0;
            secondNumInput = 0;
            resultNum = 0;
            modePrevOperation = "";
            modeCurrentOperation = "";
            isDecimalPointPlaced = false;
            isNegativeSignPlaced = false;
            isEqualDisplayed = false;
            isTextBoxEntrytoClear = false;
            isToReInitialize = false;
        }

        private void textBoxBottomEntry_Init()
        {
            if (isToReInitialize == true)
            {
                Calculator_Init();
            }

            if (isTextBoxEntrytoClear == true)
            {
                textBoxBottomEntry.Text = "";
                isTextBoxEntrytoClear = false;
            }

            if (textBoxBottomEntry.Text == "0")
            {
                textBoxBottomEntry.Text = "";
            }
            else if (textBoxBottomEntry.Text == "-0")
            {
                textBoxBottomEntry.Text = "-";
            } 
            
        }
        
        private void onOperationSelected()
        {
            isToReInitialize = false;
            if (modePrevOperation == "")
            {
                firstNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = firstNumInput + " " + modeCurrentOperation;
            }
            else if (modeCurrentOperation != modePrevOperation)
            {
                textTopDisplay = firstNumInput + " " + modeCurrentOperation;
            }    
            else if (modeCurrentOperation == modePrevOperation)
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                doCalculation();
                textTopDisplay = resultNum.ToString() + " " + modeCurrentOperation;
                firstNumInput = resultNum;
                //textTopDisplay = "test";
            }

            textBoxTopDisplay.Text = textTopDisplay;
            isEqualDisplayed = false;
            isTextBoxEntrytoClear = true;
        }

        private void doCalculation()
        {
            // MessageBox.Show(firstNumInput.ToString());
            // MessageBox.Show(secondNumInput.ToString());
            if (modeCurrentOperation == "+")
            {
                resultNum = firstNumInput + secondNumInput;
                
            }
            else if (modeCurrentOperation == "-")
            {
                resultNum = firstNumInput - secondNumInput;
            }
            else if (modeCurrentOperation == "*")
            {
                resultNum = firstNumInput * secondNumInput;
            }
            else if (modeCurrentOperation == "/")
            {
                resultNum = firstNumInput / secondNumInput;
            }
            // MessageBox.Show(resultNum.ToString());
        }        

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "0";
        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "1";
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "2";
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "3";
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "4";
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "5";
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "6";
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "7";
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "8";
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            textBoxBottomEntry_Init();
            textBoxBottomEntry.Text = textBoxBottomEntry.Text + "9";
        }

        private void buttonDecimalPoint_Click(object sender, EventArgs e)
        {
            if (textBoxBottomEntry.Text.Contains("."))
            {
                isDecimalPointPlaced = true;
            }
            else
            {
                isDecimalPointPlaced = false;
            }

            if (isDecimalPointPlaced == false )
            {
                textBoxBottomEntry.Text = textBoxBottomEntry.Text + ".";
                isDecimalPointPlaced = true;
            }
            
        }

        private void buttonPosNeg_Click(object sender, EventArgs e)
        {
            if (textBoxBottomEntry.Text.Contains("-"))
            {
                isNegativeSignPlaced = true;
            }
            else
            {
                isNegativeSignPlaced = false;
            }

            if (isNegativeSignPlaced == false)
            {
                textBoxBottomEntry.Text = "-" + textBoxBottomEntry.Text;
                isNegativeSignPlaced = true;
            }
            else if (isNegativeSignPlaced == true)
            {
                textBoxBottomEntry.Text = textBoxBottomEntry.Text.Replace("-", "");
                isNegativeSignPlaced = false;
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (modePrevOperation == "" && isEqualDisplayed == false)
            {
                textTopDisplay = textBoxBottomEntry.Text + " =";
                return;
            }

            if (isEqualDisplayed == false)
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
            }
            else if (isEqualDisplayed == true)
            {

            }

            doCalculation();
            textTopDisplay = firstNumInput.ToString() + " " + modeCurrentOperation + " " + secondNumInput.ToString() + " =";
            textBoxTopDisplay.Text = textTopDisplay;
            textBoxBottomEntry.Text = resultNum.ToString();
            firstNumInput = resultNum;
            isEqualDisplayed = true;
            modePrevOperation = "";
            isToReInitialize = true;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            modeCurrentOperation = "+";
            onOperationSelected();
            modePrevOperation = "+";
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            modeCurrentOperation = "-";
            onOperationSelected();
            modePrevOperation = "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            modeCurrentOperation = "*";
            onOperationSelected();
            modePrevOperation = "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            modeCurrentOperation = "/";
            onOperationSelected();
            modePrevOperation = "/";
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            double numDoubleTempVar;

            if (modePrevOperation == "")
            {
                firstNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = "sqrt(" + firstNumInput + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                numDoubleTempVar = Convert.ToDouble(firstNumInput);
                numDoubleTempVar = Math.Sqrt(numDoubleTempVar);
                resultNum = Convert.ToDecimal(numDoubleTempVar);
                textBoxBottomEntry.Text = resultNum.ToString();
                isTextBoxEntrytoClear = true;
            }
            else
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = firstNumInput.ToString() + " " + modeCurrentOperation + " sqrt(" + secondNumInput.ToString() + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                numDoubleTempVar = Convert.ToDouble(secondNumInput);
                numDoubleTempVar = Math.Sqrt(numDoubleTempVar);
                secondNumInput = Convert.ToDecimal(numDoubleTempVar);
                textBoxBottomEntry.Text = secondNumInput.ToString();
            }
        }

        private void buttonExponentTwo_Click(object sender, EventArgs e)
        {
            if (modePrevOperation == "")
            {
                firstNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = "sqr(" + firstNumInput + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                resultNum = firstNumInput * firstNumInput;
                textBoxBottomEntry.Text = resultNum.ToString();
                isTextBoxEntrytoClear = true;
            }
            else
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = firstNumInput.ToString() + " " + modeCurrentOperation + " sqr(" + secondNumInput.ToString() + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                secondNumInput = secondNumInput * secondNumInput;
                textBoxBottomEntry.Text = secondNumInput.ToString();
            }    
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            if (modePrevOperation == "")
            {
                firstNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = "1/(" + firstNumInput + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                resultNum = 1 / firstNumInput;
                textBoxBottomEntry.Text = resultNum.ToString();
                isTextBoxEntrytoClear = true;
            }
            else
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = firstNumInput.ToString() + " " + modeCurrentOperation + " 1/(" + secondNumInput.ToString() + ")";
                textBoxTopDisplay.Text = textTopDisplay;
                secondNumInput = 1 / secondNumInput;
                textBoxBottomEntry.Text = secondNumInput.ToString();
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (modePrevOperation == "" && isEqualDisplayed == false)
            {
                Calculator_Init();
            }
            else
            {
                secondNumInput = Convert.ToDecimal(textBoxBottomEntry.Text);
                textTopDisplay = firstNumInput.ToString() + " " + modeCurrentOperation + " (" + secondNumInput.ToString() + ")%";
                textBoxTopDisplay.Text = textTopDisplay;
                secondNumInput = firstNumInput * secondNumInput / 100;
                textBoxBottomEntry.Text = secondNumInput.ToString();
            }
        }

        private void buttonCancelAll_Click(object sender, EventArgs e)
        {
            Calculator_Init();
        }

        private void buttonCancelEntry_Click(object sender, EventArgs e)
        {
            if (isToReInitialize == true)
            {
                Calculator_Init();
            }

            textBoxBottomEntry.Text = "0";
            
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (isToReInitialize == true)
            {
                textBoxTopDisplay.Text = "";
                textTopDisplay = "";
                firstNumInput = 0;
                secondNumInput = 0;
                resultNum = 0;
                modePrevOperation = "";
                modeCurrentOperation = "";
                isEqualDisplayed = false;
                isTextBoxEntrytoClear = false;
                isToReInitialize = false;
                return;
            }

            int textEntryMinLength = 1;

            if (textBoxBottomEntry.Text.Contains("-"))
            {
                isNegativeSignPlaced = true;
            }
            else
            {
                isNegativeSignPlaced = false;
            }

            if (isNegativeSignPlaced == true)
            {
                textEntryMinLength = 2;
            }

            if (textBoxBottomEntry.Text.Length > textEntryMinLength)
            {
                textBoxBottomEntry.Text = textBoxBottomEntry.Text.Remove(textBoxBottomEntry.Text.Length - 1);
            }
            else
            {
                textBoxBottomEntry.Text = "0";
                             
            }
        }
    }
}
