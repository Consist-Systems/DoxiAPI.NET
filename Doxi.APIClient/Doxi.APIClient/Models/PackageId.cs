using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.RequestResponce
{
    public class PackageId
    {
        [Required]
        public string packageId { get; set; }
    }
}
