using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class ValuesForWidget
    {
        public int IdValuesWidgets { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalMargin { get; set; }
        public decimal ClosingRatio { get; set; }
        public decimal AverageTicker { get; set; }
        public decimal SalesToLeadPowerRatio { get; set; }
        public decimal TotalLeads { get; set; }
        public decimal ValuePerLead { get; set; }
        public decimal AccountReceivable { get; set; }
        public decimal AccountPayable { get; set; }
    }
}
