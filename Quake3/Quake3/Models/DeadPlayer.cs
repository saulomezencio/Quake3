using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quake3.Models
{
    public class DeadPlayer
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int TotalKills { get; protected set; }

        public DeadPlayer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Subtraindo
        /// </summary>
        public void Subtract()
        {
            TotalKills--;
        }

        /// <summary>
        /// Somando
        /// </summary>
        public void Sum()
        {
            TotalKills++;
        }

        /// <summary>
        /// Alterando nome
        /// </summary>
        /// <param name="name"></param>
        public void Changed(string name)
        {
            Name = name;
        }

        public void ChangedKills(int kills)
        {
            TotalKills = kills;
        }
    }
}