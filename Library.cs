class Library {

    List<Book> bookList;
    Dictionary<Book, int> bookAvailableDict;
    Dictionary<Book, int> bookBorrowedDict;


    public Library() {

        bookList = new List<Book>();
        bookAvailableDict = new Dictionary<Book, int>();
        bookBorrowedDict = new Dictionary<Book, int>();

        Book book1 = new Book("Havets datter", "Trine Angelsen");
        bookList.Add(book1);
        bookAvailableDict.Add(book1, 3);
        bookBorrowedDict.Add(book1, 0);

        Book book2 = new Book("Harry Potter", "J.K Rowling");
        bookList.Add(book2);
        bookAvailableDict.Add(book2, 10);
        bookBorrowedDict.Add(book2, 0);

        Book book3 = new Book("Ringenes herre", "J.R.R. Tolkien");
        bookList.Add(book3);
        bookAvailableDict.Add(book3, 10);
        bookBorrowedDict.Add(book3, 0);

    }

    public List<Book> ListAllBooks() {
        return bookList;
    }

    public Book BorrowBook(string title) {
        Book? book = bookList.Find((Book) => { return Book.title == title; });
        if(book == null) {
            return null;
        }

        bookAvailableDict.TryGetValue(book, out int available);
        bookBorrowedDict.TryGetValue(book, out int borrowed);

        if(available > 0) {

            bookAvailableDict[book]--;
            bookBorrowedDict[book]++;

            return book;

        }
        else {
            return null;
        }
        
        
    }

    public void ReturnBook(Book book) {
        bookAvailableDict[book]++;
        bookBorrowedDict[book]--;
        Console.WriteLine("");
        Console.WriteLine($"You returned {book.title}");
        Console.WriteLine("");
    }

}