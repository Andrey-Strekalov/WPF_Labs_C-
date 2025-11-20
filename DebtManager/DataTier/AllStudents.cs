using System;
using System.Collections.Generic;
using System.IO;

namespace DataTier
{
    public static class AllStudents
    {
        public static List<Student> GetAllStudents(string dataPath)
        {
            List<Student> list = new List<Student>();

            if (string.IsNullOrEmpty(dataPath) || !File.Exists(dataPath))
            {
                // Если файла нет, возвращаем тестовые данные
                return GetTestData();
            }

            try
            {
                using (StreamReader sr = new StreamReader(dataPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] items = line.Split('*');
                        if (items.Length >= 4)
                        {
                            var student = new Student
                            {
                                Name = items[0].Trim(),
                                Group = items[1].Trim(),
                                Course = Convert.ToInt32(items[2].Trim()),
                                AmountOfDebt = Convert.ToInt32(items[3].Trim())
                            };
                            list.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка чтения файла: " + ex.Message);
                return GetTestData();
            }

            return list;
        }

        private static List<Student> GetTestData()
        {
            return new List<Student>
            {
                new Student { Name = "Иванов Иван", Group = "ИТ-21", Course = 2, AmountOfDebt = 0 },
                new Student { Name = "Петрова Анна", Group = "ИТ-21", Course = 2, AmountOfDebt = 2 },
                new Student { Name = "Сидоров Петр", Group = "ИТ-31", Course = 3, AmountOfDebt = 1 },
                new Student { Name = "Козлова Мария", Group = "ИТ-31", Course = 3, AmountOfDebt = 0 },
                new Student { Name = "Васильев Алексей", Group = "ИТ-11", Course = 1, AmountOfDebt = 3 }
            };
        }

        public static void SaveAllStudents(List<Student> students, string dataPath)
        {
            // Реализация сохранения в файл
        }
    }
}