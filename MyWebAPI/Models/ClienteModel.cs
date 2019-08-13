using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
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


        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();

            string sqlcommand = "insert into cliente(nome,data_cadastro,cpf_cnpj,data_nascimento,tipo,telefone," +
                "email,cep,logradouro,numero,bairro,complemento,cidade,uf) " +
                $"values('{Nome}','{DateTime.Parse(DataCadastro).ToString("yyyy/MM/dd")}','{Cpf_Cnpj}','{DateTime.Parse(DataNascimento).ToString("yyyy/MM/dd")}','{Tipo}'," +
                $"'{Telefone}','{Email}','{Cep}','{Logradouro}','{Numero}','{Bairro}'," +
                $"'{Complemento}','{Cidade}','{Uf}')";

            objDAL.ExecutarSQLCommand(sqlcommand);
        }
        public List<ClienteModel> Listagem()
        {
            List<ClienteModel> list = new List<ClienteModel>();
            ClienteModel item;

            DAL objDAL = new DAL();

            string command = "select * from cliente order by nome asc";
            DataTable dados = objDAL.RetornarDataTable(command);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = int.Parse(dados.Rows[i]["id"].ToString()),
                    Nome = dados.Rows[i]["nome"].ToString(),
                    DataCadastro = DateTime.Parse(dados.Rows[i]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                    Cpf_Cnpj = dados.Rows[i]["cpf_cnpj"].ToString(),
                    DataNascimento = DateTime.Parse(dados.Rows[i]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Tipo = dados.Rows[i]["tipo"].ToString(),
                    Telefone = dados.Rows[i]["telefone"].ToString(),
                    Email = dados.Rows[i]["email"].ToString(),
                    Cep = dados.Rows[i]["cep"].ToString(),
                    Logradouro = dados.Rows[i]["logradouro"].ToString(),
                    Numero = dados.Rows[i]["numero"].ToString(),
                    Bairro = dados.Rows[i]["bairro"].ToString(),
                    Complemento = dados.Rows[i]["complemento"].ToString(),
                    Cidade = dados.Rows[i]["cidade"].ToString(),
                    Uf = dados.Rows[i]["uf"].ToString()

                };
                list.Add(item);
            }
            return list;
        }
        public ClienteModel ListagemCliente(int id)
        {
            ClienteModel item;
            DAL objDAL = new DAL();

            string command = $"select * from cliente where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(command);

            item = new ClienteModel()
            {
                Id = int.Parse(dados.Rows[0]["id"].ToString()),
                Nome = dados.Rows[0]["nome"].ToString(),
                DataCadastro = DateTime.Parse(dados.Rows[0]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Cpf_Cnpj = dados.Rows[0]["cpf_cnpj"].ToString(),
                DataNascimento = DateTime.Parse(dados.Rows[0]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Tipo = dados.Rows[0]["tipo"].ToString(),
                Telefone = dados.Rows[0]["telefone"].ToString(),
                Email = dados.Rows[0]["email"].ToString(),
                Cep = dados.Rows[0]["cep"].ToString(),
                Logradouro = dados.Rows[0]["logradouro"].ToString(),
                Numero = dados.Rows[0]["numero"].ToString(),
                Bairro = dados.Rows[0]["bairro"].ToString(),
                Complemento = dados.Rows[0]["complemento"].ToString(),
                Cidade = dados.Rows[0]["cidade"].ToString(),
                Uf = dados.Rows[0]["uf"].ToString()

            };

            return item;
        }
        public void AtualizarCliente()
        {
            DAL objDAL = new DAL();

            string sqlcommand = $"update cliente set " +
                $"nome='{Nome}'" +
                $",data_cadastro='{DateTime.Parse(DataCadastro).ToString("yyyy/MM/dd")}'" +
                $",cpf_cnpj='{Cpf_Cnpj}'" +
                $",data_nascimento='{DateTime.Parse(DataNascimento).ToString("yyyy/MM/dd")}'" +
                $",tipo='{Tipo}'" +
                $",telefone='{Telefone}'" +
                $",email='{Email}'" +
                $",cep='{Cep}'" +
                $",logradouro='{Logradouro}'" +
                $",numero='{Numero}'" +
                $",bairro='{Bairro}'" +
                $",complemento='{Complemento}'" +
                $",cidade='{Cidade}'" +
                $",uf='{Uf}' where id={Id}";

            objDAL.ExecutarSQLCommand(sqlcommand);
        }
        public void Deletar(int id)
        {
            DAL objDAL = new DAL();
            string command = $"delete from cliente where id={id}";
            objDAL.ExecutarSQLCommand(command);
        }
    }
}