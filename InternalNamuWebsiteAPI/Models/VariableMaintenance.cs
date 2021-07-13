using System;
using System.Collections.Generic;

#nullable disable

namespace InternalNamuWebsiteAPI.Models
{
    public partial class VariableMaintenance
    {
        public int Idvariablemaintenance { get; set; }
        public int IdMenuItems { get; set; }
        public int Idtype { get; set; }
        public string Description { get; set; }
        public decimal Valor { get; set; }
    }
}
