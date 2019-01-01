using NPDApp.controllers;
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
        JobManager jobManager;
        public JobForm() : base()
        {
            InitializeComponent();
            jobManager = new JobManager(repositoryFactory.JobRepository);
        }

        private void JobForm_Load(object sender, EventArgs e)
        {
            LoadJobUrgency();
        }

        private void LoadJobUrgency()
        {

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

        private void AddMachineButton_Click(object sender, EventArgs e)
        {
            MachineForm machineForm = new MachineForm();
            machineForm.ShowDialog(this);
            this.LoadMachines();
        }

        private void SubmitJobButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(ControlsValidated())
                {
                    int clientID = (int)clientComboBox.SelectedValue;
                    int machineID = (int)machineComboBox.SelectedValue;
                    var description = faultDescTxt.Text;
                    var location = clientLocationTxt.Text;
                    // Schedule a new job
                    jobManager.Description = description;
                    jobManager.Location = location;
                    jobManager.Client = clientID;
                    jobManager.Machine = machineID;
                    jobManager.Urgency = (JobUrgency)Enum.Parse(typeof(JobUrgency), jobUrgencyComboBox.SelectedValue.ToString());
                    jobManager.Register();

                    repositoryFactory.Save();
                    MessageBox.Show("Record saved.");
                    ClearInput();
                }     
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Something went wrong.");
            }
                   
        }

        private void ClearInput()
        {
            faultDescTxt.Text = string.Empty;
            clientLocationTxt.Text = string.Empty;
            clientComboBox.ResetText();
            machineComboBox.ResetText();
        }

        private bool ControlsValidated()
        {
            bool validated = true;
            if (clientComboBox.SelectedValue == null || !int.TryParse(clientComboBox.SelectedValue.ToString(), out int value))
            {
                validated = false;
                MessageBox.Show("Please select a client.");
            }
            if (machineComboBox.SelectedValue == null || !int.TryParse(machineComboBox.SelectedValue.ToString(), out value))
            {
                validated = false;
                MessageBox.Show("Please select a machine.");
            }
            if(string.IsNullOrWhiteSpace(faultDescTxt.Text) || string.IsNullOrWhiteSpace(clientLocationTxt.Text))
            {
                validated = false;
                MessageBox.Show("Please provide description and location for the job.");
            }
            return validated;
        }

        private void JobForm_Shown(object sender, EventArgs e)
        {
            LoadClients();
            LoadMachines();
        }
    }
}
