using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
	public class Contact
	{
		public int ContactId {get; set; }

		[Required]
		[Display(Name = "First Name")]
		public string FirstName {get; set;}

		[Required]
		[Display(Name = "Last Name")]
		public string LastName {get; set; }

		public string Telephone {get; set; }

		[EmailAddress]
		[Display(Name = "Email")]
		public string EmailAddress {get; set; }
		
	}
}