namespace LibrarySystem.LibrarySystem
{
    public abstract class LibraryItem
    {
        private readonly int _id;
        private readonly string _title;

        public int Id => _id;
        public string Title => _title;
        public ItemType Type { get; set; }

        protected LibraryItem(int id, string title, ItemType type)
        {
            _id = id;
            _title = title;
            Type = type;
        }

        public abstract string GetDetails();
    }
}