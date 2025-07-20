using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.MVC.Models
{
    public class Songs
    {
        public IList<Music> PastCurrentMusic { get; set; }
        public IList<Music> UpComingMusic { get; set; }
    }
}