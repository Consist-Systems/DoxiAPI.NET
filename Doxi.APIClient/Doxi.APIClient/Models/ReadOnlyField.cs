using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class ReadOnlyField
    {
        [Required]
        public string SignerEmail { get; set; }

        [Required]
        public string ElementLabel { get; set; }

        public string Value { get; set; }

        public int TextSize { get; set; }

        public string TextFont { get; set; }

    }
}
