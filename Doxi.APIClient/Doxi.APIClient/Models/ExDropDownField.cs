using System.Collections.Generic;

namespace Doxi.APIClient
{
    public class ExDropDownField
    {
        public IEnumerable<ExDropDownItem> Values { get; set; }
    }
    public class ExDropDownItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
