using System.Collections.Generic;

namespace _NET.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> List();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}