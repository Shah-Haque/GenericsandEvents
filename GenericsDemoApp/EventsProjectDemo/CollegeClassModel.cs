using System;
using System.Collections.Generic;

namespace EventsProjectDemo
{
    public class CollegeClassModel
    {
        //this initalises a eventhandler
        public event EventHandler<string> EnrollmentFull;

        private List<string> EnrolledStudents = new List<string>();
        private List<string> WaitingList = new List<string>();

        public string CourseTitle { get; private set; }
        public int MaximumStudents { get; private set; }

        public CollegeClassModel(string Title, int MaximumStudents)
        {
            CourseTitle = Title;
            this.MaximumStudents = MaximumStudents;

            
        }

        public string SignUpStudent (string StudentName) 
        {
            string output = "";

            if (EnrolledStudents.Count < MaximumStudents)
            {
                EnrolledStudents.Add(StudentName);
                output = $"{ StudentName } was enrolled in {CourseTitle} ";
                //we will check to if space for class is maxed out
                if (EnrolledStudents.Count == MaximumStudents)
                {
                    //this will invoke the event
                    EnrollmentFull?.Invoke(this, $"{CourseTitle} enrollment is now full");
                }
            }
            else 
            {
                WaitingList.Add(StudentName);
                output = $"{StudentName} was added to the wait list in {CourseTitle}";
            }

            return output;
        }

    }
}
