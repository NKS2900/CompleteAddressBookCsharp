﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookApp
{
	public class MultipleAddressBook
	{
		public List<ContactPerson> userList;
		public MultipleAddressBook()
		{
			this.userList = new List<ContactPerson>();
		}

		/// <summary>
		/// Adding Contacts in List.
		/// </summary>
		/// <param name="firstName">FirstName</param>
		/// <param name="lastName">LastName</param>
		/// <param name="address">City</param>
		/// <param name="state">State</param>
		/// <param name="contact">Contact no.</param>
		/// <param name="zip">Pincode</param>
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
			List<string> person = new List<string>();
			bool exits = isPlaceExist(place);
			if (exits)
			{
				Console.WriteLine("Contacts From Place: " + place);
				foreach (ContactPerson user in userList.FindAll(x => x.address.Equals(place)).ToList())
				{
					string name = user.firstName + " " + user.lastName;
					person.Add(name);
				}
				foreach (ContactPerson user in userList.FindAll(x => x.state.Equals(place)).ToList())
				{
					string name = user.firstName + " " + user.lastName;
					person.Add(name);
				}
				foreach (string val in person)
				{
					Console.WriteLine(val);
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
		public void CountContact(string countPlace)
		{
			int count = 0;
			bool exits = isPlaceExist(countPlace);
			if (exits)
			{
				Console.WriteLine("Contacts From Place: " + countPlace);
				foreach (ContactPerson user in userList.FindAll(x => x.address.Equals(countPlace)).ToList())
				{
					count++;
				}
				foreach (ContactPerson user in userList.FindAll(x => x.state.Equals(countPlace)).ToList())
				{
					count++;
				}
				Console.WriteLine($"Total Contacts From {countPlace} : {count}");
			}
			else
			{
				Console.WriteLine($"Contect not Found From {0}", countPlace);
			}
		}

		public void SortAlphabetically(int choice1)
		{
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("FirstName    LastName     City     State   Contact      Zip");
			Console.WriteLine("------------------------------------------------------------");
			switch (choice1)
			{
				case 1:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.firstName, y.firstName)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;

				case 2:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.address, y.address)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;

				case 3:
					userList.Sort(new Comparison<ContactPerson>((x, y) => string.Compare(x.state, y.state)));
					foreach (ContactPerson contact in userList)
					{
						contact.print();
					}
					break;
			}
		}
		public void writeInTxtFile()
		{
			FileWriter.WriteUsingStreamWriter(userList);			
		}

		public void readFromTxtFile()
		{
			Console.Clear();
			Console.WriteLine("Contacts_From_Text_File");
			FileWriter.readFile();
		}

		public void writeInCsvFile()
		{
			FileWriter.csvFileWriter(userList);
		}

		public void readFromCsvFile()
		{
			Console.Clear();
			Console.WriteLine("Contacts_From_CSV_File");
			FileWriter.readFromCSVFile();
		}

		public void writeInJsonFile()
		{
			FileWriter.WriteContactsInJSONFile(userList);
		}

		public void readInJsonFile()
		{
			Console.Clear();
			Console.WriteLine("Contacts_From_JsonFile");
			FileWriter.ReadContactsFromJSONFile();
		}
	}
}