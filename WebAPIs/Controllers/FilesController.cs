using AutoMapper;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.ViewModels;

namespace WebAPIs.Controllers
{
    [ApiController, Route("api/Files"), Produces("application/json")]
    public class FilesController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IServiceFile _IServiceFile;

        public FilesController(IMapper iMapper, IServiceFile serviceFile)
        {
            _IMapper = iMapper;
            _IServiceFile = serviceFile;
        }

        [Produces("application/json"), HttpPost("/api/Files/AddCSV/")]
        public async Task<IActionResult> AddCSV([FromForm] IFormFileCollection files)
        {
            try
            {
                List<UserShawandpartnersViewModel> userShawandpartnersViewModel = new();
                foreach (var file in files)
                {
                    userShawandpartnersViewModel.AddRange(_IServiceFile.ReadCSV<UserShawandpartnersViewModel>(file.OpenReadStream()));
                }

                //convert model
                List<UserShawandpartners> userShawandpartnersList = _IMapper.Map<List<UserShawandpartners>>(userShawandpartnersViewModel);

                //inserting in de in db
                var result = await _IServiceFile.AddCSV(userShawandpartnersList);

                return Ok($"csv file was uploaded successfully. {userShawandpartnersViewModel.Count}");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while uploading the csv file. " + ex.Message);
            }
        }
    }
}