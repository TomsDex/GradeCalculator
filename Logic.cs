namespace GradeCalculator
{
    
        public class Logic
        {
            /// <summary>
            /// Outputs all student details, including a pass/fail and their grade
            /// </summary>
            /// <param name="students"></param>
            public static void OutputAllStudents(List<Student> students)
            {
                Console.WriteLine();
                foreach (var student in students)
                {
                    Console.Write(student.Name + " has ");

                    if (student.HasPassed) Console.Write("passed");
                    else Console.Write("failed");

                    Console.WriteLine(" with a Grade " + student.Grade + "!");
                }
                Console.WriteLine();
            }

            /// <summary>
            /// Sorts all students into a new list by grade, then outputs the students who achieved the highest grade
            /// </summary>
            /// <param name="studentsInput"></param>
            public static void GetAndOutputHighestGrade(List<Student> students)
            {
                //sorts student list alphabetically, this list stores A above A*
                List<Student> studentsByOrdinal = [.. students.OrderBy(student => student.Grade, StringComparer.Ordinal)];

                //begin process to move A* above A

                //initialise new list to store final result
                List<Student> studentsByGrade = [];

                //for every student input
                for (int i = 0; i < studentsByOrdinal.Count; i++)
                {
                    var student = studentsByOrdinal[i];

                    if (student.Grade == "A*")
                    {
                        //add A* students to final list
                        studentsByGrade.Add(student);
                        //remove A* students from old list
                        studentsByOrdinal.Remove(student);
                    }
                }

                //add all other students to final list
                foreach (var student in studentsByOrdinal) studentsByGrade.Add(student);

                //gets the highest grade
                string highestGrade = studentsByGrade[0].Grade;

                //initialise list for all students with that grade
                List<Student> studentsWithHighestGrade = [];

                foreach (var student in studentsByGrade)
                {
                    if (student.Grade == highestGrade)
                    {
                        //add all highest grade students to highest grade list
                        studentsWithHighestGrade.Add(student);
                    }
                }

                Console.Write("There ");
                if (studentsWithHighestGrade.Count == 1) Console.Write("is ");
                else Console.Write("are ");
                Console.Write(studentsWithHighestGrade.Count + " student");
                if (studentsWithHighestGrade.Count != 1) Console.Write("s");
                Console.Write(" with the highest grade of a");
                if (highestGrade == "E" || highestGrade == "A" || highestGrade == "A*") Console.Write("n");
                Console.WriteLine(" " + highestGrade + "!");
                if (studentsWithHighestGrade.Count == 1) Console.WriteLine("This was achieved by " + studentsWithHighestGrade[0].Name + ".");
                else
                {
                    Console.WriteLine("This was achieved by the following students:");
                    foreach (var student in studentsWithHighestGrade)
                    {
                        if (student.Grade == highestGrade)
                        {
                            Console.WriteLine(student.Name);
                        }
                    }
                }
            }

            public static void OutputAverageMark(List<Student> students)
            {
                double avgMark = 0;

                //gets sum of marks
                foreach (var student in students) avgMark += student.Mark;

                //divides by number of student inputs to get average mark
                avgMark /= students.Count;

                //rounds to the nearest int
                avgMark = double.Round(avgMark);

                if (students.Count > 1)
                {
                    Console.WriteLine("The average mark achieved by all students was " + avgMark + ".");
                    Console.WriteLine("This is equivalent to a Grade " + Student.CalculateGrade(true, avgMark) + " at the higher band and a Grade " + Student.CalculateGrade(false, avgMark) + " at the lower band.");
                }
            }
        }
}
