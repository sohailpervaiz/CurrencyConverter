﻿using System;
namespace dotnet_technical_test.Models.CurrencyConverter
{
    public class ISO_Currency
    {
        public string[] ISO_Codes { get; set; }

        ISO_Currency()
        {
            this.ISO_Codes = new[]
            {
                "USD",
                "AED",
                "ARS",
                "AUD",
                "BGN",
                "BRL",
                "BSD",
                "CAD",
                "CHF",
                "CLP",
                "CNY",
                "COP",
                "CZK",
                "DKK",
                "DOP",
                "EGP",
                "EUR",
                "FJD",
                "GBP",
                "GTQ",
                "HKD",
                "HRK",
                "HUF",
                "IDR",
                "ILS",
                "INR",
                "ISK",
                "JPY",
                "KRW",
                "KZT",
                "MVR",
                "MXN",
                "MYR",
                "NOK",
                "NZD",
                "PAB",
                "PEN",
                "PHP",
                "PKR",
                "PLN",
                "PYG",
                "RON",
                "RUB",
                "SAR",
                "SEK",
                "SGD"
            };
        }
    }
}
