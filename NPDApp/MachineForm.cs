using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPDApp.models;
using Exception = System.Exception;

namespace NPDApp
{
    public partial class MachineForm : BaseForm
    {
        public MachineForm()
        {
            InitializeComponent();
        }

        private void MachineForm_Load(object sender, EventArgs e)
        {
            // Populate dropdown control with machine types
            machineTypeComboBox.DataSource = Enum.GetNames(typeof(MachineType));
           
            //Not working properly
           /*var data = Enum.GetNames(typeof(MachineType)).ToList()
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            machineTypeComboBox.DataSource = data;
            machineTypeComboBox.DisplayMember = "Description";
            machineTypeComboBox.ValueMember = "Value";
            */
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            machineNameTextBox.ResetText();
            manufacturerTextBox.ResetText();
            machineTypeComboBox.ResetText();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Record saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error saving record.");
            }
        }

        private void AddNewMachine()
        {
            Machine machine = new Machine()
            {
                Name = machineNameTextBox.Text,
                Manufacturer = manufacturerTextBox.Text,
                Type = (MachineType)Enum.Parse(typeof(MachineType), machineTypeComboBox.SelectedText)

            };
            var machineRepository = repositoryFactory.MachineRepository;
            machineRepository.Insert(machine);
            repositoryFactory.Save();
        }
    }
}
