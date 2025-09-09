namespace LibrarySystem.LibrarySystem
{
    public class TextBook : LibraryItem
    {
        private readonly string _publisher;
        public string Publisher => _publisher;

        public TextBook(int id, string title, string publisher)
            : base(id, title, ItemType.TextBook)
        {
            _publisher = publisher;
        }

        public override string GetDetails()
            => $"TextBook: {Title} (ID: {Id}), Publisher: {Publisher}";
    }
}