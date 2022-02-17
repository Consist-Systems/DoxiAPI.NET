namespace Doxi.Domain.Models.FrontModels
{
    public class TemplateInfo
    {
        public TemplateInfo(string templateId, string templateName)
        {
            TemplateId = templateId;
            TemplateName = templateName;
        }

        public string TemplateId { get; set; }
        public string TemplateName { get; set; }
    }
}
