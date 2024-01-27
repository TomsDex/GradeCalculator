using GradeCalculator;

namespace D1
{
    internal class Program
    {
        static void Main()
        {
            List<Student> studentsInput = [];

            do //initialise overall input loop
            {
                Student inStudent = new();
                studentsInput.Add(inStudent);
                if (!inStudent.AddAnother) break;


            } while (true);

            Logic.OutputAllStudents(studentsInput);
            Logic.GetAndOutputHighestGrade(studentsInput);
            Logic.OutputAverageMark(studentsInput);
        }

    }
}