using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IServiceMessage
    {
        Task Adicionar(Message objeto);

        Task Atualizar(Message objeto);

        Task<List<Message>> ListarMensagensAtivas();
    }
}
