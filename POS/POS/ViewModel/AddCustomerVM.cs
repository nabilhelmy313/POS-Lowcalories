using Microsoft.AspNetCore.Http;
using POS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class AddCustomerVM
    {
        public IEnumerable<Zoon> Zoons { get; set; }
        public int ZoonId { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string Flat { get; set; }
        public string Landmark { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Customer Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter Customer Phone")]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public IFormFile Photo { get; set; }
        public string Note { get; set; }
    }
}
