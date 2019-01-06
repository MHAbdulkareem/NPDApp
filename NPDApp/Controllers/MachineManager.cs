using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPDApp.models;
using NPDApp.DataAccess;

namespace NPDApp.Controllers
{
    public class MachineManager : DataAccessImpl
    {
        private IRepository<Machine> repository;
        private List<Machine> registeredMachines;

        public MachineManager()
        {
            this.repository = repositoryFactory.MachineRepository;
            LoadRegisteredMachines();
        }

        public void LoadRegisteredMachines()
        {
            registeredMachines = (from machines in repository.Get()
                                 select machines).ToList();
        }

        public List<Machine> RegisteredMachines { get { return registeredMachines; } }

        public void AddMachine(string machineName, string machineType, string manufacturer)
        {
            var machine = new Machine
            {
                Name = machineName,
                Manufacturer = manufacturer,
                Type = (MachineType)Enum.Parse(typeof(MachineType), machineType)
            };
            repository.Insert(machine);
            repositoryFactory.Save();
        }

        public Machine GetMachine(int ID)
        {
            var foundMachine = repository.GetByID(ID);
            return foundMachine;
        }

        public void RemoveMachine(Machine machine)
        {
            repository.Delete(machine);
        }

    }
}
