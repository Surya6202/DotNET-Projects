using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.MVC.Models
{
    public class Music
    {
        [Key]
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}