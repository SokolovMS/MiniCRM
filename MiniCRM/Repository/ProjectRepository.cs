using MiniCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Repository
{
    class ProjectRepository
    {
        private List<Project> _projects = new List<Project>();

        public ProjectRepository()
        {
            StatusesRepository sr = new StatusesRepository();
            ClientRepository cr = new ClientRepository();

            Add(new Project("iOS QDR",      sr.Get(3), cr.Get(0), new DateTime(2015, 12, 12)));
            Add(new Project("iOS CDR",      sr.Get(2), cr.Get(0), new DateTime(2015, 12, 12)));
            Add(new Project("Punch List",   sr.Get(1), cr.Get(0), new DateTime(2015, 12, 12)));
            Add(new Project("Dodo IS",      sr.Get(3), cr.Get(1)));
            Add(new Project("PJM",          sr.Get(3), cr.Get(2)));
            Add(new Project("Kinect",       sr.Get(1), cr.Get(3), new DateTime(2015, 12, 13)));
            Add(new Project("Android-Касса",sr.Get(0), cr.Get(4), new DateTime(2015, 12, 14)));

            Add(new Project("del", sr.Get(0), cr.Get(0)));
            SetStatus(_projects.Count - 1, sr.Get(1));
            Remove(new Project("del", sr.Get(1), cr.Get(0)));
        }

        public List<Project> GetProjects()
        {
            return new List<Project>(_projects);
        }
        public void invoiceProjects(DateTime invoiceDate)
        {
            foreach (Project p in _projects)
            {
                p.InvoiceProject(invoiceDate);
            }
        }
        public void SetStatus(int ProjectIndex, string NewStatus)
        {
            if (ProjectIndex < 0 || ProjectIndex >= _projects.Count)
                throw new IndexOutOfRangeException("ProjectRepository.Get(" + ProjectIndex + ")");

            _projects[ProjectIndex].status = NewStatus;
        }

        public void Add(Project newProject)
        {
            _projects.Add(newProject);
        }
        public void Remove(Project project)
        {
            _projects.Remove(project);
        }
    }
}
