using System;
using System.Collections.Generic;
using System.Linq;

namespace TelefonRehberi
{
    public class PhoneListManager 
    {
        private readonly List<Person> _phoneList=null;
        public PhoneListManager(List<Person> phoneList)
        {
            _phoneList = phoneList;
        }
        public void Add(Person person)
        {
            _phoneList.Add(person);
        }
        public void Add()
        {
            Person person = new Person();
            Console.Write("Lütfen isim giriniz            : ");
            person.Name = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz         : ");
            person.Surname = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz: ");
            person.PhoneNumber = Console.ReadLine();

            _phoneList.Add(person);

        }
        public void Update()
        {
            Console.Write("Lütfen numarısını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string entry = Console.ReadLine();

            Person updatedPerson = _phoneList.FirstOrDefault(x => x.Name == entry || x.Surname == entry);
            if (updatedPerson==null)
            {
                Console.WriteLine("Kişi bulunamadı, Büyük küçük harflere dikkat edin!");
                return;
            }
            Console.Write("{0} kişisinin yeni numarasını giriniz: ", updatedPerson.Name);

            updatedPerson.PhoneNumber = Console.ReadLine();
        }

        public void Delete()
        {
            Console.Write("Lütfen numarısını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string entry = Console.ReadLine();

            Person deletedPerson= _phoneList.FirstOrDefault(x=>x.Name==entry||x.Surname==entry);

            if (deletedPerson == null)
            {
                Console.WriteLine("Kişi bulunamadı, Büyük küçük harflere dikkat edin!");
                return;
            }
            Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)", deletedPerson.Name, deletedPerson.Surname);
            
            string input = Console.ReadLine();

            if (input == "y")
            {
                _phoneList.Remove(deletedPerson);
                Console.WriteLine($"{deletedPerson.Name} rehberden silindi.\n");
            }
            else if (input == "n") { }
            else { Console.WriteLine("Hatalı giriş yaptınız!\n"); }

        }
        public void WriteList()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************");
            
            foreach (Person p in _phoneList)
            {
                Console.WriteLine($"isim: {p.Name}\nsoyisim: {p.Surname}\nTelefon numarası: {p.PhoneNumber}\n");
            }
        }
       
        public void SearchPhoneList()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n"
                            + "*********************************************\n"
                            + "İsim veya soyisime göre arama yapmak için : (1)\n"
                            + "Telefon numarasına göre arama yapmak için : (2)\n");
            
            string entry = Console.ReadLine();

            if (entry == "1")
            {
                Console.Write("İsim veya soyisim giriniz: ");
                string name = Console.ReadLine();

                var person = _phoneList.FirstOrDefault(x => x.Name == name || x.Surname == name);
                if (person == null)
                {
                    Console.WriteLine("Kişi bulunamadı, Büyük küçük harflere dikkat edin!");
                    return;
                }
                Console.WriteLine("İsim: {0}\nSoyisim: {1}\nTelefon Numarası: {2}\n-", person.Name, person.Surname, person.PhoneNumber);
            }
            else if (entry == "2")
            {
                Console.Write("Telefon numarası giriniz: ");
                string phoneNumber = Console.ReadLine();
                if (phoneNumber == null)
                {
                    Console.WriteLine("Böyle biri yok!");
                    return;
                }
                var person = _phoneList.FirstOrDefault(x => x.PhoneNumber == phoneNumber);

                Console.WriteLine("İsim: {0}\nSoyisim: {1}\nTelefon Numarası: {2}\n-", person.Name, person.Surname, person.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız!\n");
            }

        }
    }
}
