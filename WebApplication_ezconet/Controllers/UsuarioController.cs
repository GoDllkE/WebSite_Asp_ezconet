using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication_ezconet.DAO;
using WebApplication_ezconet.Models;

namespace WebApplication_ezconet.Controllers
{
    public class UsuarioController : Controller
    {
        /*
         * Por alguma razão, nenhum 'ModelState' está sendo exibido. 
         * Testado também utilizando os inputs pelo HTML-Helper e também não funcionaram.
         * Funções JS/Jquery de validações também não funcionaram (eventos) - Os mesmos foram testados separadamente e funcionaram.
         * Caso consiga encontrar a solução, me avise.
         * Abraço!
         */

        /// <summary>
        /// Ação Index
        /// </summary>
        /// <returns>Retorna a View 'Index' com 2 ViewBags (Objeto Usuario e Sexo) e uma model do objeto usuario</returns>
        public ActionResult Index()
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SexoDAO sexoDao = new SexoDAO();

            IList<Usuario> usuario = usuarioDao.Lista();
            IList<Sexo> sexo = sexoDao.Lista();

            ViewBag.Usuario = usuario;
            ViewBag.Sexo = sexo;

            if (TempData["Mensagem"] != null)
                ViewBag.Mensagem = Convert.ToString(TempData["Mensagem"]);

            return View(usuario);
        }

        /// <summary>
        /// Action para Formulario de cadastro de usuarios
        /// </summary>
        /// <returns>Retorna uma View com 2 ViewBags (objeto usuario e sexo)</returns>
        public ActionResult Form()
        {
            SexoDAO sexoDao = new SexoDAO();
            IList<Sexo> sexo = sexoDao.Lista();
            ViewBag.Sexo = sexo;

            Usuario usuario = new Usuario();
            ViewBag.Usuario = usuario;

            if (TempData["Mensagem"] != null)
                ViewBag.Mensagem = Convert.ToString(TempData["Mensagem"]);

            return View();
        }


        /// <summary>
        /// Action para adicionar usuario ao BD via POST apenas
        /// </summary>
        /// <param name="usuario">Objeto usuario, passado pelos campos 'name' do Form()</param>
        /// <param name="usuarioSenha1">Campo 'senha' passado pelo Form()</param>
        /// <param name="usuarioSenha2">Campo 'Confirme a senha' passado pelo Form()</param>
        /// <param name="usuarioAtivo">Checkbox passada pelo Form() para indicar status do usuario ao finalizar cadastro</param>
        /// <returns>Se valido e cadastrado, retorna para Index do usuario. Se invalido, retorna para o Form() de cadastro do usuario</returns>
        [HttpPost]
        public ActionResult Adiciona(String usuarioNome, DateTime usuarioDataNasc, int usuarioSexo, String usuarioEmail, String usuarioSenha1, String usuarioSenha2, String usuarioAtivo)
        {
            /* 
             * Tudo isso por causa da referencia de objeto, sem tempo, tive que fazer do jeito 'feio'
             * Por alguma razão (provavelmente de outra dimenção paralela), fazer via objeto não está indo, 
             * algo está barrando e o Debug não ajudou nada....
             * Rollback pra versão 'feia'
            */

            // Mensagem de erro padrão
            String erroMsg = "Cadastrado nao realizado. Foram encontrado(s) dado(s) invalido(s). ";

            // Instancia de usuario
            Usuario usuario = new Usuario();

            // Valida Nome
            if (usuarioNome.Length < 3 || usuarioNome.Length > 200) {                                           
                erroMsg += "\nCampo nome com quantidade de caracteres "+ usuarioNome.Length.ToString() + " inválidos. (min: 3 | max: 200)";
                ModelState.AddModelError("Usuario.Nome", "Nome inválidos! Verifique os novamente.");
            }
            else
                usuario.Nome = usuarioNome;                                                                

            // Pega Data
            usuario.DataNascimento = (DateTime)usuarioDataNasc;                                               

            // Valida Email
            if (usuarioEmail.Length < 1 || usuarioEmail.Length > 100) {                                        
                erroMsg += "\nCampo Email com quantidade de caracteres " + usuarioEmail.Length.ToString() + " inválidos. (min: 3 | max: 100)";
                ModelState.AddModelError("Usuario.Email", "Email invalido! Verifique os novamente.");
            }
            else
                usuario.Email = usuarioEmail;                                                                 

            // Valida Senha
            if ((usuarioSenha1.Length < 3 || usuarioSenha1.Length > 30) && (usuarioSenha2.Length < 3 || usuarioSenha2.Length > 30))
            {
                if (usuarioSenha1.Equals(usuarioSenha2))
                    usuario.Senha = usuarioSenha1; 
                else
                {
                    erroMsg += "\nSenha invalida. Campos não coincidem";
                    ModelState.AddModelError("Usuario.Senha", "Senhas invalidas! Campos não coincidem.");
                }
            }
            else
            {
                erroMsg += "\nCampo senha com quantidade de caracteres: " + usuarioSenha1.Length.ToString() + "  e " + usuarioSenha2.Length.ToString() + " inválidos. (min: 3 | max: 30)";
                ModelState.AddModelError("Usuario.Senha", "Senhas invalidas! Campos estão com menos ou mais caracteres do que o permitido (min: 3 | max: 30).");
            }
                
            // Pega Sexo
            usuario.SexoId = usuarioSexo;
            
            // Ativo
            if (usuarioAtivo == "1")
                usuario.Ativo = 1;
            else
                usuario.Ativo = 0;

            // Verifica via Model
            if (ModelState.IsValid)
            {
                UsuarioDAO dao = new UsuarioDAO();
                dao.Adiciona(usuario);
                TempData["Mensagem"] = "Cadastrado com sucesso!";                                               // Por algum motivo, só mostra a informação armazenada no TempData
                return RedirectToAction("Index", "Usuario");                                                    // Redireciona para index do usuario
            }
            else
            {
                // Sexo
                SexoDAO sexoDao = new SexoDAO();
                IList<Sexo> sexo = sexoDao.Lista();
                ViewBag.Sexo = sexo;
                TempData["Mensagem"] = erroMsg;                                                                 // Por algum motivo, só mostra a informação armazenada no TempData
                ModelState.AddModelError("Valores", "Dados inválidos! Verifique os campos novamente.");         // Por algum motivo, nenhum ModelError está sendo mostrado, assim como os JS não está sendo executado
                return RedirectToAction("Form", "Usuario");                                                     // Redireciona para Form de cadastro   
            }
        }

        /// <summary>
        /// Action para remover um usuário cadastrado no BD
        /// </summary>
        /// <param name="id">Parametro inteiro referente ao ID do usuario cadastrado no BD</param>
        /// <returns>Após concluir, redireciona para Index do usuario</returns>
        [Route("/Usuario/Remove/{id}", Name = "DeletarUsuario")]
        public ActionResult Remove(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscaPorId(id);

            dao.Remove(usuario);
            TempData["Mensagem"] = "Usuário removido com sucesso!";
            return RedirectToAction("Index", "Usuario");
        }

        /// <summary>
        /// Altera status do usuario cadastrado
        /// </summary>
        /// <param name="id">Parametro inteiro referente ao ID do usuario cadastrado no BD</param>
        /// <returns>Após concluir, redireciona para Index do usuario</returns>
        [Route("/Usuario/MudaStatus/{id}", Name = "AlteraStatusUsuario")]
        public ActionResult MudaStatus(int id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscaPorId(id);

            if(usuario.Ativo == 1) { usuario.Ativo = 0; }
            else { usuario.Ativo = 1; }

            dao.Atualiza(usuario);
            TempData["Mensagem"] = "Status atualizado!";
            return RedirectToAction("Index", "Usuario");
        }


        /* Actions não Implementadas/Finalizadas */

        /// <summary>
        /// Action para Login
        /// </summary>
        /// <returns>Retorna View</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Action para autenticar Usuario no sistema
        /// </summary>
        /// <param name="login">Recolhe campo 'login' da View Login()</param>
        /// <param name="senha">Recolhe campo 'senha' da View Login()</param>
        /// <returns>Se login concluido com sucesso, retorna para Index do usuario. Se não, retorna para Login()</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autentica(String login, String senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.Busca(login, senha);

            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Usuario");
            }
            else
                return RedirectToAction("Login", "Usuario");
        }

    }
}