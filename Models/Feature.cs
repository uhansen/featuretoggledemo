using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models
{
    public class Feature
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
