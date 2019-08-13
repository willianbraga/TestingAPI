using AplicacaoCliente.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCliente.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string DataNascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> list = new List<ClienteModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            list = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return list;
        }
        public ClienteModel Carregar(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("listagem", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }
        public void Inserir()
        {
            string jsondata = JsonConvert.SerializeObject(this);
            string json = WebAPI.RequestPOST("registrar", jsondata);
        }
        public void Atualizar()
        {
            string jsondata = JsonConvert.SerializeObject(this);
            string json = WebAPI.RequestPUT("atualizar/" + Id, jsondata);
        }
        public void Delete(int id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("deletar", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
        }
    }
}
