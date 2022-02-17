using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.FrontModels
{
    public class ElementPosition
    {
        [Required]
        public float Top { get; set; }

        [Required]
        public float Left { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public float Height { get; set; }
    }
}