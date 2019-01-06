using NPDApp.controllers;
using NPDApp.Controllers;
using NPDApp.DataAccess;
using NPDApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.Forms
{
    public class JobPresenter
    {
        private NDPAppContext context;
        private RepositoryFactory repositoryFactory;
        private JobManager jobManager;
        private ClientManager clientManager;
        private MachineManager machineManager;
        private IJobUI screen;

        public JobPresenter(IJobUI screen)
        {
            context = new NDPAppContext();
            repositoryFactory = new RepositoryFactory(context);
            jobManager = new JobManager();
            clientManager = new ClientManager();
            machineManager = new MachineManager();

            this.screen = screen;
            screen.Register(this);
            InitialiseForm();
        }

        private void InitialiseForm()
        {
            LoadClients();
            LoadMachines();
            LoadJobUrgency();
        }

        private object GetJobUrgency()
        {
            return Enum.GetValues(typeof(JobUrgency))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
            typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();
        }

        public void UpdateView()
        {
            LoadClients();
            LoadMachines();
            LoadJobUrgency();
        }

        private void LoadJobUrgency()
        {
            screen.PopulateJobUrgency(GetJobUrgency(), "Description", "Value");
        }

        private void LoadMachines()
        {
            // Populate dropdown control with existing machines
            machineManager.LoadRegisteredMachines();
            screen.PopulateMachines(machineManager.RegisteredMachines, "Name", "ID");
        }

        private void LoadClients()
        {
            screen.PopulateClients(clientManager.RegisteredClients, "Name", "ID");
        }

        public void CreateJob()
        {
            try
            {
                if (ControlsValidated())
                {
                    int clientID = (int)screen.SelectedClient;
                    int machineID = (int)screen.SelectedMachine;
                    var description = screen.GetFaultDescription();
                    var location = screen.GetJobLocation();

                    // Schedule a new job
                    jobManager.Description = description;
                    jobManager.Location = location;
                    jobManager.Client = clientID;
                    jobManager.Machine = machineID;
                    jobManager.Urgency = (JobUrgency)Enum.Parse(typeof(JobUrgency), screen.SelectedJobUrgency.ToString());
                    jobManager.Register();

                    repositoryFactory.Save();
                    screen.Message("Record saved.");
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                screen.Message($"Something went wrong: {ex.Message}");
            }
        }
        private bool ControlsValidated()
        {
            bool validated = true;
            if (screen.SelectedClient == null || !int.TryParse(screen.SelectedClient.ToString(), out int value))
            {
                validated = false;
                screen.Message("Please select a client.");
            }
            if (screen.SelectedMachine == null || !int.TryParse(screen.SelectedMachine.ToString(), out value))
            {
                validated = false;
                screen.Message("Please select a machine.");
            }
            if (string.IsNullOrWhiteSpace(screen.GetFaultDescription()) || string.IsNullOrWhiteSpace(screen.GetJobLocation()))
            {
                validated = false;
                screen.Message("Please provide description and location for the job.");
            }
            return validated;
        }

        private void ClearInput()
        {
            screen.SetJobLocation(string.Empty);
            screen.SetFaultDescription(string.Empty);
            //clientComboBox.ResetText();
            //machineComboBox.ResetText();
        }
    }
}
