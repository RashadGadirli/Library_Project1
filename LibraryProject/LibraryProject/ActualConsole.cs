using Library.Business.Exceptions;
using Library.Business.Implementations;
using Library.Data1;
using Library.Core.Entity;
using System.Xml.Linq;
using System.Reflection.Emit;
using static System.Reflection.Metadata.BlobBuilder;



AuthorService a = new AuthorService();
GenreService g = new GenreService();
Data d = new Data();
BookService b = new(a, g);
bool flag = true;
bool flag1 = true;
string hey = "";




int Catcher(string number, int min, int max)
{

    int number1 = default;
    while (true)
    {
        Console.WriteLine("Please enter an integer (-1 to quit)");
        number = Console.ReadLine();

        try
        {
            number1 = Convert.ToInt32(number);
            if (number1 == -1)
            {
                flag1 = false;
                break;
            }
            if (number1 < min || number1 > max)
            {
                Console.WriteLine($"Invalid value (The values between {min} and {max} are allowed) . Try again");
            }
            else
            {
                break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("This input is not integer. Please enter another value");

        }

    }
    return number1;

}
int intCatcher(string number)
{

    int number1 = default;
    while (true)
    {
        Console.WriteLine("Please enter an integer (-1 to quit)");
        number = Console.ReadLine();

        try
        {
            number1 = Convert.ToInt32(number);
            if (number1 == -1)
            {
                flag1 = false;
                break;
            }
            else
            {
                break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("This input is not integer. Please enter another value");

        }

    }
    return number1;

}



while (flag)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Choose an item to make an operation with:\n1. Author\n2. Genre\n3. Book\nPress any other number to quit");
    string operation = default;
    int option = Catcher(operation, 1, 3);
    if (option==-1)
    {
        Console.WriteLine("Operation ended");
    }
    
    if (option == 1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. Create Author\n2. Delete Author\n3. Update Author\n" +
                        "4. Get All Authors\n5.Get all Books by Authors\n6. Get the Author by ID\n"
                        + "============================");
    }
    else if (option == 2)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("7. Create Genre\n8. Delete Genre\n9. Update Genre\n" +
                        "10. Get All Genres\n11. Get the Genre by ID\n"
                        + "============================");
    }
    else if (option == 3)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("12. Create Book\n13. Update Book \n14. Delete Book\n" +
                        "15. Get All Books\n16. Get the Book by ID\n17. Get Books by Name\n18. Get Count of a Book\n" +
                        "19. Get Authors of the Book\n============================");

    }
    else
    {
        flag = false;
    }

    int option1 = Catcher(hey,1,19);
    
    
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Blue;
    switch (option1)
    {
        case -1: 
            {
                break;
            }
        case 1:// Create an author
            {
                Console.WriteLine("Creating an Author...");
                Console.WriteLine("Please input name of the author");
                string name = Console.ReadLine();
                Console.WriteLine("Please input surname of the author");
                string surname = Console.ReadLine();
                try
                {
                    a.Create(name, surname);
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Argument input is null");
                    Console.ResetColor();
                }
                catch (AlreadyExistException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An Author with this id already exists");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Unexpected error");
                    Console.ResetColor();
                }


                break;
            }
        
        case 2: //Delete Author
            {
                Console.WriteLine("Deleting an author...");
                Console.WriteLine("Enter the name of the author you want to delete:");
                string name = Console.ReadLine();
                try
                {
                    var author = a.GetByName(name);
                   
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{author.ID} Name:{author.Name}Surname:{author.Surname}");
                        Console.WriteLine("================================");
                    

                }
                catch(NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (ListNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                    goto case 1;
                    break;
                }

                Console.WriteLine("Deleting an Author...");

                Console.WriteLine("Please enter the Id of the Author");
                
                int id = intCatcher(hey); 
                try
                {
                    a.Delete(id);
                }

                catch (NotFoundException ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An Author with this id does not exist");
                    Console.ResetColor();
                }
                catch( ListNullException ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine(ex.Message);

                }
                break;
            }
        case 3://Update Author
            {
                
                Console.WriteLine("Enter the name of the author you want to update:");
                string name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var author = a.GetByName(name);
                    Console.WriteLine("================================");
                    Console.WriteLine($"ID:{author.ID}\n Name:{author.Name}\n Surname:{author.Surname}");
                    Console.WriteLine("================================");
                    

                }

                catch (ListNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    goto case 1;
                    break;
                }
                catch(NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                Console.WriteLine("Insert the id of the Author you want to update:");
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Update Name\n2. Update Surname\n3. Update Both");
                int option2 = int.Parse(Console.ReadLine());
                switch (option2)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the Updated Name:");
                            string UpdatedName = Console.ReadLine();
                            try
                            {
                                a.UpdateAuthor(id, UpdatedName, "", 1);
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Update cant be null");
                                Console.ResetColor();
                                break;
                            }
                            catch (NotFoundException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An author with the id you inserted does not exist");
                                Console.ResetColor();
                                break;
                            }
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the Updated Surname:");
                            string UpdatedSurName = Console.ReadLine();
                            try
                            {
                                a.UpdateAuthor(id, "", UpdatedSurName, 2);
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Update cant be null");
                                Console.ResetColor();
                                break;
                            }
                            catch (NotFoundException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An author with the id you inserted does not exist");
                                Console.ResetColor();
                                break;
                            }
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("Enter the Updated Name:");
                            string UpdatedName = Console.ReadLine();
                            Console.WriteLine("Enter the Updated Surname:");
                            string UpdatedSurName = Console.ReadLine();
                            try
                            {
                                a.UpdateAuthor(id, UpdatedName, UpdatedSurName, 2);
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Update cant be null");
                                Console.ResetColor();
                            }
                            catch (NotFoundException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An author with the id you inserted does not exist");
                                Console.ResetColor();
                            }
                        }

                        break;
                }
                break;

            }
        case 4:// Get All Authors
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var authors = a.GetAll();
                    foreach (var item in authors)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}Surname:{item.Surname}");
                        Console.WriteLine("================================");
                    }

                }

                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                }
                break;

            }
        case 5://Get All books by Author
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var authors = a.GetAll();
                    foreach (var item in authors)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}Surname:{item.Surname}");
                        Console.WriteLine("================================");
                    }

                }
                catch (ListNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                    goto case 1;
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                }
                break;

            }
        case 6://Get Author by ID
            {
                try
                {
                    var authors = a.GetAll();
                    foreach (var item in authors)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}Surname:{item.Surname}");
                        Console.WriteLine("================================");
                    }
                }
                catch (ListNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                    goto case 1;
                }
                
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Insert the id of the Author:");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    var SpesificAuthor = a.GetById(id);
                }
                catch (NotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An author with this id does not exist");
                    Console.ResetColor();
                }


                break;

            }
        case 7:// Create Genre
            {
                Console.WriteLine("Creating an Genre...");
                Console.WriteLine("Please input name of the Genre");
                string name = Console.ReadLine();

                try
                {
                    g.Create(name);
                }
                
                catch (AlreadyExistException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Genre with this id already exists");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unexpected error");
                    Console.ResetColor();
                }
                break;

            }
        case 8://Delete Genre
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var genres = g.GetAll();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (var item in genres)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}");
                        Console.WriteLine("========================");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no genres created, try to create one first");
                    Console.ResetColor();
                    goto case 7;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Deleting a Genre...");
                Console.WriteLine("Please enter the Id of the Genre");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    g.Delete(id);
                }

                catch (NotFoundException ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Genre with this id does not exist");
                    Console.ResetColor();
                }
            }
            
            break;
    
        

        
        case 9://Update Genre
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var genres = g.GetAll();
                    foreach (var item in genres)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}");
                        Console.WriteLine("========================");
                    }

                }

                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no authors created, try to create one first");
                    Console.ResetColor();
                }
                Console.WriteLine("Insert the id of the Author you want to update:");
                int id1 = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the Updated Name:");
                string UpdatedName = Console.ReadLine();
                try
                {
                    g.UpdateGenre(id1, UpdatedName);
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Update cant be null");
                    Console.ResetColor();
                    break;
                }
                catch (NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A genre with the id you inserted does not exist");
                    Console.ResetColor();
                    break;
                }
                break;

            }
        case 10://Get All Genres
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var genres = g.GetAll();
                    foreach (var item in genres)
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}");
                        Console.WriteLine("========================");
                    }

                }

                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no genres created, try to create one first");
                    Console.ResetColor();
                    goto case 7;
                }
                break;

            }
        case 11://Get Genre by ID
            {
                try
                {
                    var genres = g.GetAll();
                }
                catch(ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no genres created. Try to cerate one first");
                    Console.ResetColor();
                    goto case 7;
                }
                
                Console.WriteLine("Please enter the name of the Genre u want to find");
                int id= int.Parse(Console.ReadLine());
                try
                {
                    var genre = g.GetById(id);
                }
                catch(NotFoundException ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("A Genre with this id does not exist");
                    Console.ResetColor();
                    break;
                }
                
                break;

            }

        case 12://Create Book
            {
                Console.WriteLine("Creating a Book...");
                Console.WriteLine("Please input name of the Book:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the count of the Book:");
                int count = int.Parse(Console.ReadLine());
                Console.WriteLine("How many genres does this book have");
                int genrecount = int.Parse(Console.ReadLine());
                try
                {
                    var genres = g.GetAll();
                    foreach (var item in genres)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}");
                        Console.WriteLine("================================");

                    }
                }

                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This collection is null");
                    Console.WriteLine("Please create a genre first");
                    Console.ResetColor();
                    goto case 7;

                    break;
                }
                List<int> Genres = new List<int>();

                for (int i = 0; i < genrecount; i++)
                {
                    Console.WriteLine($"Please enter the ID of the genre No:{i + 1} of the book");
                    Genres.Add(int.Parse(Console.ReadLine()));
                }

                Console.WriteLine("How many authors does this book have");
                int authorcount = int.Parse(Console.ReadLine());
                try
                {
                    var authors = a.GetAll();
                    foreach (var item in authors)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name}Surname:{item.Surname}");
                        Console.WriteLine("================================");

                    }
                }

                catch (ListNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please create an author first");
                    Console.ResetColor();
                    goto case 1;
                }
                List<int> Authors = new List<int>();

                for (int i = 0; i < authorcount; i++)
                {
                    Console.WriteLine($"Please enter the author No:{i + 1} of the book");
                    Authors.Add(int.Parse(Console.ReadLine()));
                }
                try
                {
                    b.Create(name, count, Authors, Genres);
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Argument input is null");
                    Console.ResetColor();
                    break;
                }
                catch (AlreadyExistException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Genre with this id already exists");
                    Console.ResetColor();
                    break;
                }
                
                break;

            }
        case 13://Update Book
            {
                try
                {
                    var books = b.GetAll();
                }
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please create a book first");
                    Console.ResetColor();
                    goto case 12;

                }
                Console.WriteLine("Updating the book...");
                Console.WriteLine("Please, enter the name of the book you want to update:");
                string name = Console.ReadLine();
                try
                {
                    var book = b.GetByName(name);
                }
                catch (NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A book with the name you entered to update does not exist");
                    Console.ResetColor();
                    break;
                }

                break;

            }
        case 14://Delete Book
            {
                Console.WriteLine();
                try
                {
                    var books = b.GetAll();
                    foreach (var item in books)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name} Count:{item.Count}");
                        Console.WriteLine("================================");
                    }

                }

                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no books created, try to create one first");
                    goto case 12;
                    break;
                }
                Console.WriteLine("Deleting a Book...");

                Console.WriteLine("Please enter the Id of the Book");
                Guid id = Guid.Parse(Console.ReadLine());
                try
                {
                    b.Delete(id);
                }

                catch (NotFoundException ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A book with this id does not exist");
                    Console.ResetColor();
                }
                break;

            }
        case 15:// Get All books
            {
                try
                {
                    var books = b.GetAll();
                    var genres = g.GetAll();
                    var authors = a.GetAll();
                    
                    
                    
                    
                    foreach (var item in books)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        
                        



                        Console.WriteLine("================================");
                        Console.WriteLine($"ID:{item.ID} Name:{item.Name} Count:{item.Count}");
                        Console.WriteLine("================================");

                    }
                }
                catch(ArgumentNullException ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("There are no books created. Try to create one first");
                    Console.ResetColor();
                    goto case 12;
                }
                break;

            }
        case 16://Get the Book by ID
            {
                Console.WriteLine("Enter the Id of the book u want to find");
                Guid id = Guid.Parse(Console.ReadLine());
                try
                {
                    var book = b.GetAll();
                }
                catch(ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no books created. Try to create one first");
                    Console.ResetColor();
                    goto case 12;
                }
            }
                break;

            
        case 17://get books by name
            {
                Console.WriteLine("Please enter the name of the book you are searching");
                string name = Console.ReadLine();
                try
                {
                    var book = b.GetByName(name);
                    Console.WriteLine($"id:{book.ID} name:{book.Name} count:{book.Count}");

                }
                catch (NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                break;

            }
        case 18://Get Count of the book
            {
                Console.WriteLine("Please enter the name of the book you are searching");
                string name = Console.ReadLine();
                try
                {
                    var book = b.GetByName(name);

                }
                catch (NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                break;

            }
        case 19://Get Authors of the Book
            {
                Console.WriteLine("Please enter the name of the book you are searching for:");
                string name = Console.ReadLine();

                try
                {
                    
                    var book = b.GetByName(name);
                    if (book == null)
                    {
                        throw new NotFoundException($"Book with name '{name}' not found.");
                    }

                    List<int> authorsID = book.AuthorId; 
                    List<Author> matchingAuthors = Data.Authors.Where(a => authorsID.Contains(a.ID)).ToList(); 

                    if (matchingAuthors.Count > 0)
                    {
                        foreach (var author in matchingAuthors)
                        {
                            Console.WriteLine($"Author ID: {author.ID}, Author Name: {author.Name} Author Surname:{author.Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No authors found for this book.");
                    }
                }
                catch (NotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

                break;
            }


    }
}

