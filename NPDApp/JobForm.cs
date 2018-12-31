using NPDApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPDApp
{
    public partial class JobForm : BaseForm
    {
        public JobForm() : base()
        {
            InitializeComponent();
        }

        private void JobForm_Load(object sender, EventArgs e)
        {
            // Populate dropdown control with job urgency types
            jobUrgencyComboBox.DataSource = Enum.GetNames(typeof(JobUrgency));

            // Populate dropdown control with machine type
            machineComboBox.DataSource = Enum.GetNames(typeof(MachineType));

            // Populate client list dropdown from db
            List<Client> clients = repositoryFactory.ClientRepository.Get().ToList();
            clientComboBox.DataSource = clients;
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "ID";
        }

        private void addMachineButton_Click(object sender, EventArgs e)
        {
            MachineForm machineForm = new MachineForm();
            machineForm.ShowDialog(this);
        }
    }
}
