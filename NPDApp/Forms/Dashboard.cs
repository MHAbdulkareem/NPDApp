using NPDApp.controllers;
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
    public partial class Dashboard : Form
    {
        JobManager jobManager;
        public Dashboard()
        {
            InitializeComponent();
            jobManager = new JobManager();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClientForm cform = new ClientForm();
            cform.ShowDialog(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobForm jobForm = new JobForm();
            jobForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadRegisteredJobs()
        {
            // Get all registered jobs in DB from JobsController
            jobManager.RetrieveRegisteredJobs();
            List<GridViewModel> currentJobs = (from jobs in jobManager.RegisteredJobs
                                               select new GridViewModel
                                               {
                                                   ID = jobs.ID,
                                                   ClientName = jobs.Client.Name,
                                                   MachineName = jobs.Machine.Name,
                                                   Description = jobs.Description,
                                                   Date = jobs.StartDate.ToLongDateString(),
                                                   Status = jobs.Status.ToString(),
                                                   Urgency = jobs.Urgency.ToString()
                                               }).ToList();

            // Set the Datasource of DataGridView as List of Current Jobs
            dataGridView1.DataSource = currentJobs;
            //Resize the ID Column to 50px
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 50;
            //Resize the Urgency Column to 60px
            DataGridViewColumn urgencyColumn = dataGridView1.Columns[6];
            urgencyColumn.Width = 60;
        }

        class GridViewModel
        {
            public int ID { get; set; }
            public string ClientName { get; set; }
            public string MachineName { get; set; }
            public string Description { get; set; }
            public string Date { get; set; }
            public string Status { get; set; }
            public string Urgency { get; set; }
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClientDetailsForm clientForm = new ClientDetailsForm();
            clientForm.ShowDialog(this);
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            // Reload Jobs Table values when Form in in-view and active
            LoadRegisteredJobs();
        }
    }
}
