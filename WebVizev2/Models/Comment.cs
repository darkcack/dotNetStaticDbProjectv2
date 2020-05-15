using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVizev2.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string yorum { get; set; }
        public string Yorumİsmi { get; set; }
        public int Novelid { get; set; }
    }
}