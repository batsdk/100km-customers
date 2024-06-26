using System.Text.Json;
using DevUpLink.Entities;

namespace DevUpLink.Helpers
{
    public class InputReader
    {

        public static async Task<List<Customer>> ReadFileAsync(IFormFile file)
        {
            var customers = new List<Customer>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var customer = JsonSerializer.Deserialize<Customer>(line);
                    if (customer != null)
                    {
                        customers.Add(customer);
                    }
                }
            }

            return customers;

        }

    }
}