using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hale_Terminal.Model
{
    class EquityModel
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentPrice { get; set; }
        public string PriceChange { get; set; }

        public string Spread { get; set; }

        public string DataTime { get; set; }
        public string Volume { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string Valuation { get; set; }
        public string PriceChangeDay { get; set; }
        public string YearWeekHigh { get; set; }
        public string YearWeekLow { get; set; }
        public string YTDChange { get; set; }
        public string MktCap { get; set; }
        public string SharesOutstanding { get; set; }
        public string ShortInterest { get; set; }
        public string DaysToCover { get; set; }
        public string Date { get; set; }
        public string PE { get; set; }
        public string EstPE { get; set; }
        public string TYTDMEPS { get; set; }
        public string EstEPS { get; set; }
        public string EstPEG { get; set; }
        public string IndGrossYield { get; set; }
        public string Website { get; set; }
        public string HQ { get; set; }
        public string EmployeeCount { get; set; }
        public string President { get; set; }
        public string VisePresident { get; set; }
        public string SecondVP { get; set; }
        public string TotRet { get; set; }
        public string BetaVsSPX { get; set; }
    }
}
