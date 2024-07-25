using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.Domain.DTOs.Candidates;

namespace VotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository candidate;
        public CandidateController(ICandidateRepository candidate)
        {
            this.candidate = candidate;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody]CandidateCreateDTO new_candidate)
        {
            try
            {
                var create_new_candidate = await candidate.CreateCandidate(new_candidate);
                if(create_new_candidate != null)
                {
                    return Ok(create_new_candidate);
                }
                else
                {
                    return BadRequest(create_new_candidate);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet ("/{candidate_id}")]
        public async Task<IActionResult> FetchCandidate(int candidate_id)
        {
            try
            {
                var fetched_candidate = await candidate.GetCandidateByID(candidate_id);
                if(fetched_candidate == null)
                {
                    return NotFound(fetched_candidate);
                }
                return Ok(fetched_candidate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult> FetcAllCandidates() => Ok(await candidate.GetAllCandidates());

    }
}
