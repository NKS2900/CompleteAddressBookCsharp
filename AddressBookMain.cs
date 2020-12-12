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
				Console.WriteLine("******WELCOME TO ADDRESS BOOK******");
				Console.WriteLine("1. Add_Contact \n2.  Exit");
				Console.WriteLine("Enter Your Choice:");
				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						addUser();
						Console.WriteLine("Details Added Successfully. \n");
						break;
					
					case 2:
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
	}
}
