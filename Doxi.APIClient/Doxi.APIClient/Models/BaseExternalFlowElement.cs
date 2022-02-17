using Doxi.Service.Interfaces.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doxi.Domain.Models.FrontModels
{
    public abstract class BaseExternalFlowElement
    {

        [Required]
        [EnumDataType(typeof(ElementType), ErrorMessage = "Invalid Element Type")]
        public ElementType ElementType { get; set; }
        [EnumDataType(typeof(ElementSubType), ErrorMessage = "Invalid Element Subtype")]
        public ElementSubType ElementSubType { get; set; }

        [Required]
        public int PageNumber { get; set; }

        [Required]
        public ElementPosition Position { get; set; }

        [Obsolete]
        public bool IsEditorElement { get; set; }

        [StringLength(200)]
        public string TextValue { get; set; }

        public int TextSize { get; set; }

        public string TextFont { get; set; }

        public string ElementLabel { get; set; }

        public string ElementHelp { get; set; }

        public string ValueName { get; set; }

        /// <summary>
        /// Right=0,Center=1,Left=2
        /// </summary>
        [EnumDataType(typeof(ExHorizontalAlignment), ErrorMessage = "Invalid Horizontal Alignment")]
        public ExHorizontalAlignment? HorizontalAlignment { get; set; }

        public bool? IsRequired { get; set; }

        public ExValidation[] Validations { get; set; }
        public ExDateTimeValidation DateTimeValidation { get; set; }
        public ExDropDownField[] DropDownList { get; set; }

        public KeyValuePair<string, string>[] AdditionalInfo { get; set; }

        public DuplicateElementInfo DuplicateElementInfo { get; set; }

        [JsonIgnore]
        public bool IsDisableAttachment { get; set; }
    }

    public enum ExHorizontalAlignment
    {
        Right,
        Center,
        Left
    }
}
