using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPDApp.DataAccess;
using NPDApp.models;

namespace NPDApp
{
    public partial class ClientForm : BaseForm
    {
        public ClientForm() : base()
        {
            InitializeComponent();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            clientNameTxt.ResetText();
            clientAddressTxt.ResetText();
            clientPhoneTxt.ResetText();
            clientEmailTxt.ResetText();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(EULAAccepted())
            {
                try
                {
                    SaveRecord();
                    ClearControls();
                    MessageBox.Show("Record saved.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error saving record.");
                }
                
            }
            else
            {
                MessageBox.Show("Please accept Terms and Conditions.");
            }
            
        }

        private bool EULAAccepted()
        {
            return agreeCheckBox.Checked;
        }

        private void SaveRecord()
        {
            Client client = new Client
            {
                Address = clientAddressTxt.Text,
                Email = clientEmailTxt.Text,
                Name = clientNameTxt.Text,
                PhoneNumber = clientPhoneTxt.Text
                //RegistrationDate = DateTime.Now,
                //Eula = agreeCheckBox.Checked
            };
            var crRepository = repositoryFactory.ClientRepository;
            crRepository.Insert(client);
            repositoryFactory.Save();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if(textBox == clientNameTxt)
            {
                ValidateClientName(clientNameTxt);
            }
            else if(textBox == clientAddressTxt)
            {
                ValidateClientAddress(clientAddressTxt);
            }
            else if(textBox == clientEmailTxt)
            {
                ValidateClientEmail(clientEmailTxt);
            }
            else
            {
                ValidateClientPhoneNumber(clientPhoneTxt);
            }
        }

        private void ValidateClientPhoneNumber(TextBox clientPhoneTxt)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(clientPhoneTxt.Text))
            {
                MessageBox.Show("Please enter client phone number");
                valid = false;
            }
            else if (!clientPhoneTxt.Text.Any(c => Char.IsNumber(c)))
            {
                MessageBox.Show("Please enter only numbers");
                valid = false;
            }
            if(!valid)
            {
                clientPhoneTxt.Focus();
            }
        }

        private void ValidateClientEmail(TextBox clientEmailTxt)
        {
            try
            {
                new System.Net.Mail.MailAddress(clientEmailTxt.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please enter client email");
                clientEmailTxt.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid email");
                clientEmailTxt.Focus();
            }
        }

        private void ValidateClientAddress(TextBox clientAddressTxt)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(clientAddressTxt.Text))
            {
                MessageBox.Show("Please enter client address");
                valid = false;
            }
            else if(clientAddressTxt.Text.Length < 2)
            {
                MessageBox.Show("Client address is too short");
                valid = false;
            }

            if(!valid)
            {
                clientAddressTxt.Focus();
            }
        }

        private void ValidateClientName(TextBox textBox)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Please enter client name");
                valid = false;
            }
            else if ( textBox.Text.Length < 2)
            {
                MessageBox.Show("Client name is too short");
                valid = false;
            }
            else if (textBox.Text.Length > 50)
            {
                MessageBox.Show("Client name is too long");
                valid = false;
            }
            if (!valid)
            {
                textBox.Focus();
            }

        }
    }
}
