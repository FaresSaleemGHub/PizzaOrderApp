using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PizzaOrderApp
{
    public partial class OrderPage : Form
    {
        private string selectedImagePath = "";

        public OrderPage()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            else if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }
            else if (rbLarg.Checked)
            {
                lblSize.Text = "Larg";
                return;
            }
        }
        void UpdateCrustType()
        {
            UpdateTotalPrice();

            if (rbThin.Checked)
            {
                lblCrustype.Text = "Thin";
                return;
            }
            else if (rbMidium.Checked)
            {
                lblCrustype.Text = "Medium";
                return;
            }
            else if (rbThick.Checked)
            {
                lblCrustype.Text = "Thick";
                return;
            }
        }
        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            else if (rbTackeOut.Checked)
            {
                lblWhereToEat.Text = "Take out";
                return;
            }
        }

        void UpdatePizzaCounter()
        {
            UpdateTotalPrice();
            lblPzzaCounter.Text = nudPizzaCounter.Value + " Pizza";
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string sToppings = "";

            if (chkExtraChees.Checked)
                sToppings += "Extra Chees, ";
            if (chkGreenPapper.Checked)
                sToppings += "Green Papper, ";
            if (chkMashroom.Checked)
                sToppings += "Mashroom, ";
            if (chkOlives.Checked)
                sToppings += "Olives, ";
            if (chkOnion.Checked)
                sToppings += "Onion, ";
            if (chkTomatoes.Checked)
                sToppings += "Tomatoes, ";

            if (sToppings.EndsWith(","))
                sToppings = sToppings.Substring(0, sToppings.Length - 2).Trim();

            if (sToppings == "")
                sToppings = "No Toppings";

            lblToppings.Text = sToppings;
        }
        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else
                return Convert.ToSingle(rbLarg.Tag);
        }
        float CalculateToppingPrice()
        {
            float TotlaToppingPrice = 0;
            if (chkExtraChees.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkExtraChees.Tag);

            if (chkGreenPapper.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkGreenPapper.Tag);

            if (chkMashroom.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkMashroom.Tag);

            if (chkOlives.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkOnion.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkTomatoes.Checked)
                TotlaToppingPrice += Convert.ToSingle(chkTomatoes.Tag);

            return TotlaToppingPrice;
        }

        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag);
            else if (rbMidium.Checked)
                return Convert.ToSingle(rbMidium.Tag);
            else
                return Convert.ToSingle(rbThick.Tag);
        }

        float GetTotalPrice()
        {
            return (GetSelectedSizePrice() + CalculateToppingPrice() + GetSelectedCrustPrice()) * Convert.ToSingle(nudPizzaCounter.Value);
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + GetTotalPrice().ToString();
        }

        void ResetForm()
        {
            UpdateTotalPrice();

            btnOrder.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbNumber.Enabled = true;
            nudPizzaCounter.Value = 1;

            rbMedium.Checked = true;

            chkExtraChees.Checked = false;
            chkGreenPapper.Checked = false;
            chkMashroom.Checked = false;
            chkOlives.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;

            rbThin.Checked = true;
            rbEatIn.Checked = true;
            btnOrder.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void OrderPage_Load(object sender, EventArgs e)
        {
            // Horizontally center the label
            lblTitle.Left = (this.Width - lblTitle.Width) / 2;

            UpdateSize();
            UpdateToppings();
            UpdateCrustType();
            UpdateWhereToEat();
            UpdateTotalPrice();

            cbGender.SelectedIndex = 0;  // Selects the first item
            dtpDOB.Value = DateTime.Now;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (pbLoading.Value < pbLoading.Maximum)
                {
                    pbLoading.Value += 10;
                    pbLoading.Refresh();
                    Thread.Sleep(500);

                    if (pbLoading.Value == 50)
                    {
                        if (!IsValidUserRegistrEntry())
                        {
                            pbLoading.Value = 0;
                            break;
                        }
                    }
                    if (pbLoading.Value == 100)
                    {
                        if (MessageBox.Show("Confirm The Order?", "Confirmation",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                            DialogResult.OK)
                        {
                            MessageBox.Show("Order Places Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnOrder.Enabled = false;
                            gbSize.Enabled = false;
                            gbToppings.Enabled = false;
                            gbCrustType.Enabled = false;
                            gbWhereToEat.Enabled = false;
                            gbNumber.Enabled = false;
                        }
                        pbLoading.Value = 0;
                    }
                }
            }
        }

        private bool ShowErrorMessage()
        {
            MessageBox.Show("Please, Check Your Registry Inputs",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
        private bool IsValidUserRegistrEntry()
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                return ShowErrorMessage();

            }
            else if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                return ShowErrorMessage();
            }
            else if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                return ShowErrorMessage();
            }
            else if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                return ShowErrorMessage();
            }
            else if (string.IsNullOrWhiteSpace(mtbPhoneNumber.Text))
            {
                return ShowErrorMessage();
            }
            else if (string.IsNullOrWhiteSpace(tbNotes.Text))
            {
                return ShowErrorMessage();
            }
            else if (string.IsNullOrWhiteSpace(selectedImagePath))
            {
                return ShowErrorMessage();
            }
            return true;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTackeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMashroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPapper_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void OrderPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NewItem => Item 2");
        }

        private void tsmTitleColor_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void tsmTitleFont_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void tsmOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it's OK");
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            lblTitle.Font = fontDialog1.Font;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                epEmpty.SetError(tbFirstName, "This field is required");
            }
            else
            {
                epEmpty.SetError(tbFirstName, ""); // clear
            }
        }

        private void CheckEmptyErrorProvider(object sender, EventArgs e)
        {
            Control tb = sender as Control;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                epEmpty.SetError(tb, "This field is required");
            }
            else
            {
                epEmpty.SetError(tb, ""); // clear
            }
        }

        private void pbProfile_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbProfile_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select Profile Picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Dispose the old image to release file lock
                if (pbProfile.Image != null)
                {
                    pbProfile.Image.Dispose();
                }
                selectedImagePath = openFileDialog1.FileName;
                pbProfile.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void rbMidium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void nudPizzaCounter_ValueChanged(object sender, EventArgs e)
        {
            UpdatePizzaCounter();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            cbGender.SelectedIndex = 0;
            tbEmail.Text = "";
            tbPassword.Text = "";
            mtbPhoneNumber.Text = "";
            tbNotes.Text = "";
            dtpDOB.Value = DateTime.Now;

            pbProfile.Image = Properties.Resources.picture1;
        }

        private void newOrderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void contatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string url = "https://www.facebook.com/fares.saleem.52/";
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            //{
            //    FileName = url,
            //    UseShellExecute = true
            //});
        }
        private void ChangeFont()
        {
            Font OriginalFont = lblTitle.Font;

            fontDialog1.Font = lblTitle.Font;

            fontDialog1.ShowColor = true;
            fontDialog1.ShowApply = true;
            fontDialog1.ShowEffects = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblTitle.Font = fontDialog1.Font;
            }
            else
            {
                lblTitle.Font = OriginalFont;
            }
        }

        private void ChangeColor()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblTitle.ForeColor = colorDialog1.Color;
            }
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string email = "fareses11@hotmail.com";
            string subject = Uri.EscapeDataString("Hello from Pizza Order App");
            string body = Uri.EscapeDataString("I wanted to reach out to you...");

            string mailto = $"mailto:{email}?subject={subject}&body={body}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = mailto,
                UseShellExecute = true
            });
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.facebook.com/fares.saleem.52/";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void inestagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.instagram.com/fares.t.h.saleem/";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void linkedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/fares-saleem-1578a8361/";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/FaresSaleemGHub";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
