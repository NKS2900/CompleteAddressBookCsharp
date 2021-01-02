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
        
    }
}
