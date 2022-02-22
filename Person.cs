using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_02
{
    class Person
    {
        private string id;
        private string fullName;

        public Person()
        {
            //Đây là Nhánh 1
        }

        public Person(string id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
        }

        public string ID { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public virtual void Input()
        {
            Console.Write("Nhập ID: ");
            ID = Console.ReadLine();
            Console.Write("Nhập Họ và tên: ");
            FullName = Console.ReadLine();
        }

        public virtual void Output()
        {
            Console.WriteLine($"ID: {this.ID} - Họ và tên: {this.FullName}");
        }

    }
}
