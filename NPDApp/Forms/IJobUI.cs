using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.Forms
{
    public interface IJobUI
    {
        object SelectedClient { get; }
        object SelectedMachine { get; }
        object SelectedJobUrgency { get; }
        void PopulateClients(object dataSource, string displaymember, string valueMember);
        void PopulateMachines(object dataSource, string displaymember, string valueMember);
        void PopulateJobUrgency(object dataSource, string displaymember, string valueMember);
        void SetJobLocation(string location);
        void SetFaultDescription(string description);
        string GetJobLocation();
        string GetFaultDescription();
        void Register(JobPresenter jobPresenter);
        void Message(string message);
    }
}
