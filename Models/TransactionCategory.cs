using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager_V1.Models
{
    public class TransactionCategory
    {
        public string Name { get; set; }

        public TransactionCategory(string n) 
        { 
            this.Name = n;
        }
    }
}
