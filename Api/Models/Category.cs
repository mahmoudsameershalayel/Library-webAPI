using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
       
    }
}
