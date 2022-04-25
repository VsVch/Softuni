using System.ComponentModel.DataAnnotations;

namespace ASP.netCoreTreningApp.Models.Privacy
{
    public class PrivacyFormModel
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


    }
}
