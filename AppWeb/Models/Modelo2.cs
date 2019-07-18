using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    public class Modelo2
    {
        public int Modelo2Id { get; set; }
        public int cargo { get; set; }
        public int cedula { get; set; }
        public virtual ICollection<Modelo1> Modelo1 { get; set; }
    }
}