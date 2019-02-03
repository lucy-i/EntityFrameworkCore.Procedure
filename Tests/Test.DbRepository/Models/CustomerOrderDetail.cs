using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test.DbRepository.Models
{
    public class CustomerOrderDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column("No of Orders")]
        public string NoOfOrders { get; set; }
    }
}
