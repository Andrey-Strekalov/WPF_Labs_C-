using DataTier;

namespace LogicTier
{
    public class StudentWrap
    {
        private Student _student;

        public StudentWrap(Student s)
        {
            _student = s;
        }

        public string NameStudent
        {
            get { return _student.Name; }
            set { _student.Name = value; }
        }

        public string GroupStudent
        {
            get { return _student.Group; }
            set { _student.Group = value; }
        }

        public int CourseStudent
        {
            get { return _student.Course; }
            set { _student.Course = value; }
        }

        public int AmountOfDebt
        {
            get { return _student.AmountOfDebt; }
            set { _student.AmountOfDebt = value; }
        }

        public string StudentPresentation
        {
            get
            {
                return _student.Name + " | Группа: " + _student.Group +
                       " | Курс: " + _student.Course +
                       " | Задолженностей: " + _student.AmountOfDebt;
            }
        }
    }
}