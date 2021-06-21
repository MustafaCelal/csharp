using System.Collections.Generic;
using System.Linq;

namespace ToDoProject
{
    public class BoardManager
    {

        public List<Card> ListBoard()
        {
            return BoardDataBase.Board;
        }

        public void AddCardToBoard(Card card)
        {
            
            BoardDataBase.Board.Add(card);
        }

        public Card FindByTitle(string cardTitle)
        {
            return BoardDataBase.Board.FirstOrDefault(x => x.Title == cardTitle);
        }

        public void RemoveCard(Card card)
        {
            BoardDataBase.Board.Remove(card);
        }

        public void CarryCard(Card card,Status status)
        {
            Card cardShouldCarried = BoardDataBase.Board.Find(x=>x==card);
            cardShouldCarried.Status = status;
        }
    }
}
