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
        [Required]                              //validation for view model
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Should be greater than or equal to 1")]
        public int price { get; set; }


    }
}
