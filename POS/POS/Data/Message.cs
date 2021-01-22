using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public DateTime MessageDate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Branch Branch { get; set; }
        public int BId { get; set; }

    }
}
