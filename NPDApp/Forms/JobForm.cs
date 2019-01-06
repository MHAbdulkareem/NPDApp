using NPDApp.controllers;
using NPDApp.Controllers;
using NPDApp.Forms;
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
    public partial class JobForm : Form, IJobUI
    {
        private JobPresenter presenter;

        public object SelectedClient { get => clientComboBox.SelectedValue; }
        public object SelectedMachine { get => machineComboBox.SelectedValue; }
        public object SelectedJobUrgency { get => jobUrgencyComboBox.SelectedValue; }

        public JobForm() : base()
        {
            InitializeComponent();
        }

        private void AddMachineButton_Click(object sender, EventArgs e)
        {
            MachineForm machineForm = new MachineForm();
            machineForm.ShowDialog(this);
            presenter.UpdateView();
        }

        private void SubmitJobButton_Click(object sender, EventArgs e)
        {
            presenter.CreateJob();

        }        

        private void JobForm_Activated(object sender, EventArgs e)
        {
            presenter.UpdateView();   
        }

        public void PopulateClients(object dataSource, string displaymember, string valueMember)
        {
            clientComboBox.DataSource = dataSource;
            clientComboBox.DisplayMember = displaymember;
            clientComboBox.ValueMember = valueMember;
        }

        public void PopulateMachines(object dataSource, string displaymember, string valueMember)
        {
            // Populate dropdown control with existing machines
            //machineManager.LoadRegisteredMachines();
            
            machineComboBox.DataSource = dataSource;
            machineComboBox.DisplayMember = displaymember;
            machineComboBox.ValueMember = valueMember;
        }

        public void PopulateJobUrgency(object dataSource, string displaymember, string valueMember)
        {
            jobUrgencyComboBox.DataSource = dataSource;

            jobUrgencyComboBox.DisplayMember = displaymember;
            jobUrgencyComboBox.ValueMember = valueMember;
        }

        public void SetJobLocation(string location)
        {
            clientLocationTxt.Text = location;
        }

        public void SetFaultDescription(string description)
        {
            faultDescTxt.Text = description;
        }

        public string GetJobLocation()
        {
            return clientLocationTxt.Text;
        }

        public string GetFaultDescription()
        {
            return faultDescTxt.Text;
        }

        public void Register(JobPresenter jobPresenter)
        {
            presenter = jobPresenter;
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }
    }
}
