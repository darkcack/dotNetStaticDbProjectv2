using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVizev2.Models
{
    public class Novel
    {
       
        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Headliner { get; set; }

        public int categoryId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string translator { get; set; }
        public Category category { get; set; }
       

        public List<Comment> Comment = new List<Comment>();
    }
}