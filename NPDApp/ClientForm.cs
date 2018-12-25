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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clientNameTxt.ResetText();
            clientAddressTxt.ResetText();
            clientPhoneTxt.ResetText();
            clientEmailTxt.ResetText();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                Address = clientAddressTxt.Text,
                Email = clientEmailTxt.Text,
                Name = clientEmailTxt.Text,
                PhoneNumber = clientPhoneTxt.Text
            };
            ClientRepository crRepository = new ClientRepository();;
            crRepository.InsertClient(client);
        }
    }
}
