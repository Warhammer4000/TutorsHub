using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Entity.BlogModel
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Key { get; set; }
        public bool Private { get; set; }
    }
}