    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        Autenticacao AutenticacaoServico;

        //public ClienteController(IHttpContextAccessor context)
        //{
        //    AutenticacaoServico = new Autenticacao(context);
        //}

        // GET api/values
        [HttpGet]
        [Route("listagem")]
        public ActionResult<List<ClienteModel>> Listagem()
        {
            return new ClienteModel().Listagem();
        }

        // GET api/values/5
        [HttpGet]
        [Route("listagem/{id}")]
        public ActionResult<ClienteModel> ListagemCliente(int id)
        {

            return new ClienteModel().ListagemCliente(id);

            //DAL objDAL = new DAL();
            //string command = $"select * from cliente where id = {id}";
            //DataTable dataTable = objDAL.RetornarDataTable(command);

            //return dataTable.Rows[0]["Nome"].ToString();
        }

        // POST api/registrar
        [HttpPost]
        [Route("registrar")]
        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel dados)
        {
            ReturnAllServices returnAll = new ReturnAllServices();
            try
            {
                dados.RegistrarCliente();
                returnAll.Result = true;
                returnAll.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                returnAll.Result = false;
                returnAll.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return returnAll;
        }

        // PUT api/values/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar([FromBody] ClienteModel dados)
        {
            ReturnAllServices returnAll = new ReturnAllServices();
            try
            {
                dados.AtualizarCliente();
                returnAll.Result = true;
                returnAll.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                returnAll.Result = false;
                returnAll.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return returnAll;
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("deletar/{id}")]
        public ReturnAllServices Deletar(int id)
        {
            ReturnAllServices returnAllServices = new ReturnAllServices();
            try
            {
              //  AutenticacaoServico.Autenticar();
                new ClienteModel().Deletar(id);
                returnAllServices.Result = true;
                returnAllServices.ErrorMessage = "Cliente excluido com sucesso!";
            }
            catch (Exception ex)
            {
                returnAllServices.Result = false;
                returnAllServices.ErrorMessage = ex.Message;
            }
            return returnAllServices;
        }
    }
}
