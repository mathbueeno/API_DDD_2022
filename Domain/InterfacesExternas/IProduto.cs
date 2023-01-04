using Entities.EntidadesExternas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesExternas
{
    public interface IProduto
    {
        List<Produto> List();

        Produto Create(Produto produto);
        Produto Update(Produto produto);
        Produto GetOne(int codigo);
        Produto Delete(int codigo);
    }
}
