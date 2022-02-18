using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class FlowElementSignerData
    {
        public string ElementId { get; set; }

        [StringLength(4000)]
        public string TextData { get; set; }

        // public int TextSize { get; set; }
    }
}
