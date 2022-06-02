using System;
using ApiDemo.Models;

namespace ApiDemo.DataRepositories
{
	public class PatientInfoORMRepository:IPatientInfoDataRepository
	{
        DBContexts.PatientsDataContext _context;
        public PatientInfoORMRepository(DBContexts.PatientsDataContext  context)
		{
            this._context = context;
		}

        public PatientInfoModel Create(PatientInfoModel newPatient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientInfoModel> GetAllPatients()
        {
            throw new NotImplementedException();
        }
    }
}

