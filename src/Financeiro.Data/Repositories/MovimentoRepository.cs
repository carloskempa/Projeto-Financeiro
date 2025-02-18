﻿using Financeiro.Domain.Core.Data;
using Financeiro.Domain.Entidades;
using Financeiro.Domain.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Financeiro.Data.Repositories
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly FinanceiroContext _context;

        public MovimentoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Movimento>> Buscar(Expression<Func<Movimento, bool>> predicado)
        {
            return await _context.Movimentos.AsNoTracking().Where(predicado).ToListAsync();
        }

        public async Task<Movimento> ObterPorId(Guid id)
        {
            return await _context.Movimentos.FindAsync(id);
        }

        public void Cadastrar(Movimento entity)
        {
            _context.Movimentos.Add(entity);
        }

        public void Atualizar(Movimento entity)
        {
            _context.Movimentos.Update(entity);
        }

        public void Deletar(Movimento entity)
        {
            _context.Movimentos.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
