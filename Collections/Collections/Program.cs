using Collections;

Phone phonebook = new Phone();

phonebook.AddDefaultNumbers();

while (true)
{
    Console.WriteLine("Please choose the operation:");
    Console.WriteLine("*******************************************");
    Console.WriteLine("1.Add New Number");
    Console.WriteLine("2.Delete Existing Number");
    Console.WriteLine("3.Update Existing Number");
    Console.WriteLine("4.List Phonebook");
    Console.WriteLine("5.Search in Phonebook");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            phonebook.AddNewNumber();
            break;
        case 2:
            phonebook.DeleteNumber();
            break;
        case 3:
            phonebook.UpdateNumber();
            break;
        case 4:
            phonebook.ListPhonebook();
            break;
        case 5:
            phonebook.SearchInPhonebook();
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

