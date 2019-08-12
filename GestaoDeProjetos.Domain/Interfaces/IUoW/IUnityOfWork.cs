namespace GestaoDeProjetos.Domain.Interfaces.IUoW
{
    public interface IUnityOfWork
    {
        void Commit();
        void BeginTransaction();
        void RollBack();
        bool SaveChanges();
    }
}
