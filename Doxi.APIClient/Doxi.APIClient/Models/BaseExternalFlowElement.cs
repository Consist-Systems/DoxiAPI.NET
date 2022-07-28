
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Doxi.APIClient
{
    public abstract class BaseExternalFlowElement
    {

        
        
        public ElementType ElementType { get; set; }
        
        public ElementSubType ElementSubType { get; set; }

        
        public int PageNumber { get; set; }

        
        public ElementPosition Position { get; set; }

        [Obsolete]
        public bool IsEditorElement { get; set; }

       
        public string TextValue { get; set; }

        public int TextSize { get; set; }

        public string TextFont { get; set; }

        public string ElementLabel { get; set; }

        public string ElementHelp { get; set; }

        public string ValueName { get; set; }

        /// <summary>
        /// Right=0,Center=1,Left=2
        /// </summary>
        
        public ExHorizontalAlignment? HorizontalAlignment { get; set; }

        public bool? IsRequired { get; set; }

        public ExValidation[] Validations { get; set; }
        public ExDateTimeValidation DateTimeValidation { get; set; }
        public ExDropDownField[] DropDownList { get; set; }

        public KeyValuePair<string, string>[] AdditionalInfo { get; set; }

        public DuplicateElementInfo DuplicateElementInfo { get; set; }

        [JsonIgnore]
        public bool IsDisableAttachment { get; set; }

        public string ElementId { get; set; }
    }

    public enum ExHorizontalAlignment
    {
        Right,
        Center,
        Left
    }
}
