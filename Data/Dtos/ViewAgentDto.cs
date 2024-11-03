using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewAgentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

    }
}
