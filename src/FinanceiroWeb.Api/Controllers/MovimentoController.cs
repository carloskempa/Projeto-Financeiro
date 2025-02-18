﻿using Financeiro.App.Dtos;
using Financeiro.App.Interfaces;
using Financeiro.Domain.DataTransferObjects.Filtro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceiroWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly IMovimentoApp _movimentoApp;

        public MovimentoController(IMovimentoApp movimentoApp)
        {
            _movimentoApp = movimentoApp;
        }


        //Todo: Implementar Um controlerBase para pegar as notificações de erros e nao mandar Exceptions via api
        [HttpPost("listar")]
        public async Task<IActionResult> ObterMovimentacoes([FromBody] MovimentoFilter filter, [FromQuery] Paginacao paginacao)
        {
            try
            {
                return Ok(await _movimentoApp.ObterMovimentacoes(filter, paginacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] MovimentoDto movimento)
        {
            var result = await _movimentoApp.Cadastrar(movimento);

            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
