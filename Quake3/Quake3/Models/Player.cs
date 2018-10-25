using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quake3.Models
{
    public class Player
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public Player(int id)
        {
            Id = id;
        }

        public Player(int id, string name) : this(id)
        {
            Name = name;
        }

        public void Changed(string name)
        {
            Name = name;
        }
    }
}