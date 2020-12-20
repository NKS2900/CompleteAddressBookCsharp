using System;
using System.Collections.Generic;
namespace AddressBookApp
{
	class AddressBookMain
	{

		public static Dictionary<string, MultipleAddressBook> addressBookDict = new Dictionary<string, MultipleAddressBook>();
		public static MultipleAddressBook multiadd = new MultipleAddressBook();
		public static void Main(string[] args)
		{
			bool flag = true;
			while (flag)
			{
				Console.WriteLine();
				Console.WriteLine("********WELCOME TO ADDRESS BOOK********");
				Console.WriteLine("1. Create_AddressBooks \n2. Open_AddressBooks \n3. Count_TotalContacts \n4. Serch_FromAllContact \n5. DeletAddressBook \n6. StoreContactsIn_TextFile \n7. ReadContactsFrom_TextFile \n8. StoreContactsIn_CsvFile \n9. ReadContactsFrom_CsvFile \n10. Exit");
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
						Console.WriteLine($"You have {size} AddressBook.");

						foreach (var address in addressBookDict.Keys)
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
								MainMenu(bookname);
							}
							else if (size == ch)
							{
								Console.Clear();
								Console.WriteLine("AddressBook not present!!!!!");
							}
						}
						break;

					case 3:
						Console.Write("Enter City or State want to Count : ");
						string countplace = Console.ReadLine();
						foreach (var addbook in addressBookDict.Keys)
						{
							Console.WriteLine("Contacts From AddressBook : " + addbook);
							addressBookDict[addbook].CountContact(countplace);
						}
						Console.WriteLine("----------------------------------------");
						break;

					case 4:
						Console.Write("Enter City Or State name U want To Serch : ");
						string place = Console.ReadLine();
						Console.WriteLine("----------------------------------------");
						foreach (var addbook in addressBookDict.Keys)
						{
							Console.WriteLine("Contacts From AddressBook : " + addbook);
							addressBookDict[addbook].SerchContact(place);
							Console.WriteLine("----------------------------------------");
						}
						break;

					case 5:
						Console.WriteLine($"You have {size} AddressBook.");
						foreach (var address in addressBookDict)
						{
							Console.WriteLine(address.Key);
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
					case 6:
						Console.WriteLine($"You have {size} AddressBook.");

						foreach (var address in addressBookDict.Keys)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName : ");
						string addressBokk = Console.ReadLine();
						addressBookDict[addressBokk].writeInTxtFile();
						break;
					case 7:
						Console.WriteLine($"You have {size} AddressBook.");

						foreach (var address in addressBookDict.Keys)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName : ");
						string readContacts = Console.ReadLine();
						addressBookDict[readContacts].readFromTxtFile();
						break;
					case 8:
						Console.WriteLine($"You have {size} AddressBook.");

						foreach (var address in addressBookDict.Keys)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName : ");
						string writeInCsv = Console.ReadLine();
						addressBookDict[writeInCsv].writeInCsvFile();
						break;
					case 9:
						Console.WriteLine($"You have {size} AddressBook.");

						foreach (var address in addressBookDict.Keys)
						{
							Console.WriteLine(address);
						}
						Console.Write("Enter Address_BookName : ");
						string readContact = Console.ReadLine();
						addressBookDict[readContact].readFromCsvFile();
						break;
					case 10:
						flag = false;
						break;
					default:
						Console.WriteLine("Invalid Option...");
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
		public static void addUser(MultipleAddressBook MultAddObj)
		{
			Console.Write("Enter FirstName: ");
			string firstName = Console.ReadLine();
			Console.Write("Enter LastName: ");
			string lastName = Console.ReadLine();
			Console.Write("Enter Address : ");
			string address = Console.ReadLine();
			Console.Write("Enter State : ");
			string state = Console.ReadLine();
			Console.Write("Enter Contact No: ");
			string contact = Console.ReadLine();
			Console.Write("Enter zip : ");
			string zip = Console.ReadLine();
			MultAddObj.AddContact(firstName, lastName, address, state, contact, zip);

		}
		public static void MainMenu(string bookname)
		{

			bool signal = true;
			while (signal)
			{
				Console.WriteLine("******WELCOME TO ADDRESS BOOK******");
				Console.WriteLine("1. Add_Contact \n2. Display_Contact \n3. Delet_Contact \n4. Update_Contact  \n5. Sort_Contacts \n6. Exit");
				Console.WriteLine("Enter Your Choice:");
				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						Console.Clear();
						addUser(addressBookDict[bookname]);
						
						Console.WriteLine("Details Added Successfully. \n");
						break;
					case 2:
						Console.Clear();
						addressBookDict[bookname].Display();
						break;
					case 3:
						Console.Write("Enter FirstName U want to Delet : ");
						string deletName = Console.ReadLine();
						addressBookDict[bookname].DeletContact(deletName);
						break;
					case 4:
						Console.WriteLine("Enter FirstName U want To Update");
						string fname = Console.ReadLine();
						addressBookDict[bookname].EditContact(fname);
						break;
					case 5:
						Console.WriteLine("Chooose option TO Sort Contacts by \n1. FirstName \n2. City \n3. State");
						int option = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("---------------------------");
						Console.WriteLine("Alphabetically_Sorted_List");
						Console.WriteLine("---------------------------");
						switch (option)
						{
							case 1:
								addressBookDict[bookname].SortAlphabetically(1);
								break;
							case 2:
								addressBookDict[bookname].SortAlphabetically(2);
								break;
							case 3:
								addressBookDict[bookname].SortAlphabetically(3);
								break;
							default:
								Console.WriteLine("Invalid option....");
								break;
						}
						Console.WriteLine("---------------------------");
						break;
					case 6:
						signal = false;
						break;
					default:
						Console.WriteLine("Invalid option ???");
						break;
				}
			}
		}
	}
}