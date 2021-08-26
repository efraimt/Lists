using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lists
{

    class SortStudentsByAge : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return (x.Age.CompareTo(y.Age) *-1);
        }
    }


    class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            Id = Program.GetNextStudentId();
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public override bool Equals(object? obj)
        {
            return object.ReferenceEquals(this, obj) ? true : (obj as Student)?.Id == this.Id ? true : false;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Id, FirstName, LastName);
        }


        public int CompareTo(Student? other)
        {
            //if (this.FirstName == "Efraim") return 1;
            if (this.LastName.CompareTo(other.LastName) == 0)
                return this.FirstName.CompareTo(other.FirstName);
            return this.LastName.CompareTo(other.LastName);
        }
    }



    static class Program
    {
        static int index;
        public static Guid GetNextStudentId()
        {
            return Guid.NewGuid();
        }


        static List<Student> list = new List<Student>();


        static void PrintAll()
        {
            foreach (var item in list)
            {
                Debug.WriteLine(item);
            }
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //      Application.EnableVisualStyles();
            //      Application.SetCompatibleTextRenderingDefault(false);
            //      Application.Run(new Form1());


            List<Student> students = new List<Student>(50000);



            list.Add(new Student("Moshe", "Levi"));

            //var chaim = new Student("Chaim");
            //list.Add(chaim);
            list.Add(new Student("chaim", "Friedland") { Age=30});
            list.Add(new Student("Miriam", "Cohen") { Age = 36 });
            list.Add(new Student("Chaim", "Cohen") { Age = 25 });


            list.Add(new Student("Efraim", "Ben david") { Age = 29 });
            //list.Add(chaim);

            PrintAll();

            //list.Remove(chaim);
            list.Sort();

            list.Sort(new SortStudentsByAge());

            PrintAll();


            List<string> list2 = new List<string>(new string[] { "Moshe", "Chaim", "Miriam" });
            //MessageBox.Show(list2.Count.ToString());
            //list2.Sort();


            int x = 200;
            bool same = x.Equals(300);

            //Student s1 = new Student("Levi");
            //Student s2 = new Student("Usama");

            //same = s1.Equals(s2);

            //same = s1.Equals(s2);

            int compareResults = -9999;

            compareResults = x.CompareTo(300); //-1
            compareResults = x.CompareTo(200); //0
            compareResults = x.CompareTo(100); //1


            // s1.CompareTo(s2); // -1

        }
    }
}
