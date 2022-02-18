using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Doxi.APIClient
{
    public class MustHaveOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                if (list.Count > 0)
                    return true;
                else
                {
                    ErrorMessage = "At least one element is required";
                    return false;
                }
            }
            ErrorMessage = "At least one element is required";
            return false;
        }
    }
}