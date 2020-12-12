using System;
using System.Collections.Generic;
namespace AddressBookApp
{
	class AddressBookMain
	{
		public static LinkedList<ContactPerson> userList = new LinkedList<ContactPerson>();
		public static void Main(string[] args)
		{
			bool flag = true;
			while (flag)
			{
				Console.WriteLine("*******WELCOME TO ADDRESS BOOK*******");
				Console.WriteLine("1. Add_Contact\n2. Display_Contact\n3. Update_Contact\n4. Delet_Contact\n5. Exit");
				Console.WriteLine("Enter Your Choice:");
				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						addUser();
						Console.WriteLine("Details Added Successfully. \n");
						break;
					case 2:
						Display();
						break;
					case 3:
						Console.WriteLine("Enter FirstName U want To Update");
						string fname = Console.ReadLine();
						EditContact(fname);
						break;
					case 4:
						Console.Write("Enter FirstName U want to Delet : ");
						string deletName = Console.ReadLine();
						DeletContact(deletName);
						break;
					case 5:
						flag = false;
						break;
					default:
						Console.WriteLine("Invalid option ???");
						break;
				}
			}
		}
		public static void addUser()
		{
			Console.Write("Enter FirstName: ");
			string firstName = Console.ReadLine();
			bool check = CheckContact(firstName);
			if (check)
			{
				Console.Write("Enter FirstName: ");
				firstName = Console.ReadLine();
			}
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
			ContactPerson user = new ContactPerson(firstName, lastName, address, state, contact, zip);
			userList.AddLast(user);
			user.print();
		}
		public static void Display()
		{
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("FirstName    LastName     City     State   Contact      Zip");
			Console.WriteLine("------------------------------------------------------------");
			foreach (var item in userList)
			{
				ContactPerson p = item;
				p.print();
			}
			Console.WriteLine("------------------------------------------------------------");
		}
		public static bool CheckContact(string fname)
		{
			bool check = false;
			foreach (ContactPerson user in userList)
			{
				if (user.firstName.Equals(fname))
				{
					check = true;
					Console.WriteLine($"Contact {fname} alerady presented pls Enter diff. First_Name");
					break;
				}
			}
			return check;
		}
		public static void EditContact(string fname)
		{
			int size = userList.Count;
			int check = 0;
			foreach (ContactPerson user in userList)
			{
				check++;
				if (user.firstName.Equals(fname))
				{
					addUser();
					userList.Remove(user);
					Console.WriteLine("Contact Updated Successfully...");
					break;
				}
				else if (size == check)
				{
					Console.WriteLine(fname + " not found in addressbook...");
					break;
				}
			}
		}
		public static void DeletContact(string Fname)
		{
			int size = userList.Count;
			int check = 0;
			foreach (ContactPerson user in userList)
			{
				check++;
				if (user.firstName.Equals(Fname))
				{
					userList.Remove(user);
					Console.WriteLine("Contact Deleted Successfully...");
					Display();
					break;
				}
				else if (size == check)
				{
					Console.WriteLine(Fname + " not found in addressbook...");
					break;
				}
			}
		}
	}
}
