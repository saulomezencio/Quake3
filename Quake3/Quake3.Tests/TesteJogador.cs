using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Quake3.Models;
using System.Web;
using Quake3.Infrastructure;
using System.IO;
using System.Text;
using Quake3.Tests.Players;

namespace Quake3.Tests
{
    [TestClass]
    public class TesteJogador
    {
        [TestMethod]
        public void Deve_criar_um_jogador_somente_com_o_identificador()
        {
            var playerOne = PlayersGame.Default().WithID(1).Build();
            var IdPlayerExpected = 1;

            Assert.AreEqual(IdPlayerExpected, playerOne.Id);
        }

        [TestMethod]
        public void Deve_criar_um_jogador_com_o_identificador_e_o_nome()
        {
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Isgalamido";
            var playerOne = PlayersGame.Default().WithIdAndName(IdPlayerExpected, namePlayerExpected).Build();

            Assert.AreEqual(IdPlayerExpected, playerOne.Id);
            Assert.AreEqual(namePlayerExpected, playerOne.Name);
        }

        [TestMethod]
        public void Deve_permitir_a_alteracao_do_nome_do_jogador()
        {
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Isgalamido";
            var playerOne = PlayersGame.Default().Build();

            playerOne.Changed("Isgalamido");

            Assert.AreEqual(IdPlayerExpected, playerOne.Id);
            Assert.AreEqual(namePlayerExpected, playerOne.Name);
        }
    }
}
