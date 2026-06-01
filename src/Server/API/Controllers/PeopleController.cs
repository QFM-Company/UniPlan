using Business.DTOs.Requests;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet(Name = "AddNewPerson")]
        public async Task<bool> AddNewPerson(PersonRequest request)
        {
            return await _peopleService.Save(request);
        }
    }
}
