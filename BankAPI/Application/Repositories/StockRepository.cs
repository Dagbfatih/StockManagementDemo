using BankAPI.Models;
using CsvHelper;
using System.Globalization;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using CsvHelper.Configuration;

namespace BankAPI.Application.Repositories
{
    public class StockRepository
    {
        private IHostingEnvironment _hostingEnvironment;
        public StockRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // https://www.amcharts.com/demos/stock-chart-candlesticks/#code ex source
        public IList<Stock> GetAll()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (var reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, "data", "example.csv")))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<StockDbModel>();
                IList<Stock> result = records.Select(s => new Stock
                {
                    Amount = s.Amount,
                    Close = s.Close,
                    Date = s.Date,
                    High = s.High,
                    Low = s.Low,
                    Open = s.Open,
                    Volume = s.Volume
                }).OrderBy(s => s.Date).ToList();
                return result;
            }
        }
    }
}
