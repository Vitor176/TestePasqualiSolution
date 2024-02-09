using System;
using System.Net.NetworkInformation;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;

namespace ToDoListAPI.Messages
{
    public class Messages
    {
        public static string UnexpectedErrorMessage = "Erro inesperado, favor consultar o administrador.";
        public static string NotFoundDatasForThisRouteMessage = "Não houveram resultados para a pesquisa.";
        public static string NotFoundDataForThisIdMessage = "Não Existem informações para o Id informado.";
        public static string ErrorObjectNullMessage = "Objeto não pode ser nulo";
        public static string ErrorUpdateRegisterMessage = "Não foi possível atualizar o cadastro.";
        public static string ErrorUpdateDataBaseMessage = "Erro interno, não foi possível atualizar o cadastro.";

        #region LOGS

        public string BeginRequestMessage(string context = null)
        {
            return $"Inicio da requisição {(string.IsNullOrWhiteSpace(context) ? "no contexto: " + context : string.Empty)} - {DateTime.Now}";
        }
        public string SearchAnyIntoDatabase(string any = null)
        {
            return $"Buscando {any} em banco de dados";
        }
        public string CreateRegisterIntoDataBase(RegisterPF register = null)
        {
            return $"Criando um novo cadastro para {register.Name}";
        }
        public string UpdateRegisterExisting(RegisterPF registerPF = null)
        {
            return $"Atualizando o cadastro com o Id {registerPF.Id}";  
        }
        public string DeletingRegisterWithId(long id)
        {
            return $"Excluindo o Cadastro com o Id:{id}";
        }
        public string ErrorLog(string error = null)
        {
            return $"Não Foi Possível Encontrar Cadastros, Erro : {error}";
        }
        public string ErrorCreateRegisterIntoDataBase(string error = null)
        {
            return $"Não Foi Possível Criar um novo cadastro, erro:{error}";
        }

        #endregion
    }
}
