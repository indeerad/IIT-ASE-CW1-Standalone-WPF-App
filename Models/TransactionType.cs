using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager_V1.Models
{
    public class TransactionType
    {
        public string Name { get; set; }

        public TransactionType(string name) 
        { 
            this.Name = name;
        }

        
    }
}
