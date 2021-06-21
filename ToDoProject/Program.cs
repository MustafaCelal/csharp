using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoProject
{
    class Program
    {
        private static readonly BoardManager _boardManager = new BoardManager();

        static void Main()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :\n"
                           + "*******************************************\n"
                           + "(1) Board Listelemek\n"
                           + "(2) Board'a Kart Eklemek\n"
                           + "(3) Board'dan Kart Silmek\n"
                           + "(4) Kart Taşımak\n");

            int input = Convert.ToInt32(Console.ReadLine());

            MenuSecim(input);
        }

        public static void MenuSecim(int choise)
        {
            switch (choise)
            {
                case 1:
                    BoardiListele();
                    break;
                case 2:
                    AddCardToBoard();
                    break;
                case 3:
                    DeleteCardToBoard();
                    break;
                case 4:
                    CardTasi();
                    break;
                default:
                    Console.WriteLine("Böyle bir seçim bulunmamaktadır!");
                    break;
            }

            Main();
        }

        static void BoardiListele()
        {
            List<Card> cards = _boardManager.ListBoard();

            LineListele("ToDo Line",cards.Where(x => x.Status == Status.TODO).ToList());
            LineListele("IN PROGRESS Line",cards.Where(x => x.Status == Status.INPROGRESS).ToList());
            LineListele("DONE Line", cards.Where(x => x.Status == Status.DONE).ToList());

            Main();
        }

        private static void LineListele(string line,List<Card> board)
        {
            Console.WriteLine(line + "\n*****************");

            foreach (var card in board)
            {
                Console.WriteLine("Başlık : " + card.Title);
                Console.WriteLine("İçerik : " + card.Description);
                Console.WriteLine("Atanan Kişi : " + MemberDataBase.FindMember(card.Person).FullName);
                Console.WriteLine("Büyüklük : " + card.Size.ToString());
                Console.WriteLine("--------------------------------------------");
            }
        }

        static void AddCardToBoard()
        {
            Card card = new Card();

            Console.Write("Başlık Giriniz                                    :");
            card.Title = Console.ReadLine();

            Console.Write("İçerik Giriniz                                    :");
            card.Description = Console.ReadLine();

            Console.Write("Büyüklük Giriniz ->  XS(1),S(2),M(3),L(4),XL(5)   :");
            card.Size = (Size)int.Parse(Console.ReadLine());

            Console.Write("Kişi seçiniz                                      :");
            int personId = int.Parse(Console.ReadLine());

            while (MemberDataBase.FindMember(personId) == null)
            {
                Console.WriteLine("Girilen Numarada Kullanıcı Bulunamadı.");
                Console.Write("Kişi seçiniz                                      :");
                personId = int.Parse(Console.ReadLine());
            }

            card.Person = personId;
            card.Status = Status.TODO;
            _boardManager.AddCardToBoard(card);

            Main();
        }

        static void DeleteCardToBoard()
        {
            Console.WriteLine("Öncelikle Silmek İstediğiniz Kartı Seçmeniz Gerekiyor.");
            Console.WriteLine("Lütfen Kart Başlığını Yazınız.");

            var _card = _boardManager.FindByTitle(Console.ReadLine());

            if (_card == null)
            {
                Console.WriteLine("Aradığınız Kart Bulunamadı.");
                Console.WriteLine("Ana Menüye Dön (1)");
                Console.WriteLine("Tekrar Dene (2)");

                int processType = int.Parse(Console.ReadLine());

                if (processType == 1)
                    Main();
                else if (processType == 2)
                    DeleteCardToBoard();
            }

            _boardManager.RemoveCard(_card);

            Main();
        }

        static void CardTasi()
        {
            Console.WriteLine("Öncelikle Taşımak İstediğiniz Kartı Seçmeniz Gerekiyor.");
            Console.WriteLine("Lütfen Kart Başlığını Yazınız.");

            var card = _boardManager.FindByTitle(Console.ReadLine());

            while (card == null)
            {
                Console.WriteLine("Aradığınız Kart Bulunamadı.");
                Console.WriteLine("Ana Menüye Dön (1)");
                Console.WriteLine("Tekrar Dene (2)");

                int input = int.Parse(Console.ReadLine());

                if (input == 1) Main();
                else if (input == 2) { }
                else Console.WriteLine("Hatala giriş!");
                
            }

            Console.WriteLine("Bulunan Kart Bilgileri"
                           + "\n************************************"
                           + "\nBaşlık       : " + card.Title
                           + "\nİçerik       : " + card.Description
                           + "\nAtanan Kişi  : " + MemberDataBase.FindMember(card.Person).FullName
                           + "\nBüyüklük     : " + card.Size.ToString()
                           + "\nLine         : " + (card.Status.ToString()));

            Console.WriteLine("Lütfen Taşımak İstediğiniz Line'ı Seçiniz."
                            + "\n(1) TODO"
                            + "\n(2) IN PROGRESS"
                            + "\n(3) DONE");

            int line = int.Parse(Console.ReadLine());

            if (line < 1 || line > 3)
            {
                Console.WriteLine("Hatalı Seçim Yaptınız.");
                Main();
            }

            _boardManager.CarryCard(card, (Status)line);
            
            Main();
        }
    }
}
