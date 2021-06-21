namespace ToDoProject
{
    public class Card
    {
        public string Title { get ; set ; }
        public string Description { get; set; }
        public int Person { get; set; }
        public Size Size { get; set; }
        public Status Status { get; set; }
        public Card(string title, string description, int person, Size size, Status status = Status.TODO)
        {
            Title = title;
            Description = description;
            Person = person;
            Size = size;
            Status = status;
        }

        public Card()
        {
        }
    }
}
