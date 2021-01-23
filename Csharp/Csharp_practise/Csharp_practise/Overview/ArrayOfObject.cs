using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class ArrayOfObject
    {
        public void Run()
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Student[] student = new Student[n];
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine("Student ID: " + (i + 1));
                Console.Write("Student first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Student last name: ");
                string lastName = Console.ReadLine();

                student[i] = new Student(i + 1, firstName, lastName);
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (var item in student)
            {
                Console.WriteLine("Student ID: " + item.getId());
                Console.WriteLine("Student First Name: " + item.getFirstName());
                Console.WriteLine("Student Last Name: " + item.getLastName());
                Console.WriteLine();
            }
        }
    }
}
