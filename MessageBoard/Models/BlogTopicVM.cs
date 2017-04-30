using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class BlogTopicVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageThumbnail { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}