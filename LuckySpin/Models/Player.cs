using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player //DONE: Annotate the Player properties as described in section 3.
    {
        [Required(ErrorMessage = "Please enter your Name")]
        public string FirstName { get; set; }

        [Range(1,9, ErrorMessage = "Choose a number")]
        public int Luck { get; set; }
    }
}