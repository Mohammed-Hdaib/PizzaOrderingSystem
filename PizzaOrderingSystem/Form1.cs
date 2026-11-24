using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            CalculateTotalPrice();
            
            if (rbSamll.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if(rbMedium.Checked)
            {
                lblSize.Text = "Meduim";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        void UpdateCrustType()
        {
            CalculateTotalPrice();

            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin";
                return;

            }

            if(rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick";
                return;
            }
        }

        void UpdateToppings()
        {
            CalculateTotalPrice();

            string Toppings = "";

            if (chkExtraChees.Checked)
            {
                Toppings += "Extra Cheese";
            }

            if (chkGreenPeppers.Checked)
            {
                Toppings += ",GreenPeppers";
            }

            if (chkMushrooms.Checked)
            {
                Toppings += ",Mushrooms";
            }

            if (chkOlives.Checked)
            {
                Toppings += ",Olives";
            }

            if (chkOnion.Checked)
            {
                Toppings += ",Onion";
            }

            if (chkTomatos.Checked)
            {
                Toppings += ",Tomatos";
            }


            if (Toppings.StartsWith(","))
            {
                Toppings = Toppings.Substring(1, Toppings.Length - 1);
            }

            else if (Toppings == "")
            {
                Toppings = "No Toppings";
            }

            lblToppings.Text = Toppings;

        }

        void UpdateEatPlace()
        {
            if(rbEatIn.Checked)
            {
                lblWhereToEat.Text = "EatIn";
            }

            else
            {
                lblWhereToEat.Text = "Take Out";
            }
        }

        float GetSelectedSizePrice()
        { 

            if (rbSamll.Checked)
            {
                return Convert.ToSingle(rbSamll.Tag);
            }

            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }

            else 
            {
                return Convert.ToSingle(rbLarge.Tag);
            }

        }

        float GetSelectedCrustType()
        {
            if (rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);
                
            }

            else 
            {
                return Convert.ToSingle(rbThickCrust.Tag);
            }



        }

        float CalculateSelectedToppingsPrice()
        {
            float TotalPrice = 0;

            if(chkExtraChees.Checked)
            {
                TotalPrice += Convert.ToSingle(chkExtraChees.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                TotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }

            if (chkMushrooms.Checked)
            {
                TotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }

            if (chkOlives.Checked)
            {
                TotalPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkOnion.Checked)
            {
                TotalPrice += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkTomatos.Checked)
            {
                TotalPrice += Convert.ToSingle(chkTomatos.Tag);
            }


            return TotalPrice;


        }

        void CalculateTotalPrice()
        {
            lblTotalPrice.Text = "$" +  ((CalculateSelectedToppingsPrice() + GetSelectedSizePrice() + GetSelectedCrustType()) * Convert.ToSingle(numericUpDown1.Value));
        }

        private void rbSamll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatos_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK )
            {
                if(MessageBox.Show("Order Placed Successfully", "Success") == DialogResult.OK)
                {
                    ConfirmOrder();
                }

            }    
        }



        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEatPlace();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEatPlace();
        }

        void ConfirmOrder()
        {
            gbSize.Enabled = false;
            gbToppings.Enabled = false;
            gbCrustType.Enabled = false;
            gbWhereToEat.Enabled = false;
            btnOrderPizza.Enabled = false;
        }

        void ResetOrder()
        {
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            rbMedium.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            chkExtraChees.Checked = false;
            chkGreenPeppers.Checked = false;
            chkMushrooms.Checked = false;
            chkOnion.Checked = false;
            chkTomatos.Checked = false;
            chkOlives.Checked = false;



            
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrustType();
            UpdateEatPlace();
            UpdateToppings();
            CalculateTotalPrice();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
    }
    }

