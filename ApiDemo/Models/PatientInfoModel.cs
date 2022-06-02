using System;
using System.ComponentModel.DataAnnotations;
namespace ApiDemo.Models
{
	public class PatientInfoModel
	{
		[Key]
		public string MRN { get; set; }
		public string? Name{ get; set; }
		public int  Age{ get; set; }
		public string? PhoneNumber { get; set; }
	}
}

