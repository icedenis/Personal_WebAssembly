using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_WebAssembly.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }

        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }
        //need to add to its same as the DTO in thr API
        public string Fileimg { get; set; }
    }
}
