using Personal_Finance_Manager_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager_V1.Services
{
    class TransactionService
    {

       

        public static async Task<IEnumerable<Transaction>> getAllIncome()
        {
           var client  = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7209");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Income");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Transaction>>();
            }
            else
            {
                // Error
            }

            return null;
        }

        public static async Task<IEnumerable<Transaction>> getAllExpense()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7278");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Expenses");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Transaction>>();
            }
            else
            {
                // Error
            }

            return null;
        }
    }
}
