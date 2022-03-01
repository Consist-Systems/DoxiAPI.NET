﻿using System;

namespace Doxi.APIClient
{
    public class ExDateTimeValidation
    {
        public string DateTimeFormat { get; set; }
        public bool IsCurrentDateTime { get; set; }
        public DateTime? MinimumDate { get; set; }
        public DateTime? MaximumDate { get; set; }
    }
}