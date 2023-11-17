using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Phone
    {
        private List<Person> phonebook;

        public Phone()
        {
            phonebook = new List<Person>();
        }

        public void AddDefaultNumbers()
        {
            phonebook.Add(new Person { Name = "Tofiq", Surname = "Nasibli", PhoneNumber = "050-770-6777" });
            phonebook.Add(new Person { Name = "Mariam", Surname = "Aliyeva", PhoneNumber = "051-770-6777" });
            phonebook.Add(new Person { Name = "HaciAga", Surname = "Ahmedov", PhoneNumber = "070-770-6777" });
            phonebook.Add(new Person { Name = "Michael", Surname = "Jacksen", PhoneNumber = "077-770-6777" });
            phonebook.Add(new Person { Name = "Ali", Surname = "Huseynov", PhoneNumber = "010-770-6777" });
        }

        public void AddNewNumber()
        {
            Console.WriteLine("Please enter the Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter the Surname:");
            string surname = Console.ReadLine();
            t:
            Console.WriteLine("Please enter the Phone Number:");
                string phoneNumber = Console.ReadLine();
            if (phoneNumber.Length!=10)
            {
                Console.WriteLine("Wrong input Try again: ");
                goto t;
            }

            phonebook.Add(new Person { Name = name, Surname = surname, PhoneNumber = phoneNumber });

            Console.WriteLine("Number successfully added!");
        }

        public void DeleteNumber()
        {
            Console.WriteLine("Please enter the name or surname of the person you want to delete:");
            string searchTerm = Console.ReadLine();

            Person personToDelete = phonebook.FirstOrDefault(person => person.Name.Contains(searchTerm) || person.Surname.Contains(searchTerm));

            if (personToDelete == null)
            {
                Console.WriteLine("No data found in the phonebook. Please choose an option:");
                Console.WriteLine("1.To end deletion              2. To try again");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    return;
                }
                else if (choice == 2)
                {
                    DeleteNumber();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Ending the process.");
                }
            }
            else
            {
                Console.WriteLine($"Do you confirm deleting {personToDelete.Name}? (y/n)");

                string confirmation = Console.ReadLine();

                if (confirmation.ToLower() == "y")
                {
                    phonebook.Remove(personToDelete);
                    Console.WriteLine("Person successfully deleted!");
                }
                else if (confirmation.ToLower() == "n")

                {
                    Console.WriteLine("Delet canceled.");
                }
            }
        }

        public void UpdateNumber()
        {
            Console.WriteLine("Please enter the name or surname of the person you want to update:");
            string searchTerm = Console.ReadLine();

            Person personToUpdate = phonebook.FirstOrDefault(person => person.Name.Contains(searchTerm) || person.Surname.Contains(searchTerm));

            if (personToUpdate == null)
            {
                Console.WriteLine("No data matching the criteria found in the phonebook. Please choose an option:");
                Console.WriteLine("1.To end updating     2.To try again");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    return;
                }
                else if (choice == 2)
                {
                    UpdateNumber();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Ending the process.");
                }
            }
            else
            {
                Console.WriteLine($"Please enter the new phone number (current number: {personToUpdate.PhoneNumber}):");
                string newPhoneNumber = Console.ReadLine();

                personToUpdate.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Number successfully updated!");
            }
        }

        public void ListPhonebook()
        {
            Console.WriteLine("Phonebook");
            Console.WriteLine("**********************************************");

            foreach (Person person in phonebook)
            {
                Console.WriteLine($"Name: {person.Name} Surname: {person.Surname} Phone Number: {person.PhoneNumber}");
            }

            Console.WriteLine("**********************************************");
        }

        public void SearchInPhonebook()
        {
            Console.WriteLine("Choose the type of search:");
            Console.WriteLine("**********************************************");
            Console.WriteLine("To search by name or surname: 1    To search by phone number: 2");

            string searchType = Console.ReadLine();

            if (searchType == "1")
            {
                Console.WriteLine("Please enter the name or surname to search:");
                string searchTerm = Console.ReadLine();

                var searchResults = phonebook.Where(person => person.Name.Contains(searchTerm) || person.Surname.Contains(searchTerm));

                DisplaySearchResults(searchResults);
            }
            else if (searchType == "2")
            {
                Console.WriteLine("Please enter the phone number to search:");
                string searchTerm = Console.ReadLine();

                var searchResults = phonebook.Where(person => person.PhoneNumber.Contains(searchTerm));

                DisplaySearchResults(searchResults);
            }
            else
            {
                Console.WriteLine("Invalid choice. Ending the process.");
            }
        }

        private static void DisplaySearchResults(IEnumerable<Person> searchResults)
        {
            Console.WriteLine("Search Results:");
            Console.WriteLine("*****************************************");

            foreach (Person person in searchResults)
            {
                Console.WriteLine($"Name: {person.Name} Surname: {person.Surname} Phone Number: {person.PhoneNumber}");
            }
        }
    }

}
