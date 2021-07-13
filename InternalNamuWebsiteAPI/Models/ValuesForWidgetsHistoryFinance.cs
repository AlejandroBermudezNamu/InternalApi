using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class ValuesForWidgetsHistoryFinance
    {
        public int IdValuesWidgets { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal AccountReceivable { get; set; }
        public decimal AccountPayable { get; set; }
        public int Numero { get; set; }
    }
}
