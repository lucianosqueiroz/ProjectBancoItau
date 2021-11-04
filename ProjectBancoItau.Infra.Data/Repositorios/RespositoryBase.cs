using ProjectBancoItau.Domain.Conexao;
using ProjectBancoItau.Domain.Interfaces;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using ProjectBancoItau.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Infra.Data.Repositorios
{
    public class RespositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
       // protected Conexao Db = new Conexao();

        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
