using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Models
{
    internal class TimeUntilModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long. Must be less than 100 characters.")]
        public string Name { get; set; } = "My Countdown";
        [Required]        
        public DateTime CountdownDate { get; set; } = DateTime.Today.AddDays(7);
        public string AnimationImage { get; set; } = "lottie_hourglass";        
    }

    internal class TimeUntilImages
    {
        public List<string> AnimationImages { get; set; } = new List<string>() {
            "lottie_hourglass",
            "lottie_dude",
            "lottie_cloud"
        };
    }
}
