using System;
using System.ComponentModel.DataAnnotations;

namespace albumcollection.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
    }
}