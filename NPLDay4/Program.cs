using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NPLDay4
{
    class Program
    {
        /// <summary>
        /// ex1: nhap vao chuoi roi format theo dinh dang
        /// </summary>
        /// <param name="formatString"></param>
        public void Exercise1(string formatString)
        {
            List<string> str = formatString.Split(' ').ToList<string>();
            foreach (string item in str)
            {
                string it = item.Trim().ToLower();
                if (it == "")
                {
                    continue;
                }
                string i = char.ToUpper(it[0]) + it.Substring(1);
                Console.Write(i + " ");
                
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Ex2: Check email
        /// </summary>
        /// <param name="formatString"></param>
        public void Exercise2(string formatString)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            bool isMatch = Regex.IsMatch(formatString, pattern);
            if (isMatch)
            {
                Console.WriteLine("Email is valid");
            }
            else
            {
                Console.WriteLine("Email is invalid");
            }

        }



        //tạo 1 class để gán firtName và LatName cho 1 dối tượng
        class Person
        {
            private string firstName;
            private string lastName;
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                }
            }
            public string LastName
            {
                get { return lastName; }
                set
                {
                    lastName = value;
                }
            }
            public override string ToString()
            {
                return firstName + " "+lastName;
            }
        }


        /// <summary>
        /// tạo 1 class implement IComparer để so sánh lastName
        /// </summary>
        public class SortPersons : IComparer
        {
            public int Compare(object x, object y)
            {
                // Ép kiểu 2 object truyền vào về Person.
                Person p1 = x as Person;
                Person p2 = y as Person;

                //xử lý lỗi nếu object truyền vào là null
                if (p1 == null || p2 == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    //thực hiện so sánh và trả về các giá trị 1 0 -1 tương ứng lớn hơn, bằng, bé hơn.
                    int comVal = p1.LastName.CompareTo(p2.LastName);
                    if (comVal == 0)
                    {
                        return 0;
                    }
                    else if (comVal > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                    
                }
            }

        }


        /// <summary>
        /// ex3: sắp sếp chuỗi các tên nhập vào
        /// </summary>
        /// <param name="formatString"></param>
        public void Exercise3(string formatString)
        {
            ArrayList arrPersons = new ArrayList();  //tạo mạng dôi tượng
           
            List<string> strList = formatString.Split(',').ToList<string>();  //cắt chuỗi thành các tên sau mỗi dấu phẩy

            foreach (string item in strList)
            {
                //laoij bỏ dấu cách trc mỗi tên và viết hoa chữ cái đầu
                string itStr = item.Trim().ToLower();

                //string it = char.ToUpper(itStr[0]) + itStr.Substring(1);

                //tách 1 tên thành firstName và LastName
                List<string> firstLast = itStr.Split(' ').ToList<string>();
                for (int i = 0; i < firstLast.Count; i++)
                {
                    //nếu k có firstNamee
                    if (firstLast.Count == 1)
                    {
                        //tạo mới 1 đối tượng và gán lastName cho đối tg
                        Person p = new Person();
                        
                        string lName = char.ToUpper(firstLast[0][0]) + firstLast[0].Substring(1); //viết hoa chứ cái đầu

                        p.LastName = lName;
                        arrPersons.Add(p);
                    }

                    //th có cả firstName và LastName
                    if (firstLast.Count > 1)
                    {
                        //tạo mới 1 đối tượng và gán firstName và lastName cho đối tg
                        Person p1 = new Person();

                        //viết hoa chứ cái đầu của mỗi tên
                        string fName = char.ToUpper(firstLast[0][0]) + firstLast[0].Substring(1);
                        string lName = char.ToUpper(firstLast[1][0]) + firstLast[1].Substring(1);

                        p1.FirstName = fName;
                        p1.LastName = lName;
                        arrPersons.Add(p1);
                    }

                    //remove mảng chứa 1 tên sau mỗi lần for
                    firstLast.Clear();

                }
            }

            //sắp xếp các dôi tượng trong arraylisst theo lastName
            arrPersons.Sort(new SortPersons());
            foreach (Person per in arrPersons)
            {
                Console.Write(per.ToString() + ", ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Program pr = new Program();
            int menu;
            do
            {
                Console.WriteLine("==========MENU========");
                Console.WriteLine("1. Exercise 1");
                Console.WriteLine("2. Exercise 2");
                Console.WriteLine("3. Exercise 3");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose 1-4");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Nhap chuoi: ");
                        string str = Console.ReadLine();
                        Console.WriteLine("Chuoi sau khi format: ");

                        pr.Exercise1(str);
                        break;
                    case 2:
                        Console.WriteLine("Nhap chuoi EMAIL: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Ket qua check email: ");

                        pr.Exercise2(email);
                        break;

                    case 3:
                        Console.WriteLine("Nhap chuoi: ");
                        string strList = Console.ReadLine();
                        Console.WriteLine("Chuoi sau khi sap xep: ");

                        pr.Exercise3(strList);
                        break;
                    case 4:

                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nhap 1 den 4");

                        break;
                }
            } while (menu > 0);


            Console.ReadKey();
        }
    }
}
