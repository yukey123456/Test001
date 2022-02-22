using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_02
{
    class Teacher : Person
    {

        private string diaChi;

        public Teacher()
        {

        }

        public Teacher(string id, string fullName, string diaChi)
        :base(id,fullName)
        {
            this.DiaChi = diaChi;
        }

        public string DiaChi { get => diaChi; set => diaChi = value; }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhập Địa chỉ: ");
            DiaChi = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Địa chỉ: {this.DiaChi}");
        }
    }
}
