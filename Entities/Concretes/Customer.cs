using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }

        public override string? ToString()
        {
            return $"CustomerId : {CustomerId}, UserId : {UserId}, CompanyName : {CompanyName}";
        }
    }
}
