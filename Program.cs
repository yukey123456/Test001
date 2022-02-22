using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_02
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            List<Person> listPerson = InputList();

            Console.WriteLine("\n ===Xuất danh sách Person===");
            OutputList(listPerson);

            //2.1 Tìm kiếm các sinh viên thuộc khoa CNTT
            TimSVCNTT(listPerson);

            //2.2 Xuất danh sách các sinh viên có điểm trung bình <5 và thuộc khoa CNTT
            TimSVCNTTTB5(listPerson);

            //2.3 Xuất danh sách giao viên có địa chỉ chứa thông tin "Quận 9"(nếu có)
            TimGiaoVienQuan9(listPerson, "Quận 9");

            //2.4 Tìm kiếm giáo viên có mã giảng viên là CHN060286 và xuất ra nếu tìm được
            TimGiaoVien(listPerson, "CHN060286");

            //2.5 Tìm danh sách sinh viên có ĐTB cao nhất và thuộc khoa CNTT
            TimSVCNTTDTBMax(listPerson);


            Console.ReadKey();

        }

        //Tìm danh sách sinh viên có ĐTB cao nhất và thuộc khoa CNTT
        private static void TimSVCNTTDTBMax(List<Person> listPerson)
        {
            Console.WriteLine("================================");
            float DTBMax = listPerson.Where(p => (p as Student).Faculty == "CNTT").Max(p => (p as Student).AverageScore);
            List<Person> listSVCNTTDTBMax = listPerson.Where(p => (p as Student).Faculty == "CNTT" && (p as Student).AverageScore == DTBMax).ToList();

            Console.WriteLine("Danh sách sinh viên thuộc khoa CNTT có ĐTB cao nhất là: ");
            OutputList(listSVCNTTDTBMax);
        }

        //Xuất danh sách giao viên có địa chỉ chứa thông tin "v"
        private static void TimGiaoVienQuan9(List<Person> listPerson, string v)
        {
            List<Person> listGV = listPerson.Where(p => p is Teacher &&
                                                       (p as Teacher).DiaChi.Contains(v)).ToList();

            if (listGV.Count != 0)
            {
                Console.WriteLine("Danh sách giáo viên có địa chỉ chứa thông tin " + v + " là:");
                OutputList(listGV);
            }
            else
            {
                Console.WriteLine("Không tìm thấy Giáo viên có địa chỉ chứa thông tin " + v);
            }
        }

        //Tìm kiếm giáo viên có mã giảng viên là "v" và xuất ra nếu tìm được
        private static void TimGiaoVien(List<Person> listPerson, string v)
        {
            Console.WriteLine("================================");
            List<Person> listGV = listPerson.Where(p => p is Teacher &&
                                                       p.ID == v ).ToList();

            if (listGV.Count != 0)
            {
                Console.WriteLine("Giáo viên có mã " + v + " là:");
                OutputList(listGV);
            }
            else
            {
                Console.WriteLine("Không tìm thấy Giáo viên có mã " + v);
            }
        }

        //Xuất danh sách các sinh viên có điểm trung bình <5 và thuộc khoa CNTT
        private static void TimSVCNTTTB5(List<Person> listPerson)
        {
            Console.WriteLine("================================");
            List<Person> listSVCNTTTB5 = listPerson.Where(p => p is Student &&
                                                       (p as Student).Faculty == "CNTT" && (p as Student).AverageScore < 5).ToList();

            if (listSVCNTTTB5.Count != 0)
            {
                Console.WriteLine("Danh sách sinh viên thuộc khoa CNTT có ĐTB < 5: ");
                OutputList(listSVCNTTTB5);
            }
            else
            {
                Console.WriteLine("Không có sinh viên thuộc khoa CNTT có ĐTB < 5 !");
            }
        }

        //Tìm kiếm các sinh viên thuộc khoa CNTT
        private static void TimSVCNTT(List<Person> listPerson)
        {
            Console.WriteLine("================================");
            List<Person> listSVCNTT = listPerson.Where(p => p is Student &&
                                                       (p as Student).Faculty == "CNTT").ToList();

            if(listSVCNTT.Count != 0)
            {
                Console.WriteLine("Danh sách sinh viên thuộc khoa CNTT: ");
                OutputList(listSVCNTT);
            }
            else
            {
                Console.WriteLine("Không có sinh viên thuộc khoa CNTT!");
            }

        }

        //Xuất danh sách
        private static void OutputList(List<Person> listPerson)
        {
            
            foreach (var person in listPerson)
            {
                person.Output();
                Console.WriteLine("------------------------------");
            }
        }

        //Nhập danh sách
        private static List<Person> InputList()
        {
            List<Person> listPerson = new List<Person>();
            int choose = new int(), n = new int();
            Person person = new Person();

            //Nhập n và kiểm tra
            CheckInt(ref n, "Nhập số lượng person muốn tạo: ");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập đối tượng thứ {i+1}:");
                do
                {
                    CheckInt(ref choose, "Chọn đối tượng: 1-Student, 2-Teacher ? ");
                    
                    switch (choose)
                    {
                        case 1:
                            person = new Student();
                            person.Input();
                            listPerson.Add(person);
                            break;
                        case 2:
                            person = new Teacher();
                            person.Input();
                            listPerson.Add(person);
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại");
                            break;
                    }
                }while (choose < 1 || choose > 2);

            }
            
            return listPerson;
        }

        /// <summary>
        /// Kiểm tra xem kí tự vừa nhập là số hay chữ, nếu sai cho nhập lại
        /// </summary>
        /// <param name=""></param>
        private static void CheckInt(ref int num, string v)
        {
            try
            {
                Console.WriteLine(v);
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bạn vừa nhập không phải là số ! Vui lòng nhập lại !");
                CheckInt(ref num, v);
            }
        }
    }
}
