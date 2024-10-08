using bankingClassAPI.DataAccess.Interface;
using bankingClassAPI.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bankingClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly ISimpleBanking _repo;
        public BankingController(ISimpleBanking repo)
        {
            _repo = repo;
        }

        [HttpPost("CreateNewUser")]

        public async Task<IActionResult> CreateBankUser([FromBody]CreateAccoutDTO new_user)
        {
            try
            {
                var res = await _repo.CreateAccount(new_user);
                return Ok(res);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CheckAccountBalance")]
        public async Task<IActionResult> CheckAcctBalance(string acct_no)
        {
            try{
                var res = await _repo.GetAccountBalance(acct_no);
                return Ok(res);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
