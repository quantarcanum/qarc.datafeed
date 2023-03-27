using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qarc.DataFeed.Core.Domain.Model
{
    public class Instrument
    {
        public string Name { get; set; }
        public string Exchange { get; set; }
        public int TimezoneDifference { get; set; }
        public decimal TickSize { get; set; }
        public decimal TickValue { get; set; }
        public decimal ContractRoundTripFee { get; set; }

        public Instrument(decimal tickValue, decimal contractRoundTripFee)
        {
            this.TickValue = tickValue;
            this.ContractRoundTripFee = contractRoundTripFee;
        }

        // used by automapper; TODO: configure automapper so that you can make the setters private and use propper encapsulation
        public Instrument()
        {
        }
    }
}
