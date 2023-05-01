using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History 101", 3);
            CollegeClassModel math = new CollegeClassModel("Calculus 202", 2);

            //This is the event listener which will look for the changes
            //happening within the app or data and fire the event

            history.EnrollmentFull += CollegeClass_EnrollmentFull;

            history.SignUpStudent("Shah Haque").PrintToConsole();
            history.SignUpStudent("Lebron James").PrintToConsole();
            history.SignUpStudent("Sue Storm").PrintToConsole();
            history.SignUpStudent("Tim Corey").PrintToConsole();
            Console.WriteLine();

            //This is the event listener which will look for the changes
            //happening within the app or data and fire the event
            math.EnrollmentFull += CollegeClass_EnrollmentFull;         

            math.SignUpStudent("Shah Haque").PrintToConsole();
            math.SignUpStudent("Sue Storm").PrintToConsole();
            math.SignUpStudent("Tim Corey").PrintToConsole();


            Console.ReadLine();
        }

        /// <summary>
        /// This handles the event listener logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CollegeClass_EnrollmentFull(object sender, string e)
        {
            CollegeClassModel model = (CollegeClassModel)sender;
            Console.WriteLine();
            Console.WriteLine($"{ model.CourseTitle } is now full");
            Console.WriteLine();
        }  
    }
}