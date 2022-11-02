using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class House : IBaseEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
    }
}
