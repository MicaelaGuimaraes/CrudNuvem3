using CrudNuvemTheree.DataAccess.Interface;
using CrudNuvemTheree.DataAccess.Repository;
using CrudNuvemTheree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudNuvemTheree.Service
{
    public class AgendaContatosService : IAgendaContatos
    {
        private AgendaContatosRepository Dados = new AgendaContatosRepository();

        public void Add(AgendaContatos entidade)
        {
            Dados.Add(entidade);
        }

        public IEnumerable<AgendaContatos> Find(Expression<Func<AgendaContatos, bool>> filtro)
        {
            var saida = Dados.Find(filtro);
            return saida;
        }

        public IEnumerable<AgendaContatos> GetAll()
        {
            var saida = Dados.GetAll();
            return saida.ToArray();
        }

        public AgendaContatos GetById(int id)
        {
            var saida = Dados.GetById(id);
            return saida;
        }

        public void Remove(AgendaContatos obj)
        {
            Dados.Remove(obj);
        }

        public void Remove(int ID)
        {
            var Registro = GetById(ID);
            Dados.Remove(Registro);
        }

        public void Update(AgendaContatos obj)
        {
            Dados.Update(obj);
        }

    }

}
