using System;
namespace ApiDemo.DataRepositories
{
	public interface IPatientInfoDataRepository
	{
		Models.PatientInfoModel Create(Models.PatientInfoModel newPatient);
		IEnumerable<Models.PatientInfoModel> GetAllPatients();
	}
}

