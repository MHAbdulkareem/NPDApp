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
            LoadJobUrgency();
            LoadMachines();
            LoadClients();
        }

        private void LoadJobUrgency()
        {
            // Populate dropdown control with job urgency types
            jobUrgencyComboBox.DataSource = Enum.GetValues(typeof(JobUrgency))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            jobUrgencyComboBox.DisplayMember = "Description";
            jobUrgencyComboBox.ValueMember = "Value";
        }

        private void LoadClients()
        {
            // Populate client list dropdown from db
            var clients = repositoryFactory.ClientRepository.Get().ToList();
            clientComboBox.DataSource = clients;
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "ID";
        }

        private void LoadMachines()
        {
            // Populate dropdown control with machine type
            var machines = repositoryFactory.MachineRepository.Get().ToList();
            machineComboBox.DataSource = machines;
            machineComboBox.DisplayMember = "Name";
            machineComboBox.ValueMember = "ID";
        }

        private void addMachineButton_Click(object sender, EventArgs e)
        {
            MachineForm machineForm = new MachineForm();
            machineForm.ShowDialog(this);
            this.LoadMachines();
        }

        private void submitJobButton_Click(object sender, EventArgs e)
        {

        }
    }
}
