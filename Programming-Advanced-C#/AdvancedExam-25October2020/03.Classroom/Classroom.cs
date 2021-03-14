using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classroom
{
    public class Classroom
    {
        private List<Student> students;

        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>(Capacity);
        }
        public int Capacity { get; set; }

        public int Count { get; private set; }

        public string RegisterStudent(Student student) 
        {
            if (this.Count >= Capacity)
            {
                return"No seats in the classroom";
            }
            this.Count++;
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(f => f.FirstName == firstName) && students.Any(l => l.LastName == lastName))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (firstName == students[i].FirstName && lastName == students[i].LastName)
                    {
                        this.Count--;
                        students.Remove(students[i]);
                        return $"Dismissed student {firstName} {lastName}";
                        
                    }
                }
            }   
            return $"Student not found";      
               
        }
        public string GetSubjectInfo(string subject)
        {
            if (students.Any(f => f.Subject == subject))
            {
                StringBuilder subjectInfo = new StringBuilder();
                subjectInfo.AppendLine($"Subject: {subject}");
                subjectInfo.AppendLine("Students:");
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Subject == subject)
                    {
                        subjectInfo.AppendLine($"{students[i].FirstName} {students[i].LastName}");
                    }
                }
                return subjectInfo.ToString();     
               
            }
            else
            {
                return "No students enrolled for the subject";
            }            
                       
        }
        public int GetStudentsCount() 
        {
            return students.Count;        
        }

        public string GetStudent(string firstName, string lastName) 
        {
            Student student = null;

            if (students.Any(f => f.FirstName == firstName) && students.Any(l => l.LastName == lastName))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (firstName == students[i].FirstName && lastName == students[i].LastName)                  
                    {

                        student = students[i];

                    }
                }
            }
            return $"Student: First Name = {student.FirstName}, Last Name = {student.LastName}, Subject = {student.Subject}";

        }
    }
}
