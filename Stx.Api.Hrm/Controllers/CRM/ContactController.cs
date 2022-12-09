using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Shared.Bps;
using Stx.Shared.Status;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stx.Api.Hrm.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
	[ApiExplorerSettings(IgnoreApi = Shared.Api.InternalConfig.SwaggerDocs.IsHideLegalApi)]
    public class ContactController : ControllerBase
	{
        private readonly IClientRepository _contactRepository;

        public ContactController(IClientRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult GetAllRecords()
        {
            return Ok(_contactRepository.GetAllRecords());
        }

        [HttpGet("{id}")]
        public IActionResult GetRecordByID(int id)
        {
            return Ok(_contactRepository.GetRecordByID(id));
        }

        [HttpPost]
        public IActionResult UpdateRecord([FromBody] Contact client, EntryState st, string userId)
        {
            if (client == null)
                return BadRequest();

            if (client.FirstName == string.Empty || client.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEmployee = _contactRepository.UpdateRecord(client, st, userId);

            return Created("client", createdEmployee);
        }

    }
}
