using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_ezconet.Models
{
    public class Sexo
    {
        public int SexoId { get; set; }

        [StringLength(15)]
        public String Descricao { get; set; }
    }
}