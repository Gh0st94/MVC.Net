using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    public class Modelo1
    {
        public int Modelo1Id { get; set; }

        public int nombre { get; set; }

        public int cargo { get; set; }
        public int Modelo2Id { get; set; }

        public virtual Modelo2 Modelo2 { get; set; }
    }
}