using DataTier;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace LogicTier
{
    public class University
    {
        private List<StudentWrap> _students = new List<StudentWrap>();

        public University()
        {
            string dataPath = "students.txt"; // путь к файлу с данными
            List<Student> tmp = AllStudents.GetAllStudents(dataPath);
            foreach (var t in tmp)
            {
                _students.Add(new StudentWrap(t));
            }
        }

        public List<StudentWrap> StudentList
        {
            get { return _students; }
        }

        public string NameOfUniversity
        {
            get { return "Наш Университет"; }
        }

        public int TotalStudents
        {
            get { return _students.Count; }
        }

        public int StudentsWithoutDebt
        {
            get { return _students.Count(s => s.AmountOfDebt == 0); }
        }

        public int TotalDebts
        {
            get { return _students.Sum(s => s.AmountOfDebt); }
        }

        public Dictionary<int, int> AmountDebtOnCourse
        {
            get
            {
                var result = new Dictionary<int, int>();
                foreach (var student in _students)
                {
                    if (result.ContainsKey(student.CourseStudent))
                    {
                        result[student.CourseStudent] += student.AmountOfDebt;
                    }
                    else
                    {
                        result[student.CourseStudent] = student.AmountOfDebt;
                    }
                }
                return result;
            }
        }

        public ObservableCollection<CourseDebtInfo> CourseDebtStatistics
        {
            get
            {
                var statistics = new ObservableCollection<CourseDebtInfo>();
                var debtByCourse = AmountDebtOnCourse;

                foreach (var course in debtByCourse.Keys.OrderBy(k => k))
                {
                    statistics.Add(new CourseDebtInfo
                    {
                        Course = course,
                        TotalDebt = debtByCourse[course]
                    });
                }

                return statistics;
            }
        }
    }

    public class CourseDebtInfo
    {
        public int Course { get; set; }
        public int TotalDebt { get; set; }
        public string DisplayInfo
        {
            get { return $"Курс {Course}: {TotalDebt} задолженностей"; }
        }
    }
}