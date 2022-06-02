using System;
using ApiDemo.Models;

namespace ApiDemo.DataRepositories
{
	public class PatientInfoMemoryRepository:IPatientInfoDataRepository
	{
        List<PatientInfoModel> _storage = new List<PatientInfoModel>();


		public PatientInfoMemoryRepository()
		{
            _storage.AddRange(
                new PatientInfoModel[]
                {
                    new PatientInfoModel{ MRN="M100", Name="Tom",Age=34, PhoneNumber="123456"},
                    new PatientInfoModel{ MRN="M200", Name="Hary",Age=35, PhoneNumber="1234567"},
                }

                ) ;
		}

        public PatientInfoModel Create(PatientInfoModel newPatient)
        {
            _storage.Add(newPatient);
            return newPatient;
        }

        public IEnumerable<PatientInfoModel> GetAllPatients()
        {
            return this._storage;

        }
    }
}

