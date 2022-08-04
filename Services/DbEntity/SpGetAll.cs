using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DbEntity
{
    public class SpGetAll
    {
        
        public int Id { get; set; }
       
        public string? Name { get; set; }

        public string? Position { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

    }
}
