using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_technical_test.Models.CurrencyConverter
{
    public class ConversionModel
    {
        public double Amount { get; set; }
        public string Base_Currency { get; set; }
        public string Exchange_Currency { get; set; }

        public IEnumerable<SelectListItem> ISO_Codes { get; set; }
    }
}