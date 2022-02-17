using Doxi.Domain.Models.FrontModels;
using System.Collections.Generic;

namespace Doxi.Domain.Models.RequestResponce
{
    public class GetUserTemplatesResponse
    {
        public IEnumerable<TemplateInfo> UserTemplates { get; set; }

    }
}
