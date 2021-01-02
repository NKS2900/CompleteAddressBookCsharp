using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp
{
	public class ContactPerson
	{
		public String firstName;
		public String lastName;
		public String address;
		public String contact;
		public String state;
		public String zip;

		public ContactPerson(String firstName, String lastName, String address,  String state, String contact, String zip)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.address = address;
			this.contact = contact;
			this.state = state;
			this.zip = zip;
		}
		public void print()
		{
		Console.WriteLine(firstName + " \t  " + lastName +" \t  " + address + " \t  " + state + " \t  " +contact + " \t " + zip); ;
		}
	}
}