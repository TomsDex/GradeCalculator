namespace TW_Deliverable_One___Refactored
{
    internal class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            Logic ILogic = new Logic();

            bool addAnother = true;

            while (addAnother) //initialise overall input loop
            {
                Student inStudent = new Student();
                students.Add(inStudent);
                addAnother = Logic.AddAnother;
            }

            Logic.OutputAllStudents(students);
            Logic.GetHighestGrade(students);
        }
            
    }
}

public class Student
    {
        public string Name { get; set; }
        public double Mark { get; set; }
        public bool IsHigher { get; set; }
    public string Grade { get; set; }
    public bool HasPassed { get; set; }


    public Student()
        {
            Name = GetName();
            Mark = GetMark();
            IsHigher = GetBand();
        Grade = CalculateGrade(IsHigher, Mark);
        HasPassed = CalculatePassed(Grade);

        }

        private static string GetName()
        {
            string? inName;

            while (true) //initialise student name loop
            {
                Console.WriteLine("Enter a student's name:");
                try
                {
                    inName = Console.ReadLine();
                    if (inName == string.Empty) throw new Exception("Name input is empty! Please try again.");
                    else return inName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            } //end of name loop
        }

        private static double GetMark()
        {
            double inMark;

            while (true) //initialise student grade loop
            {
                Console.WriteLine("Enter the student's mark: ");
                try
                {
                    string? sGrade = Console.ReadLine();
                    if (sGrade == string.Empty) throw new Exception("Grade input is empty! Please try again.");
                    else
                    {
                        if (double.TryParse(sGrade, out inMark) && 0 <= inMark && inMark <= 100) return inMark; //parse input to double and perform input validatioon that 0 <= inMark <= 100
                        else throw new Exception("Please enter a valid number between 0 and 100!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            } //end of grade loop
        }

        private static bool GetBand()
        {
            while (true) //initialise higher grade storage loop
            {
                Console.WriteLine("Is this student on the higher grade list? [Y/N]");
                try
                {
                    string? input = Console.ReadLine()?.ToUpper();

                    if (input == "Y") return true;
                    else if (input == "N") return false;
                    else throw new Exception("Please respond with Y or N");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }//end of high/low loop
        }

    private static string CalculateGrade(bool isHigher, double mark)
    {
        if (isHigher)
        {
            if (mark < 10) return "U";
            else if (mark < 30) return "F";
            else if (mark < 50) return "E";
            else if (mark < 60) return "D";
            else if (mark < 70) return "C";
            else if (mark < 80) return "B";
            else if (mark < 90) return "A";
            else return "A*";
        }
        else
        {
            if (mark < 20) return "U";
            else if (mark < 40) return "F";
            else if (mark < 60) return "E";
            else if (mark < 80) return "D";
            else if (mark < 90) return "C";
            else return "B";
        }
    }

    private static bool CalculatePassed(string grade)
    {
        if (grade == "C" || grade == "B" || grade == "A" || grade == "A*") return true;
        else return false;
    }

}

public class Logic
{
    public bool AddAnother { get; set; }
    public static void OutputAllStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.Write(student.Name + " has ");

            if (student.HasPassed) Console.Write("passed");
            else Console.Write("failed");

            Console.WriteLine(" with a Grade " + student.Grade + "!");
        }
    }
    public static void GetHighestGrade(List<Student> students)
    {
        var studentsByHighestGrade = students.OrderByDescending(x => x.Grade, StringComparer.Ordinal); //create new list sorted by highest grade
        foreach (Student student in studentsByHighestGrade)
        {
            Console.WriteLine(student.Grade);
        }
    }

    public Logic() 
    {
        AddAnother = CalculateAddAnother();
    }

    private static bool CalculateAddAnother()
    {
        Console.WriteLine("Would you like to add another student? [Y/N]");
        while (true)
        {
            try
            {
                string? input = Console.ReadLine()?.ToUpper();
                if (input == "Y") return true;
                else if (input == "N") return false;
                else throw new Exception("Please respond with Y or N");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}