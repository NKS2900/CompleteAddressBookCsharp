using System;
using System.Collections.Generic;
namespace AddressBookApp
{
	class AddressBookMain
	{
		public static Dictionary<string, MultipleAddressBook> addressBookDict = new Dictionary<string, MultipleAddressBook>();
		public static void Main(string[] args)
		{

			bool flag = true;

			while (flag)
			{
				Console.WriteLine();
				Console.WriteLine("******WELCOME TO ADDRESS BOOK******");
				Console.WriteLine("1. Create_AddressBooks \n2. Open_AddressBooks \n3. DeletAddressBook \n4. Exit");
				int choice = Convert.ToInt32(Console.ReadLine());
				int size = addressBookDict.Count;
				switch (choice)
				{
					case 1:
						Console.Write("Enter AddressBook Name : ");
						string book = Console.ReadLine();
						bool check = DuplicatAddress(book);
						if (check)
						{
							Console.Write("Enter AddressBook Name again : ");
							book = Console.ReadLine();
						}
						MultipleAddressBook admain = new MultipleAddressBook();
						addressBookDict.Add(book, admain);
						Console.Clear();
						Console.WriteLine("AddressBook_Created successfully...");
						break;
					case 2:
						Console.WriteLine($"you have {size} AddressBook.");

						foreach (var address in addressBookDict)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName : ");
						string bookname = Console.ReadLine();
						int ch = 0;
						foreach (var address in addressBookDict)
						{
							ch++;
							if (addressBookDict.ContainsKey(bookname))
							{
								Console.Clear();
								Console.WriteLine("Opened Address_Book :-->" + bookname);
								MultipleAddressBook.MainMenu();
							}
							else if (size == ch)
							{
								Console.Clear();
								Console.WriteLine("AddressBook not present!!!!!");
							}

						}
						break;
					case 3:
						foreach (var address in addressBookDict)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName  : ");
						string name = Console.ReadLine();

						int signal = 0;
						Console.Clear();
						foreach (var address in addressBookDict)
						{
							signal++;
							if (addressBookDict.Remove(name))
							{
								Console.Clear();
								Console.WriteLine($"Address_Book {name} Deleted...");
								break;
							}
							else if (size == signal)
							{
								Console.Clear();
								Console.WriteLine("AddressBook not present!!!!!");
							}
						}
						break;
					case 4:
						flag = false;
						break;
				}
			}
		}
		public static bool DuplicatAddress(string bookName)
		{
			bool check = false;
			foreach (var address in addressBookDict)
			{

				if (addressBookDict.ContainsKey(bookName))
				{
					check = true;
					Console.Clear();
					Console.WriteLine($"AddressBook-> {bookName} <-alerady presented pls Enter Diff. Name");
					break;
				}
			}
			return check;
		}
	}
}