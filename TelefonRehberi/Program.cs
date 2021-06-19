using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneListManager phoneList = new PhoneListManager(new List<Person>());
            
            phoneList.Add(new Person { Name = "Ali", Surname = "Dayı", PhoneNumber = "555 555 55 55" });
            phoneList.Add(new Person { Name = "Veli", Surname = "Hoca", PhoneNumber = "444 555 55 55" });
            phoneList.Add(new Person { Name = "Ayşe", Surname = "Teyze", PhoneNumber = "333 555 55 55" });
            phoneList.Add(new Person { Name = "Fatma", Surname = "Nine", PhoneNumber = "222 555 55 55" });
            phoneList.Add(new Person { Name = "Mehmet", Surname = "Ağa", PhoneNumber = "111 555 55 55" });


            while (true)
            {
                Menu();

                int entry = Convert.ToInt32(Console.ReadLine());

                switch (entry)
                {
                    case 1:
                        phoneList.Add();
                        break;

                    case 2:
                        phoneList.Delete();
                        break;

                    case 3:
                        phoneList.Update();
                        break;

                    case 4:
                        phoneList.WriteList();
                        break;

                    case 5:
                        phoneList.SearchPhoneList();
                        break;

                    default:
                        Console.WriteLine("Hatalı giriş yaptınız!\n");
                        break;
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncellemek\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak\n");
            Console.Write("İşlem tercihiniz: ");
        }
    }
}
