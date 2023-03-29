// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Project
{
    public class Student : Human
    {
        private string _faculty;
        private int _course;
        private string _group;

        public Student()
        {
            Console.WriteLine("---Вызван конструктор без параметров класса Student---");
        }

        public Student(string surname, string name, string patronymic, DateOnly birthday,
            string faculty, int course, string group) : base(surname, name, patronymic, birthday)
        {
            Console.WriteLine("---Вызван конструктор с параметрами класса Student---");
            _faculty = faculty;
            _course = course;
            _group = group;
        }

        public Student(Student student) : base(student)
        {
            Console.WriteLine("---Вызван конструктор копирования класса Student---");
            _faculty = student._faculty;
            _course = student._course;
            _group = student._group;
        }

        public void EditFaculty()
        {
            while (true)
            {
                Console.Write("Факультет - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _faculty = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditGroup()
        {
            while (true)
            {
                Console.Write("Группа - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _group = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditCourse()
        {
            while (true)
            {
                Console.Write("Курс - ");
                var value = Console.ReadLine();
                
                if (int.TryParse(value, out var course) && course >= 1 && course <= 5)
                {
                    _course = course;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести число от 1 до 5. Попробуйте ещё раз!");
            }
        }
        
        public string ToString()
        {
            return base.ToString() + "\nFaculty - " + _faculty + "\nCourse - " + _course + "\nGroup - " + _group;
        }

        public void RequestInfo()
        {
            base.RequestInfo();
            EditFaculty();
            EditCourse();
            EditGroup();
        }

        ~Student()
        {
            Console.WriteLine("---Вызван деструктор класса Student---");
        }
    }
}