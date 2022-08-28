using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hale_Terminal.Model;
using Hale_Terminal.Core;

namespace Hale_Terminal.ViewModel
{
    class EquityViewModel : ObservableObject
    { 

        public EquityModel Equity { get; set; }

        public EquityViewModel()
        {
            
            Equity = new EquityModel{
                Ticker = "BA US",
                Name = "BOEING CO/THE",
                Description = "The Boeing Company, together with its subsidiaries, develops, produces, and markets commercial jet aircraft, as well as provides related support services to the commercial airline industry worldwide. The Company also researches, develops, produces, modifies, and supports information, space, and defense systems, including military aircraft",
                CurrentPrice = "131.46",
                PriceChange = "-1.91",
                Spread = "131.38 / 131.39",
                DataTime = "17:03 d",
                Volume = "30,702,692",
                OpenPrice = "127.115",
                HighPrice = "131.50",
                LowPrice = "124.35",
                Valuation = "4.272B",
                PriceChangeDay = "131.46/-1.43%",
                YearWeekHigh = "391.00",
                YearWeekLow = "89.00",
                YTDChange = "-194.30/-59.65%",
                MktCap = "74,186.2M",
                SharesOutstanding = "564.3M/532.7M",
                ShortInterest = "14.6M/2.74%",
                DaysToCover = "0.4",
                Date = "07/24/20",
                PE = "N.A.",
                EstPE = "N.A.",
                TYTDMEPS = "-8.56",
                EstEPS = "-2.98",
                EstPEG = "N.A.",
                IndGrossYield = "N.A.",
                Website = "www.boeing.com",
                HQ = "Chicago, IL, US",
                EmployeeCount = "161,100 (12/31/19)",
                President = "David L Calhoun - Dave",
                VisePresident = "Leanne G Caret",
                SecondVP = "Theodore Colbert III - Ted",
                TotRet = "-64.25%",
                BetaVsSPX = "1.97"
            };
            
            
        }
    }
}
