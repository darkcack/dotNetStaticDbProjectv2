using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVizev2.Models
{
    public class Category
    {
        public int id { get; set; }

        public string Name { get; set; }

        public List<Novel> novels= new List<Novel>();

    }
}