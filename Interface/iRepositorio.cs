using System.Collections.Generic;

namespace DIO.Series
{
    public interface iRepositorio<A>
    {
         List<A> Lista();
         A RetornaPorId(int id);
         void Insere(A entidade);
         void Atualiza(int id, A entidade);
         int ProximoId();
    }
}