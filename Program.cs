List<Book> myBorrowedBookList = new List<Book>();

Library library = new Library();


Console.WriteLine("Welcome to the library!");
while(true) {

    Console.WriteLine("Choose an action: 'list' 'borrow' 'return' 'mybooks' ");
    string? userInput = Console.ReadLine();


switch (userInput)
{
    case "list": 
        
        List<Book> bookList = library.ListAllBooks();
        Console.WriteLine("");
        Console.WriteLine("Our Complete book list");

        foreach(var thisBook in bookList) {
            Console.WriteLine($"Title: {thisBook.title} - Author: {thisBook.author}");
            
        }

        Console.WriteLine("");
        break;
    case "borrow": 
        Console.WriteLine("What book do you want to borrow?");
        string? bookTitle = Console.ReadLine();

        if(bookTitle.Length < 1) {
            
            Console.WriteLine("Empty book title..");
            Console.WriteLine("");
            
            
        }

        Book? book = library.BorrowBook(bookTitle);
        if(book != null) {
            myBorrowedBookList.Add(book);
            Console.WriteLine("");
            Console.WriteLine($"You borrowed the book {book.title}");
            Console.WriteLine("");
            
        }

        break;
    case "return":
        Console.WriteLine("Which book do you want to return?");
        bookTitle = Console.ReadLine();

        if(bookTitle.Length < 1) {
            
            Console.WriteLine("No title was given..");
            Console.WriteLine("");
            
        }
        else {
            book = null;
            book = myBorrowedBookList.Find((Book) => { return Book.title == bookTitle; });
            if(book != null) {
                library.ReturnBook(book);
                myBorrowedBookList.Remove(book);
            }
            else {
                Console.WriteLine("");
                Console.WriteLine("You have not burrowed this book.. \n ");
                
            }
        }

        



        //Book? myBook = myBorrowedBookList.Find(book => book.title == bookTitle);
        break;
    case "mybooks": 
        Console.WriteLine("Your borrowed books:");
        Console.WriteLine("");
        foreach (var mybook in myBorrowedBookList) {
            Console.WriteLine($"Title: {mybook.title} - Author: {mybook.author}");
        }
        Console.WriteLine("");
        break;
    default:
        Console.WriteLine("");
        Console.WriteLine("Unrecionized action!");
        Console.WriteLine("");
        break;
}
    


}

