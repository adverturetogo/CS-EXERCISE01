// Program.cs
namespace LibrarySystem
{
    // 定义枚举
    public enum ItemType { Novels, Magazine, TextBook }

    // 定义基类
    public abstract class LibraryItem
    {
        private readonly string _id;
        private readonly string _title;
        
        public string Id => _id;
        public string Title => _title;
        public ItemType Type { get; set; }

        public LibraryItem(string id, string title, ItemType type)
        {
            _id = id;
            _title = title;
            Type = type;
        }

        public abstract string GetDetails();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 测试代码...
            Console.WriteLine("Hello, World!");
        }
    }
}