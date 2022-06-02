using System;
using Microsoft.EntityFrameworkCore;
namespace ApiDemo.DBContexts
{
	public class PatientsDataContext : DbContext
	{
		public PatientsDataContext(DbContextOptions<PatientsDataContext> opts) : base(opts)
		{
		}
		public DbSet<Models.PatientInfoModel> Patients => Set<Models.PatientInfoModel>();
	}
}

