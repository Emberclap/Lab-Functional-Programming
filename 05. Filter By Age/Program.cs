namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                string name = person[0];
                int age = int.Parse(person[1]);
                Student student = new Student(name, age);
                students.Add(student);
            }
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            Func<Student, int, bool> filter = FilterGenerator();
            
            students = students
                .Where(student => filter(student, ageThreshold))
                .ToList();
            string format = Console.ReadLine();

            Action<Student> printer = PrinterGenerator(format);

            students.ForEach(s => printer(s));

            Func<Student, int, bool> FilterGenerator()
            {
                Func<Student, int, bool> filter = null;
                if (condition == "older")
                {
                    filter = (student, number) => student.Age >= ageThreshold;
                }
                else if (condition == "younger")
                {
                    filter = (student, number) => student.Age < ageThreshold;
                }
                return filter;
            }

            Action<Student> PrinterGenerator(string format)
            {
                if (format == "name age")
                {
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                }
                else if (format == "name")
                {
                    return s => Console.WriteLine($"{s.Name}");
                }
                else if (format == "age")
                {
                    return s => Console.WriteLine($"{s.Age}");
                }
                return null;
            }
        }

   

        public class Student
        {
            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}