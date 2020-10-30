﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class StudentRecord
    {
        public void Run()
        {
            Student student = new Student();
            var obj = student.GetCourses();
            foreach (var item in obj)
            {
                Console.Write("Student id: " + item.ID + "\t");
                Console.Write("Student name: " + item.Name + "\t");
                Console.Write("Student age: " + item.Age + "\t");
                Console.Write("Graduation status: " + item.status + "\n");
            }
            #region by using for loop
            //for (int i = 0; i < student.GetCourses().Count; i++)
            //{
            //    Console.Write("Student id: " + student.GetCourses()[i].ID + "\t");
            //    Console.Write("Student name: " + student.GetCourses()[i].Name + "\t");
            //    Console.Write("Student age: " + student.GetCourses()[i].Age + "\t");
            //    Console.Write("Graduation status: " + student.GetCourses()[i].status + "\n");
            //}
            #endregion
        }
    }
    class Student
    {
        public Course course()
        {
            return new Course() { ID = 1, Name = "Eyad", Age = 1, status = Status.NonGraduate };
        }
        public List<Course> GetCourses()
        {
            //return new List<Course>
            return new List<Course>()
            {
                //new Course{ID = 1, Name = "Moayad", Age = 23, status = Status.Graduate},
                new Course(){ID = 1, Name = "Moayad", Age = 23, status = Status.Graduate},
                new Course(){ID = 1, Name = "Mohanned", Age = 21, status = Status.NonGraduate},
                new Course(){ID = 1, Name = "Mohammed", Age = 19, status = Status.NonGraduate}
            };
        }
    }
    struct Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Status status { get; set; }
    }
    enum Status
    {
        Graduate, NonGraduate
    }
}
