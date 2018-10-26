using Quake3.Models;
using Quake3.Tests.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quake3.Tests
{
    [TestClass]
    public class TesteGame
    {
        private Game game;

        [TestInitialize]
        public void Iniciar()
        {
            game = new Game();
        }

        [TestMethod]
        public void Deve_iniciar_um_jogo_sem_um_jogador()
        {
            //arrange
            var totalPlayersExpected = 0;

            //act
            var totalPlayers = game.players.Count();

            //assert
            Assert.AreEqual(totalPlayersExpected, totalPlayers);
        }

        [TestMethod]
        public void Deve_iniciar_um_jogo_com_um_jogador()
        {
            //arrange
            var totalPlayersExpected = 1;
            var killer = PlayersGame.Default().WithIdAndName(1, "Isgalamido").Build();

            //act
            game.Add(killer);

            //assert
            Assert.AreEqual(totalPlayersExpected, game.players.Count());
        }

        [TestMethod]
        public void Deve_iniciar_um_jogo_e_permitir_a_alteracao_do_nome_do_jogador()
        {
            //arrange
            var IdPlayerExpected = 1;
            var namePlayerExpected = "Isgalamido";
            var killer = PlayersGame.Default().WithIdAndName(IdPlayerExpected, namePlayerExpected).Build();
            game.Add(killer);

            //act
            game.AlterarNome(killer, "Isgalamido");

            //assert
            Assert.AreEqual(IdPlayerExpected, killer.Id);
            Assert.AreEqual(namePlayerExpected, killer.Name);
        }

        [TestMethod]
        public void Deve_iniciar_um_jogo_com_dois_jogadores_diferentes()
        {
            //arrange
            var totalPlayersExpected = 2;
            var killer = PlayersGame.Default().WithIdAndName(1, "Isgalamido").Build();
            var victim = PlayersGame.Default().WithIdAndName(2, "Dono da Bola").Build();

            //act
            game.Add(killer);
            game.Add(victim);

            //assert
            Assert.AreEqual(totalPlayersExpected, game.players.Count());
        }

        [TestMethod]
        public void Deve_iniciar_um_jogo_com_dois_jogadores_diferentes_e_permitir_a_alteracao_do_nome_de_um_dos_jogadores()
        {
            //arrange
            var totalPlayersExpected = 2;
            var namePlayerExpected = "Isgalamido";
            var killer = PlayersGame.Default().WithIdAndName(1, "Dono da Bola").Build();
            var victim = PlayersGame.Default().WithIdAndName(2, "Dono da Bola").Build();
            game.Add(killer);
            game.Add(victim);

            //act
            game.AlterarNome(victim, namePlayerExpected);

            //assert
            Assert.AreEqual(totalPlayersExpected, game.players.Count());
            Assert.AreEqual(namePlayerExpected, victim.Name);
        }

        [TestMethod]
        public void Deve_matar_um_jogador_por_morte_natual_e_atualizar_o_total_das_mortes()
        {
            //arrange
            var totalOfDeadPlayersExpected = 1m;
            var killer = PlayersGame.Default().Build();
            game.Add(killer);

            //act
            game.KillByNaturalDeath(killer, MeansOfDeath.MOD_TRIGGER_HURT); // Matar por morte natural

            //assert
            Assert.AreEqual(totalOfDeadPlayersExpected, game.total_kills);
        }

        [TestMethod]
        public void Deve_um_jogador_matar_outro_jogador_e_atualizar_o_total_das_mortes()
        {
            //arrange
            var totalOfDeadPlayersExpected = 1m;
            var killer = PlayersGame.Default().WithIdAndName(1, "Isgalamido").Build();
            var victim = PlayersGame.Default().WithIdAndName(2, "Dono da Bola").Build();
            game.Add(killer);
            game.Add(victim);

            //act
            game.KillForMurder(killer, victim, MeansOfDeath.MOD_TRIGGER_HURT); // Matar por assassinato

            //assert
            Assert.AreEqual(totalOfDeadPlayersExpected, game.total_kills);
        }
    }
}
