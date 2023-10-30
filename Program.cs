using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProjectStoringAndUpdatingTeacherRecords
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassNum { get; set; }
        public String Section { get; set; }

        public Teacher(int id, string name, int classNum, string section)
        {
            Id = id;
            Name = name;
            ClassNum = classNum;
            Section = section;
        }
    }
}
