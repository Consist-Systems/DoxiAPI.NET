using Doxi.Service.Interfaces.Enums;

namespace Doxi.Domain.Models
{
    public class ExValidation
    {
        public string Regex { get; set; }
        public ElementValidationError ErrorCode { get; set; }
    }
}
