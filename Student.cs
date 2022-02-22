using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_02
{
    class Student : Person
    {
        private float averageScore;
        private string faculty;

        public Student()
        {

        }

        public Student(string id, string fullName, float averageScore, string faculty)
        :base(id,fullName)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public override void Input()
        {
            base.Input();

            CheckFloat();
            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"ĐTB: {this.AverageScore}\nKhoa: {this.Faculty}");
        }

        /// <summary>
        /// Dùng để nhập và kiểm tra xem kí tự vừa nhập có phải là số hay không !
        /// </summary>
        private void CheckFloat()
        {
            try
            {
                Console.Write("Nhập ĐTB: ");
                AverageScore = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bạn vừa nhập không phải là số ! Vui lòng nhập lại");
                CheckFloat();
            }
        }
    }
}
