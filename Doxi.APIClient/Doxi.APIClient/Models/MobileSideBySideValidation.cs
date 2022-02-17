using Doxi.Domain.Models.FrontModels;
using Doxi.Service.Interfaces.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Doxi.Domain.Attributes
{
    public class MobileSideBySideValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IEnumerable<BaseExternalFlowElement> FlowElements = value as IEnumerable<BaseExternalFlowElement>;

            if (FlowElements == null)
                return true;

            bool isSideBySide = !FlowElements.Any(x => x.ElementType != ElementType.Sign && string.IsNullOrEmpty(x.ElementLabel));

            if (isSideBySide)
            {
                bool notValid = FlowElements.Any(x => (x.ElementType == ElementType.Checkbox || x.ElementType == ElementType.Radio)
                                && string.IsNullOrEmpty(x.ValueName));

                if (notValid)
                {
                    ErrorMessage = "Checkbox or radio elements must have value Name on side by side view";
                    return false;
                }
            }

            return true;
        }
    }
}
