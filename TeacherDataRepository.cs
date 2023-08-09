using phase1Endproject2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phase1Endproject2
{

    public class TeacherDataRepository
    {
        private string dataFilePath;

        public TeacherDataRepository(string filePath)
        {
            this.dataFilePath = filePath;
        }

        public void AddTeacher(Teacher teacher)
        {
            List<string> lines = new List<string>();
            if (File.Exists(dataFilePath))
            {
                lines = File.ReadAllLines(dataFilePath).ToList();
            }

            lines.Add($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
            File.WriteAllLines(dataFilePath, lines);
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            if (File.Exists(dataFilePath))
            {
                string[] lines = File.ReadAllLines(dataFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string className = parts[2];
                        string section = parts[3];
                        teachers.Add(new Teacher { ID = id, Name = name, Class = className, Section = section });
                    }
                }
            }
            return teachers;
        }

        public void UpdateTeacher(Teacher updatedTeacher)
        {
            List<string> lines = new List<string>();
            if (File.Exists(dataFilePath))
            {
                lines = File.ReadAllLines(dataFilePath).ToList();
            }

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                int id = int.Parse(parts[0]);
                if (id == updatedTeacher.ID)
                {
                    lines[i] = $"{updatedTeacher.ID},{updatedTeacher.Name},{updatedTeacher.Class},{updatedTeacher.Section}";
                    break;
                }
            }

            File.WriteAllLines(dataFilePath, lines);
        }
    }
}
