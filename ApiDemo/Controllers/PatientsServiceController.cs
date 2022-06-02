using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    //http://localhost:5119/api/PatientsService

    [Route("api/[controller]")]
    public class PatientsServiceController : Controller
    {
        DataRepositories.IPatientInfoDataRepository _repository;

        public PatientsServiceController(DataRepositories.IPatientInfoDataRepository repository)
        {
            this._repository = repository;
        }
        // GET: api/values
        //Action
        //
        [HttpGet]
        public IEnumerable<Models.PatientInfoModel>  Get()
        {
            IEnumerable<Models.PatientInfoModel> patientsInfo = _repository.GetAllPatients();
            return patientsInfo;
        }

        /* GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/values
        [HttpPost]
        public Models.PatientInfoModel Post([FromBody]Models.PatientInfoModel newPatient)
        {
            return _repository.Create(newPatient);
        }

        /* PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

