using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPDApp.Controllers;
using NPDApp.Forms;
using NPDApp.models;
using Exception = System.Exception;

namespace NPDApp
{
    public partial class MachineForm : BaseForm
    {
        MachineManager machineManager;
        public MachineForm()
        {
            InitializeComponent();
            machineManager = new MachineManager(repositoryFactory.MachineRepository);
        }

        private void MachineForm_Load(object sender, EventArgs e)
        {
            // Populate dropdown control with machine types
            machineTypeComboBox.DataSource = Enum.GetValues(typeof(MachineType))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            machineTypeComboBox.DisplayMember = "Description";
            machineTypeComboBox.ValueMember = "Value";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            machineNameTextBox.ResetText();
            manufacturerTextBox.ResetText();
            machineTypeComboBox.SelectedIndex = 0;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewMachine();
                ClearControls();
                MessageBox.Show("Record saved.");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error saving record.");
            }
        }

        private void AddNewMachine()
        {
            var machineName = machineNameTextBox.Text;
            var manufacturer = manufacturerTextBox.Text;
            var type = machineTypeComboBox.SelectedValue.ToString();

            machineManager.AddMachine(machineName, type, manufacturer);            
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == machineNameTextBox)
            {
                Validate(machineNameTextBox);
            }
            else if (textBox == manufacturerTextBox)
            {
                Validate(manufacturerTextBox);
            }
        }

        private void Validate(TextBox textBox)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("This field is required.");
                valid = false;
            }
            else if (textBox.Text.Length < 2)
            {
                MessageBox.Show("Input is too short.");
                valid = false;
            }

            if (!valid)
            {
                textBox.Focus();
            }
        }
    }
}
