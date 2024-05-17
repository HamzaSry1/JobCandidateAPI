using JobCandidateAPI.Services.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService service;
    }


    #region CRUD

    #endregion CRUD

}
