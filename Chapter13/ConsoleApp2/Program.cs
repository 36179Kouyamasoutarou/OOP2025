namespace Section01{
    internal class Program {
        static void Main(string[] args) {
            var price = Library.Books
                .Where(b => b.CategoryId == 1)
                .Max(b => b.Price);
            Console.WriteLine(price);

            Console.WriteLine();

            var book = Library.Books
                .Where(b => b.)
        }
    }
}
