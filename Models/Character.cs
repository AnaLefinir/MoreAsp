using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoreAsp.Models
{
    public class Character
    {
        public string Name { get; set; }
        //The attribute Display set the display name of our property, which tells asp-for 
        //what you want the label to show.
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        //Making a List of Equipment in our Character class will create the relationship
        //between Character and Equipment
        public List<Equipment> Equipment { get; set; }
    }
} 