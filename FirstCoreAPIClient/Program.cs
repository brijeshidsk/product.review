using System.Net;
using FirstCoreAPIClient.Entities;

namespace FirstCoreAPIClient
{
    internal class Program
    {
        static string baseAddress = "https://localhost:7226/";
        static HttpClient client = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyAsyncMethod().GetAwaiter().GetResult();

        }

        static async Task MyAsyncMethod()
        {
            var customer = await getCustomerAsync(3);
            Console.WriteLine($"{customer.Id} | " +
                $"{customer.Firstname} | " +
                $"{customer.Lastname} | "
                );

            var customers = await getAllCustomerAsync();

            foreach (var cust in customers)
            {
                Console.WriteLine($"{cust.Id} | " +
                    $"{cust.Firstname} | " +
                    $"{cust.Lastname} | "
                    );
            }

            var customerToCreate = new Customer
            {
                Firstname = "Brijesh",
                Lastname = "Rawat"
            };

            var loc = await createCustomerAsync(customerToCreate);

            Console.WriteLine($"location {loc}");

            await DeleteCustomerAsync(13);


            var customerToUpdate = new Customer
            {
                Id = 11,
                Firstname = "Brijesh1",
                Lastname = "Rawat1"
            };

            var customerUpdated = await UpdateCustomerAsync(customerToUpdate);

            Console.WriteLine($"Customer {customerUpdated.Firstname}");

        }

        static async Task<Customer> getCustomerAsync(int id)
        {
            Customer customer = null;
            HttpClient client = new HttpClient();
            var path = $"api/Customers/";
            var uri = $"{baseAddress}{path}{id}";
            HttpResponseMessage response = await client.GetAsync(uri); 

            if(response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }

            return customer;

        }

        static async Task<List<Customer>> getAllCustomerAsync()
        {
            List<Customer> customers = null;
            HttpClient client = new HttpClient();
            var path = $"api/Customers";
            var uri = $"{baseAddress}{path}";
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }

            return customers;

        }

        static async Task<Uri> createCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();
            var path = $"api/Customers/";
            var uri = $"{baseAddress}{path}";
            Console.WriteLine($"uri {uri}");
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, customer);
            response.EnsureSuccessStatusCode();

            var location = response.Headers.Location ;
            
            return location;

        }

        static async Task<Customer> UpdateCustomerAsync(Customer customer)
        {

            HttpClient client = new HttpClient();
            var path = $"api/Customers/";
            var uri = $"{baseAddress}{path}{customer.Id}";
            Console.WriteLine($"uri {uri}");

            HttpResponseMessage response = await client.PutAsJsonAsync(uri, customer);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            customer = await response.Content.ReadAsAsync<Customer>();
            return customer;
        }

        static async Task DeleteCustomerAsync(int id)
        {
            HttpClient client = new HttpClient();
            var path = $"api/Customers";
            var uri = $"{baseAddress}{path}/{id}";
            Console.WriteLine($"Delete uri {uri}");

            HttpResponseMessage response = await client.DeleteAsync(uri);

            Console.WriteLine($"Customer with id {id} deleted");
        }

    }
}