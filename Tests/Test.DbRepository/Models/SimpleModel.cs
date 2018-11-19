using System;
using System.Collections.Generic;
using System.Text;

namespace Test.DbRepository.Models
{
    public class SimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Key  { get; set; }
        public DateTime UpdatedDate { get; set; }
        public TimeSpan RefreshTime { get; set; }
    }
}
