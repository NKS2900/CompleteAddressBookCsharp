using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookApp;
using System;

namespace AddressBookTest
{
    [TestClass]
    public class AddressBookTestCase
    {
        /// <summary>
        /// Check Connection Established With database or not
        /// </summary>
        [TestMethod]
        public void ChekConnection()
        {
            AddressBookRepo addressbookrepo = new AddressBookRepo();
            bool result = addressbookrepo.EstablishConnection();
            bool expect = true;
            Assert.AreEqual(result, expect);
        }

        /// <summary>
        /// Given AddressBook_DB when Retrive then return Count of contact.
        /// </summary>
        [TestMethod]
        public void GivenAddressBookDB_WhenRetrieve_ThenReturnContactsFromDataBase()
        {
            AddressBookRepo addressbookrepo = new AddressBookRepo();
            int result = addressbookrepo.RetrieveContactFromPerticularAddressBook();
            int expect = 11;
            Assert.AreEqual(result, expect);
        }

        /// <summary>
        /// Givens the address books when enter first name then should update contact in address book.
        /// </summary>
        [TestMethod]
        public void GivenAddressBooks_WhenEnterFirstName_ThenShouldUpdateContactInAddressBook()
        {
            bool expected = true;
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel editModel = new AddressBookModel()
            {
                First_Name = "Dipak",
                Last_Name = "Nagar",
                City = "Latur",
                State = "Maharashtra",
                Email = "dpk@gmail.com",
                BookName = "address002",
                AddressbookType = "office"
            };
            bool result = addrepo.EditContactUsingFirstName(editModel);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Get Contacts between given range
        /// </summary>
        [TestMethod]
        public void GivenContactInsertDate_ThenReturnTotalEmployeeBetweenRange()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            int count = addrepo.getContactDataWithGivenDate();
            int expected = 5;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Retrive contacts from City or State.
        /// </summary>
        [TestMethod]
        public void GivenAddressBook_returnNumberOf_ContactsFromPerticularCityOrState()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            int count = addrepo.RetrieveContactFromPerticularCityOrState();
            int expected = 7;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// add new contact in addressbook
        /// </summary>
        [TestMethod]
        public void GivenAddressBooks_AddNewRecord_ThenShouldAddContactInAddressBook()
        {
            bool expected = true;
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel addModel = new AddressBookModel()
            {
                First_Name = "mangesh",
                Last_Name = "joshi",
                Address = "DangeChoak",
                City = "Latur",
                State = "Maharashtra",
                Email = "dpk@gmail.com",
                BookName = "address002",
                AddressbookType = "office",
                Zip = "145236",
                Phone_Number = "1478523690",
                idate = new DateTime(2010, 11, 02)
            };
            bool result = addrepo.AddContact(addModel);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Calculating required time to adding new contact in database
        /// </summary>
        [TestMethod]
        public void GivenData_WhenAddedInDatabase_ThenCalculateRequiredTime()
        {
            AddressBookRepo addrepo = new AddressBookRepo();
            AddressBookModel addModel = new AddressBookModel()
            {
                First_Name = "manish",
                Last_Name = "pathak",
                Address = "DChoak",
                City = "Aalandi",
                State = "Maharashtra",
                Email = "mkda@gmail.com",
                BookName = "address002",
                AddressbookType = "office",
                Zip = "145236",
                Phone_Number = "1478523690",
                idate = new DateTime(2010, 11, 02)
            };
            DateTime startTime = DateTime.Now;
            addrepo.AddContact(addModel);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine($"Duration taken for insertion is {0}", (stopTime - startTime));
        }
    }
}
