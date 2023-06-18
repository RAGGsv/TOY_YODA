using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TOY_YODA.Models
{
    public class TableModel
    {
        public List<SelectListItem> pais { get; set; }
        public int idPais { get; set; }
        public int nombrePais { get; set; }
    }
}