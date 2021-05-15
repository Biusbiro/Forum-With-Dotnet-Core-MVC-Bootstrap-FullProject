using System.ComponentModel.DataAnnotations;

namespace Forum_API_BackEnd.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage="Este campo não pode ter mais do que 100 caracteres")]
        [MinLength(1, ErrorMessage="Este campo deve ser preenchido")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
}