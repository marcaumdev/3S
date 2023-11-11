using api_3s.Application.ViewModel;
using api_3s.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace api_3s.Controllers;

[ApiController]
[Route("/api/usuario")]
public class UsuarioController : Controller
{
    [HttpPost]
    public IActionResult CadastrarUsuario([FromForm] FuncionarioViewModel funcionarioVM)
    {
        // Funcionario funcionario = new(funcionarioVM.IdTipoUsuario, funcionarioVM.Nome, funcionarioVM.Cpf,
        //funcionarioVM.Senha, funcionarioVM.Email, funcionarioVM.IdCargo);

        return Ok();
    }


    /// <summary>
    /// Transmite uma mensagem de email com um anexo
    /// </summary>
    /// <param name="Destinatario">Destinatario (Recipient)</param>
    /// <param name="Remetente">Remetente (Sender)</param>
    /// <param name="Assunto">Assunto da mensagem (Subject)</param>
    /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
    /// <param name="anexos">Um array de strings apontando para a localização de cada anexo</param>
    /// <returns>Status da mensagem</returns>
    [HttpPost]
    [Route("email")]
    public IActionResult EnviaMensagemComAnexos(string Destinatario, string Remetente,string Assunto, string enviaMensagem, ArrayList anexos)
    {
        try
        {
            // valida o email
            bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

            if (bValidaEmail == false)
                return Ok("Email do destinatário inválido:" + Destinatario);

            // Cria uma mensagem
            MailMessage mensagemEmail = new MailMessage(
               Remetente,
               Destinatario,
               Assunto,
               enviaMensagem);

            // The anexos arraylist should point to a file location where
            // the attachment resides - add the anexos to the message
            foreach (string anexo in anexos)
            {
                Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);
            }

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("macoratte@gmail.com", "hw8vup5e");
            client.Credentials = cred;

            // Inclui as credenciais
            client.UseDefaultCredentials = true;

            // envia a mensagem
            client.Send(mensagemEmail);

            return Ok("Mensagem enviada para " + Destinatario + " às " + DateTime.Now.ToString() + ".");
        }
        catch (Exception ex)
        {
            string erro = ex.ToString();
            return BadRequest(ex.Message.ToString() + erro);
        }
    }
    /// <summary>
    /// Confirma a validade de um email
    /// </summary>
    /// <param name="enderecoEmail">Email a ser validado</param>
    /// <returns>Retorna True se o email for valido</returns>
    public static bool ValidaEnderecoEmail(string enderecoEmail)
    {
        try
        {
            //define a expressão regulara para validar o email
            string texto_Validar = enderecoEmail;
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

            // testa o email com a expressão
            if (expressaoRegex.IsMatch(texto_Validar))
            {
                // o email é valido
                return true;
            }
            else
            {
                // o email é inválido
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
