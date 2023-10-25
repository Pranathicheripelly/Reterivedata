
    using System;
    using System.Collections.Generic;
    using System.IO;

    namespace Reterivedata
    {

   
        class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
        }

        class Program
        {
            static void Main()
            {
                List<Student> students = LoadStudentData("studentdata.txt");

                if (students.Count == 0)
                {
                    Console.WriteLine("No student data found.");
                }
                else
                {
                    Console.WriteLine("Student Data:");
                    Console.WriteLine("Name\tClass");
                    DisplayStudentData(students);

                    Console.WriteLine("\nSorting Students Data By Name:");
                    BubbleSort(students);
                    DisplayStudentData(students);

                    Console.WriteLine("\nSearch for a student by name:");
                    string searchName = Console.ReadLine();
                    int index = BinarySearch(students, searchName);

                    if (index != -1)
                    {
                        Console.WriteLine($"Student found: {students[index].Name}, Class: {students[index].Class}");
                    }
                    else
                    {
                        Console.WriteLine($"No students found with the name '{searchName}'.");
                    }
                }

                Console.ReadLine(); // Keep the console window open
            }

            static List<Student> LoadStudentData(string filePath)
            {
                List<Student> students = new List<Student>();

                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            students.Add(new Student
                            {
                                Name = parts[0].Trim(),
                                Class = parts[1].Trim()
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while reading the file: {e.Message}");
                }

                return students;
            }

            static void DisplayStudentData(List<Student> students)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($" {student.Name}\t{student.Class}");
                }
            }

            static void BubbleSort(List<Student> students)
            {
                int n = students.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (string.Compare(students[j].Name, students[j + 1].Name) > 0)
                        {
                            // Swap students[j] and students[j + 1]
                            Student temp = students[j];
                            students[j] = students[j + 1];
                            students[j + 1] = temp;
                        }
                    }
                }
            }

            static int BinarySearch(List<Student> students, string searchName)
            {
                int low = 0;
                int high = students.Count - 1;

                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    int comparison = string.Compare(students[mid].Name, searchName, StringComparison.OrdinalIgnoreCase);

                    if (comparison == 0)
                    {
                        return mid;
                    }
                    else if (comparison < 0)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }

                return -1; // Student not found
            }
        }
    }







