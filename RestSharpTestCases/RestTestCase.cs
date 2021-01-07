using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
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
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Address> dataResponse = JsonConvert.DeserializeObject<List<Address>>(response.Content);
            Assert.AreEqual(4, dataResponse.Count);

            foreach (Address e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.id + " Fname: " + e.firstName + " " + e.lastName);
            }
        }
    }
}
