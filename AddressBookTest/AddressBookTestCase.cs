using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookApp;
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
            AddressBookModel editModel = new AddressBookModel();
            editModel.First_Name = "Dipak";
            editModel.Last_Name = "Nagar";
            editModel.City = "Latur";
            editModel.State = "Maharashtra";
            editModel.Email = "dpk@gmail.com";
            editModel.BookName = "address002";
            editModel.AddressbookType = "office";
            bool result=addrepo.EditContactUsingFirstName(editModel);
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
            AddressBookModel addModel = new AddressBookModel();
            addModel.First_Name = "mangesh";
            addModel.Last_Name = "joshi";
            addModel.City = "Latur";
            addModel.State = "Maharashtra";
            addModel.Email = "dpk@gmail.com";
            addModel.BookName = "address002";
            addModel.AddressbookType = "office";
            addModel.idate= new System.DateTime(2010, 11, 02);
            bool result = addrepo.EditContactUsingFirstName(addModel);
            Assert.AreEqual(expected, result);
        }
    }
}
