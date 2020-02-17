using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Hero.Models
{
    public class SuperHero
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string AlterEgoName { get; set; }
        public string PrimaryPower { get; set; }
        public string SecondaryPower { get; set; }
        public string CatchPhrase { get; set; }
    }
}
