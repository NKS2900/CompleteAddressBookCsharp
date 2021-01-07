using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTestCases
{
    public class Address
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

    }

    [TestClass]
    public class RestTestCase
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/address", Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Retrive all Contacts from Json_Server using Rest_api.
        /// </summary>
        [TestMethod]
        public void OnCallingGETApi_ReturnContactList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Address> dataResponse = JsonConvert.DeserializeObject<List<Address>>(response.Content);
            Assert.AreEqual(8, dataResponse.Count);

            foreach (Address e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.id + " Fname: " + e.firstName + " " + e.lastName);
            }
        }

        /// <summary>
        /// adding multiple contact to json_server using restSharp_api
        /// </summary>
        [TestMethod]
        public void givenContact_OnPost_ShouldReturnAddedContact()
        {
            List<Address> addressList = new List<Address>();
            addressList.Add(new Address { firstName = "Vivek", lastName = "Jadhav", address="Beed", contact="7896541230", state="MAHA", zip="789654" });
            addressList.Add(new Address { firstName = "Ajay", lastName = "Kamble", address = "Latur", contact = "4196541230", state = "MAHA", zip = "896547" });
            addressList.Add(new Address { firstName = "Pandit", lastName = "Walde", address = "Parli", contact = "8896541230", state = "MAHA", zip = "236541" });
            addressList.Add(new Address { firstName = "Swati", lastName = "Mali", address = "Pune", contact = "9896541230", state = "MAHA", zip = "895623" });

            addressList.ForEach(addressData =>
            {
                RestRequest request = new RestRequest("/address", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("firstName", addressData.firstName);
                jObjectBody.Add("lastName", addressData.lastName);
                jObjectBody.Add("address", addressData.address);
                jObjectBody.Add("contact", addressData.contact);
                jObjectBody.Add("state", addressData.state);
                jObjectBody.Add("zip", addressData.zip);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Address dataResorce = JsonConvert.DeserializeObject<Address>(response.Content);
                Assert.AreEqual(addressData.firstName, dataResorce.firstName);
                Assert.AreEqual(addressData.lastName, dataResorce.lastName);
                Console.WriteLine(response.Content);
            });

            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Address> dataResorce = JsonConvert.DeserializeObject<List<Address>>(response.Content);
            Assert.AreEqual(8, dataResorce.Count);
        }
    }
}
