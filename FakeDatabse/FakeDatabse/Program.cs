using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDatabse
{
    public class User
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string name { set; get; }
        ICollection<Movie> movies { set; get; }
    }

    public class Movie
    {
        [Key]
        public int id { set; get; }
        [Required]
        public string title { set; get; }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
