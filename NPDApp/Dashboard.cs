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
    public partial class Dashboard : BaseForm
    {
        JobManager jobManager;
        public Dashboard()
        {
            InitializeComponent();
            jobManager = new JobManager(repositoryFactory.JobRepository);
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
            LoadRegisteredJobs();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadRegisteredJobs();
        }

        private void LoadRegisteredJobs()
        {
            List<GridViewModel> currentJobs = (from jobs in jobManager.RegisteredJobs
                                               select new GridViewModel
                                               {
                                                   ID = jobs.ID,
                                                   Location = jobs.Location,
                                                   Description = jobs.Description,
                                                   Date = jobs.StartDate.ToLongDateString(),
                                                   Urgency = jobs.Urgency.ToString(),

                                               }).ToList();

            dataGridView1.DataSource = currentJobs;
        }

        class GridViewModel
        {
            public int ID { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Date { get; set; }
            public string Urgency { get; set; }
        }
    }
}
