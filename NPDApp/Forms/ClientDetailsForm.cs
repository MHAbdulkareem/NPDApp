using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPDApp.controllers;

namespace NPDApp.Forms
{
    public partial class ClientDetailsForm : Form
    {
        private ClientManager clientManager;

        public ClientDetailsForm()
        {
            this.clientManager = new ClientManager();
            InitializeComponent();
        }

        private void ClientDetailsForm_Shown(object sender, EventArgs e)
        {
            LoadRegisteredClients();
        }

        private void LoadRegisteredClients()
        {
            List<GridViewModel> allClients = (from clients in clientManager.RegisteredClients
                                               select new GridViewModel
                                               {
                                                   ID = clients.ID,
                                                   Name = clients.Name,
                                                   Address = clients.Address,
                                                   Phone = clients.PhoneNumber,
                                                   Email = clients.Email,
                                               }).ToList();

            // Set the Datasource of DataGridView as List of Current Clients
            dataGridView1.DataSource = allClients;
            //Resize the ID Column to 50px
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 50;
        }

        class GridViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }

    }
}
