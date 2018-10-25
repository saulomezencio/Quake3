using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quake3.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int total_kills { get; protected set; }

        public virtual List<Player> players { get; set; }

        public virtual List<DeadPlayer> kills { get; set; }
        public Game()
        {
            players = new List<Player>();
            kills = new List<DeadPlayer>();
        }
        public void Add(Player player)
        {
            var onePlayer = ProcurarPlayer(player.Id);
            if (onePlayer == null)
            {
                players.Add(player);
                AddNewDeadPlayer(player);

                var deadOnePlayer = ProcurarPlayerDead(player.Id);
                deadOnePlayer.ChangedKills(0);
            }
        }
        /// <summary>
        /// Procura o player pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Player ProcurarPlayer(int id)
        {
            return players.FirstOrDefault(atWhere => atWhere.Id == id); 
        }
        /// <summary>
        /// Alterar o nome do player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="name"></param>
        public void AlterarNome(Player player, string name)
        {
            var onePlayer = ProcurarPlayer(player.Id);
            var deadOnePlayer = ProcurarPlayerDead(player.Id);
            if (onePlayer != null)
            {
                onePlayer.Changed(name);
                deadOnePlayer.Changed(name);
            }
        }
        private void AddNewDeadPlayer(Player victim)
        {
            var player = ProcurarPlayer(victim.Id);
            if (player == null)
                player = victim;

            var newDeadPlayer = new DeadPlayer(player.Id, player.Name);
            newDeadPlayer.Sum();
            kills.Add(newDeadPlayer);
        }
        /// <summary>
        /// Procurar player morto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DeadPlayer ProcurarPlayerDead(int id)
        {
            return kills.FirstOrDefault(atWhere => atWhere.Id == id);
        }
        /// <summary>
        /// Morte Natural
        /// </summary>
        /// <param name="victim"></param>
        /// <param name="meansOfDeath"></param>
        public void KillByNaturalDeath(Player victim, MeansOfDeath meansOfDeath)
        {
            var deadPlayerExist = ProcurarPlayerDead(victim.Id);
            if (deadPlayerExist != null)
            {
                //if (deadPlayerExist.TotalKills > 0m)//em caso para o kill não ficar negativo.
                deadPlayerExist.Subtract(); //Quando o <world> mata o player ele perde -1 kill.
            }
            total_kills++; //total_kills são os kills dos games, isso inclui mortes do <world>.
        }
        /// <summary>
        /// Morte pelo inimigo
        /// </summary>
        /// <param name="killer"></param>
        /// <param name="victim"></param>
        /// <param name="meansOfDeath"></param>
        public void KillForMurder(Player killer, Player victim, MeansOfDeath meansOfDeath)
        {
            var deadPlayerExist = ProcurarPlayerDead(victim.Id);
            if (deadPlayerExist != null)
            {
                deadPlayerExist.Sum();
            }
            else
            {
                AddNewDeadPlayer(victim);
            }
            total_kills++; //total_kills são os kills dos games, isso inclui mortes do <world>.
        }
    }
}