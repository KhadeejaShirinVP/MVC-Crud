using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Book_ViewModel
    {
        [Key]
        public int Book_ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int price { get; set; }


    }
}
