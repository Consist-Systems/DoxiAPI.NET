using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.FrontModels
{
    public class FlowElementSignerData
    {
        public string ElementId { get; set; }

        [StringLength(4000)]
        public string TextData { get; set; }

        // public int TextSize { get; set; }
    }
}
