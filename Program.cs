using phase1Endproject2;
using System;

class Program
{
    static void Main()
    {
        string dataFilePath = "teachers.txt";
        TeacherDataRepository teacherDataRepo = new TeacherDataRepository(dataFilePath);

        while (true)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Display All Teachers");
            Console.WriteLine("3. Update Teacher");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Teacher ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teacher Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Class and Section: ");
                    string classAndSection = Console.ReadLine();
                    var teacher = new Teacher { ID = id, Name = name, Class = classAndSection.Split(' ')[0], Section = classAndSection.Split(' ')[1] };
                    teacherDataRepo.AddTeacher(teacher);
                    Console.WriteLine("Teacher added successfully!");
                    break;

                case "2":
                    var allTeachers = teacherDataRepo.GetAllTeachers();
                    if (allTeachers.Count == 0)
                    {
                        Console.WriteLine("No teachers found.");
                    }
                    else
                    {
                        Console.WriteLine("Teachers:");
                        foreach (var t in allTeachers)
                        {
                            Console.WriteLine($"ID: {t.ID}, Name: {t.Name}, Class: {t.Class}, Section: {t.Section}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Enter Teacher ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Teacher Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Class and Section: ");
                    string newClassAndSection = Console.ReadLine();
                    var updatedTeacher = new Teacher { ID = updateId, Name = newName, Class = newClassAndSection.Split(' ')[0], Section = newClassAndSection.Split(' ')[1] };
                    teacherDataRepo.UpdateTeacher(updatedTeacher);
                    Console.WriteLine("Teacher updated successfully!");
                    break;

                case "4":
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
