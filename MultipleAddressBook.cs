using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookApp
{
	public class MultipleAddressBook
	{
		public  List<ContactPerson> userList;		
		public MultipleAddressBook()
		{
			this.userList = new List<ContactPerson>();
		}
		
		public void AddContact(String firstName, String lastName, String address, String state, String contact, String zip)
		{
			bool duplicate = equals(firstName);
			if (duplicate)
			{
				Console.WriteLine($"Duplicate Contact not allowed '{0}' is already in address book", firstName);
			}
			else
			{
				ContactPerson user = new ContactPerson(firstName, lastName, address, state, contact, zip);
				userList.Add(user);				
			}
		}
		public bool equals(string first_name)
		{
			if (userList.Any(e => e.firstName == first_name))
				return true;
			else
				return false;
		}
		public void Display()
		{
			if (userList.Count() > 0)
			{
				Console.WriteLine("------------------------------------------------------------");
				Console.WriteLine("FirstName    LastName     City     State   Contact      Zip");
				Console.WriteLine("------------------------------------------------------------");
				foreach (ContactPerson cont in userList)
				{
					cont.print();
				}
				Console.WriteLine("------------------------------------------------------------");
			}
			else
			{
				Console.WriteLine("Address_Book is Empty...!!!!!");
			}
		}
					
		public void EditContact(string fname)
		{
			int size = userList.Count;
			int check = 0;
			foreach (ContactPerson user in userList)
			{
				check++;
				if (user.firstName.Equals(fname))
				{
					userList.Remove(user);
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
					Console.WriteLine("Contact Updated Successfully...");
					AddContact(firstName, lastName, address, state, contact, zip);
					break;
				}
				else if (size == check)
				{
					Console.WriteLine(fname + " not found in addressbook...");
					break;
				}
			}
		}
		public void DeletContact(string Fname)
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
					
					break;
				}
				else if (size == check)
				{
					Console.WriteLine(Fname + " not found in addressbook...");
					break;
				}
			}
		}
		public void SerchContact(string place)
		{
			bool exits = isPlaceExist(place);
			if (exits)
			{
				foreach (ContactPerson user in userList.FindAll(x => x.address.Equals(place)).ToList())
				{
					user.print();
				}
				foreach (ContactPerson user in userList.FindAll(x => x.state.Equals(place)).ToList())
				{
					user.print();
				}
			}
			else
			{
				Console.WriteLine($"Contect not Found From {0}", place);			
			}
		}
		public bool isPlaceExist(string place)
		{
			if (this.userList.Any(e => e.address == place) || this.userList.Any(e => e.state == place))
				return true;
			else
				return false;
		}
	}
}