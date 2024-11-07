
using DevagramCSharp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevagramCSharp.Controller
{
    /* "Importante"
     Quando passado o caminho da Route entre parentese, e no nome "Controller"
    foi adcionado [] colchetes , isso serve para quando a rota for chamado exemplo:
    localhost/api/ = ao inves de aparecer o nome da classe "LoginController" no 
    localhost/api/LoginController ele ira remover o Controller do nome LoginController
    e então ficara apenas "localhost/api/Login"
     */

    [ApiController] //Serve para avisar que essa classe é uma Api Controller
    [Route("api/[Controller}")] // Esse metodo serve para definir a rota de navegação na url quando for chamado
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger; // foi atribuido no Ilogger o readonly que faz o objeto ser apenas leitura, impedindo o mesmo de ser feito alteração

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost] // Serve para informar que o metodo ou algo é um Http Post "Requisição"
        [AllowAnonymous] // Esse metodo é para deixar de forma anonima e livre para qualquer usuario poder logar
        internal IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginRequisicao) // o FromBody serve para pegar o dados no corpo da pagina
        {
            try
            {
                /*
                 O throw em C# é utilizado para lançar exceções.
                Isso permite que você sinalize a ocorrência de condições
                excepcionais (erros) no seu código, que podem ser tratadas
                posteriormente

                O uso de throw é fundamental para controlar o fluxo
                de execução do programa quando algo inesperado acontece.
                 */
                throw new ArgumentException("Erro ao Tentar Logar , sem cadastro no sistema");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro no login:  {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErroResposta()
                    {
                        Status = StatusCodes.Status500InternalServerError.ToString(),
                        Descricao = "Erro na seção do login"
                    });

            }
            // return Ok();
        }
    }
}
