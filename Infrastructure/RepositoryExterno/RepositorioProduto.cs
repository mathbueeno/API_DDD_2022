using Domain.InterfacesExternas;
using Entities.EntidadesExternas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryExterno
{
    public class RepositorioProduto : IProduto
    {
        private readonly string urlApi= "http://...";

        public Produto Create(Produto produto)
        {
            var produtoCriado = new Produto();

            using (var cliente = new HttpClient())
            {
                string jsonObjeto = JsonConvert.SerializeObject(produto);
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = cliente.PostAsync(urlApi + "Create", content);
                resposta.Wait();

                if (resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                }
            }

            return produtoCriado;
        }

        public Produto Delete(int codigo)
        {
            throw new NotImplementedException();
        }

        public Produto GetOne(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<Produto> List()
        {
            throw new NotImplementedException();
        }

        public Produto Update(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
