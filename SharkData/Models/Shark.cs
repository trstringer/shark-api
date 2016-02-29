using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharkData.Models
{
    public class Shark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Binomial { get; set; }
        public int MaxLength { get; set; }

        public static IEnumerable<Shark> GetShark()
        {
            return new List<Shark>()
            {
                new Shark() { Id = 1, Name = "Great White", Binomial = "Carcharodon carcharias", MaxLength = 17 },
                new Shark() { Id = 2, Name = "Blue", Binomial = "Prionace glauca", MaxLength = 12 },
                new Shark() { Id = 3, Name = "Tiger", Binomial = "Galeocerdo cuvier", MaxLength = 16 },
                new Shark() { Id = 4, Name = "Blacktip Reef", Binomial = "Carcharhinus melanopterus", MaxLength = 6 },
                new Shark() { Id = 5, Name = "Whitetip Reef", Binomial = "Triaenodon obesus", MaxLength = 6 },
                new Shark() { Id = 6, Name = "Nurse", Binomial = "Ginglymostoma cirratum", MaxLength = 10 },
                new Shark() { Id = 7, Name = "Lemon", Binomial = "Negaprion brevirostris", MaxLength = 8 }
            };
        }

        public static Shark GetShark(int id)
        {
            return GetShark().Where(s => s.Id == id).First();
        }

        public static Shark GetShark(string name)
        {
            return GetShark().Where(s => s.Name.ToLower() == name.ToLower()).First();
        }
    }
}