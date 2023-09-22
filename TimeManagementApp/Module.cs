using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementApp
{
    internal class Module //Module class
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int WeeksInSemester { get; set; }
        public DateTime StartDate { get; set; }
        public List<ModuleStudyRecord> StudyRecords { get; set; }

        public Module(string code, string name, int credits, int classHoursPerWeek)
        {
            Code = code;
            Name = name;
            Credits = credits;
            ClassHoursPerWeek = classHoursPerWeek;
            StudyRecords = new List<ModuleStudyRecord>();
        }
    }
}
