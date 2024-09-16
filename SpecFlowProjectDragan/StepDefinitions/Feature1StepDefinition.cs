using RestSharp;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using NUnit.Framework;
using System.IO;
using static SpecFlowProjectDragan.StepDefinitions.Feature1StepDefinitions;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework.Internal.Execution;
namespace SpecFlowProjectDragan.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinitions
    {
       
        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public Category category { get; set; }
            public string name { get; set; }
            public List<string> photoUrls { get; set; }
            public List<Tag> tags { get; set; }
            public string status { get; set; }
        }

        public class Tag
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public static readonly HttpClient client = new HttpClient();
      
       
        [Given(@"post method is provided")]
        public async Task GivenPostMethodIsProvided()
        {

            string url = "https://petstore.swagger.io/v2/pet/";
            var json = PathPlace.jsondata;
            var myobj = JsonConvert.DeserializeObject(json);
            //Console.WriteLine(myobj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Console.WriteLine("status code of post method: " + (int)HttpStatusCode.OK);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }

            Console.WriteLine("wrong");
            var jsonwrong = PathPlace.wrongjsondata;
            var myobjwrong = JsonConvert.DeserializeObject(jsonwrong);
            //Console.WriteLine(myobj);
            var contentwrong = new StringContent(jsonwrong, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responsewrong = await client.PostAsync(url, contentwrong);
                //response.EnsureSuccessStatusCode();
                Assert.AreEqual(400, (int)responsewrong.StatusCode); // status code 400
                Console.WriteLine("status code of wrong post method: " + (int)responsewrong.StatusCode);
               
            }
        }

        [When(@"provide get")]
        public async Task WhenProvideGet()
        {
                
                string url = "https://petstore.swagger.io/v2/pet/11912223922";//id created with post
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    Assert.IsTrue(responseBody.Contains("\"id\":11912223922")); // check with assertion
                    Assert.IsTrue(responseBody.Contains("\"name\":\"doggie dragan\""));// check with assertion
                    Assert.IsTrue(responseBody.Contains("\"status\":\"available\"")); // check with assertion

                }
            
        }
        [Then(@"assertion is successful")]
        public async Task ThenAssertionIsSuccessful()
        {
            Console.WriteLine(" post is checked with get and now deleting is provided");
            string url = "https://petstore.swagger.io/v2/pet/";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url + PathPlace.value);
                response.EnsureSuccessStatusCode();
                Console.WriteLine((int)response.StatusCode);
                Assert.AreEqual(200, (int)response.StatusCode);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
        }
        

        [Given(@"Testing post with class")]
        public async Task GivenTestingPostWithClass()
        {
            

                var pay = new Root
                {
                    id = 1191222393,
                    category = new Category
                    {
                        name = "Agent Name Dragan",
                        id = 1
                    },
                    name = "dragankobahagan",
                    photoUrls = { },
                    status = "available"
                };
                

                string url = "https://petstore.swagger.io/v2/pet/";
                var json = JsonConvert.SerializeObject(pay);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    
                    // response.EnsureSuccessStatusCode();
                    Assert.AreEqual(200, (int)response.StatusCode);
                    Console.WriteLine("post" + response.StatusCode);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Assert.That(responseBody, Does.Contain("\"id\":1191222393"));

                }
            
        }

        [When(@"Implement put")]
        public async Task WhenImplementPut()
        {
            var updatedpay = new Root
            {
                id = 1191222393,
                category = new Category
                {
                    name = "Agent Name Dragan after put",
                    id = 1
                },
                name = "dragankobahagan_put",
                photoUrls = { },
                status = "available"
            };

            string url = "https://petstore.swagger.io/v2/pet/";
            
            var json = PathPlace.jsonupdate;
            //var myobj = JsonConvert.DeserializeObject(updatedpay);
            var myobj = JsonConvert.SerializeObject(updatedpay);
            Console.WriteLine(myobj);
            var content = new StringContent(myobj, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                Console.WriteLine((int)response.StatusCode);
                Assert.AreEqual(200, (int)response.StatusCode);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                // check update with put using get
                
            }

            //string urlapi = "https://petstore.swagger.io/v2/pet/1191222393";//id created with post
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url+ PathPlace.valueDelete);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                Assert.IsTrue(responseBody.Contains("\"id\":1191222393")); // check with assertion
                Assert.IsTrue(responseBody.Contains("\"name\":\"dragankobahagan_put\""));// check with assertion
                Assert.IsTrue(responseBody.Contains("\"status\":\"available\"")); // check with assertion

            }
        }
   

        [Then(@"I can delete")]
        public async Task ThenICanDelete()
        {
           
            string url = "https://petstore.swagger.io/v2/pet/";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url + PathPlace.valueDelete);
                response.EnsureSuccessStatusCode();
                Console.WriteLine((int)response.StatusCode);
                Assert.AreEqual(200, (int)response.StatusCode);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url + PathPlace.valueDelete);
               
                string responseBody = await response.Content.ReadAsStringAsync();
                Assert.AreEqual(404, (int)response.StatusCode);// 404 is status code when try get after delete
                Console.WriteLine(responseBody);
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url + PathPlace.valueDelete);
                Console.WriteLine("st code:" + (int)response.StatusCode);
                Assert.AreEqual(404, (int)response.StatusCode);// 404 is status code when try delete twice

            }


        }
    

    }




}






