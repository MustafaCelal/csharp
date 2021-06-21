using System.Collections.Generic;

namespace ToDoProject
{
    public static class BoardDataBase
    {
        public static List<Card> Board;

        static BoardDataBase()
        {
            Board = new List<Card>();
            
            Board.Add(new Card("görev 1", "test 1", 1, Size.L, Status.DONE));
            Board.Add(new Card("görev 2", "test 2", 2, Size.XL, Status.INPROGRESS));
            Board.Add(new Card("görev 3", "test 3", 3, Size.XS, Status.TODO));
        }
    }
}
