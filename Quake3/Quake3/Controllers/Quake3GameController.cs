using Quake3.Infrastructure;
using Quake3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Quake3.Controllers
{
    public class Quake3GameController : ApiController
    {
        /// <summary>
        /// Chamada para efetuar a leitura do arquivo de log do Game Quake 3 fazendo criando as separações de batalhas e mostrando a quantidade de kill por batalhar e exibindo os players.
        /// </summary>
        /// <returns>Retorno em formato de Json</returns>
        [Route("api/Quake3Game/LerArquivo")]
        [HttpGet]
        public IHttpActionResult LerArquivo()
        {
            try
            {
                //Criando o entidade Game
                var reader = new GameReader();

                //Lendo o Arquivo de Log do Game Quake 3
                var games = reader.LerArquivo();
                var jsonGames = JsonConvert.SerializeObject(games, Formatting.None);
                return Ok(jsonGames);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error has occurred." + ex.Message));
            }
        }
    }
}