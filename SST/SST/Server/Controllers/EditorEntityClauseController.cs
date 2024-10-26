using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SST.Server.Controllers
{
    [ApiController]
    public class EditorEntityClauseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public EditorEntityClauseController(IConfiguration configuration,
                               ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        [Route("api/GetEditorEntityClause/{transactionID}")]
        public async Task<IActionResult> GetUserProfile(Guid transactionID)
        {
            var list = await _context.ContractTransactionEntityClauses.Include(x => x.ContractTransactionEntity).Where(x => x.ContractTransactionEntity.ContractTransactionID == transactionID)
                .Select(x => new EditorEntityClause()
                {
                    ContractTransactionEntityClauseID = x.ID,
                    ClauseName = x.Code,
                    ContractTransactionEntityName = x.ContractTransactionEntity.Name
                }).ToListAsync();
            return Ok(list);
        }
    }
}
