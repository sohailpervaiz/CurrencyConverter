using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_technical_test.Controllers.CurrencyConverter
{
    public class CurrencyConverterController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new Models.CurrencyConverter.ConversionModel();
            var codes = GetAllCodes();

            model.ISO_Codes = GetSelectListItems(codes);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Models.CurrencyConverter.ConversionModel model)
        {
            
            var codes = GetAllCodes();
            model.ISO_Codes = GetSelectListItems(codes);

            var rates = GetExchangeRates(model.Base_Currency);

            var exchangeRate = rates.Rates.GetType().GetProperty(model.Exchange_Currency).GetValue(rates.Rates,null);

            var conversionAmount = model.Amount * (double)exchangeRate;


            ViewBag.result = string.Format("{0} {1} = {2} {3}",model.Amount,model.Base_Currency,conversionAmount,model.Exchange_Currency);


            return View(model);
        }


        private Models.CurrencyConverter.API_Response GetExchangeRates(string baseCode)
        {

            try
            {
                string URLString = "https://api.exchangerate-api.com/v4/latest/" + baseCode;

                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);

                    return JsonSerializer.Deserialize<Models.CurrencyConverter.API_Response>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
        private IEnumerable<string> GetAllCodes()
        {
            return new List<string>
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
