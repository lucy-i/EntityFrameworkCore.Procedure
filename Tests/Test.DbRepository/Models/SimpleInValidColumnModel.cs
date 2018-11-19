using System;
using System.Collections.Generic;
using System.Text;

namespace Test.DbRepository.Models
{
    public class SimpleInValidColumnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Key { get; set; }
        public DateTime Updated_Date { get; set; }
        public TimeSpan Refresh_Time { get; set; }
    }
}
