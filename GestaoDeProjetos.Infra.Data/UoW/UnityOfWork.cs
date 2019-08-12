using GestaoDeProjetos.Domain.Interfaces.IUoW;
using GestaoDeProjetos.Infra.Data.Context;

namespace GestaoDeProjetos.Infra.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly GestaoDeProjetosContext _context;

        public UnityOfWork(GestaoDeProjetosContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void RollBack()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
