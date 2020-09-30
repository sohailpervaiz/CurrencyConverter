using System;
namespace dotnet_technical_test.Models.CurrencyConverter
{
    public class API_Response
    {

        public string Base { get; set; }
        public string Date { get; set; }
        public CurrencyRate Rates { get; set; }
    }
}
