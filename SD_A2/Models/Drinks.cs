using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SD_A2.Models
{
    public class Drinks
    {  
        public enum Sizes
        {
            Small,
            Medium,
            Large,
            ExtraLarge
        }
        public enum Flavours
        {
            Orange,
            Wintemelon,
            Apple,
            Banana
        }
        //set validator, getter and setter
        [BindProperty, Required(ErrorMessage = "Please select your cup size")]
        public Sizes DrinkSizes { get; set; }
        
        [Required(ErrorMessage = "Please select your flavour")]
        public Flavours DrinkFlavours { get; set; }

        [Required(ErrorMessage = "Please enter CO2 ratio")]
        [RegularExpression("^[0-9]$|^[1-9][0-9]$|^(100)$", ErrorMessage = "Please enter a valid numbers(0-100)")]
        public string CO2 { get; set; }

        public bool? CO2Num { get; set; }
        public bool? SyrupNum { get; set; }
        public bool? CupNum { get; set; }
        public bool? ChillPlate { get; set; }
        public bool? Acceptance { get; set; }
    }
}
