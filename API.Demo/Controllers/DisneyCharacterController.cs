using API.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisneyCharacterController : ControllerBase
    {
        private static readonly List<DisneyCharacter> _characters = new List<DisneyCharacter> { 
            new DisneyCharacter (){ CharacterId = 1, CharacterName = "Gaston", FirstAppearanceMovie="The Beauty and the beast", IsFriendly=false },
            new DisneyCharacter (){ CharacterId = 2, CharacterName = "Jaffar", FirstAppearanceMovie="Aladdin", IsFriendly=false },
            new DisneyCharacter (){ CharacterId = 3, CharacterName = "Hades", FirstAppearanceMovie="Hercules", IsFriendly=false },
            new DisneyCharacter (){ CharacterId = 4, CharacterName = "Stich", FirstAppearanceMovie="Lilo & Stich", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 5, CharacterName = "Simba", FirstAppearanceMovie="The Lion King", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 6, CharacterName = "Groot", FirstAppearanceMovie="Gardians of Galaxy", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 7, CharacterName = "Polochon", FirstAppearanceMovie="The little mermaid", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 8, CharacterName = "Indiana Jones", FirstAppearanceMovie="The lost arch", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 9, CharacterName = "Leia", FirstAppearanceMovie="Star wars - A new Hope", IsFriendly=true },
            new DisneyCharacter (){ CharacterId = 10, CharacterName = "Mickey", FirstAppearanceMovie="SteamBoat", IsFriendly=true }
        };

        [HttpGet]
        public DisneyCharacter[] Get()
        {
            return _characters.ToArray();
        }

        [HttpGet("{id}")]
        public DisneyCharacter? Get(int id)
        {
            try
            {
                return _characters.Find(cd => cd.CharacterId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public int Post(DisneyCharacter newData)
        {
            if (newData == null) throw new Exception();
            if (!_characters.Select(cd => cd.CharacterName).Contains(newData.CharacterName))
            {
                int maxId = _characters.Max(cd => cd.CharacterId);
                newData.CharacterId = maxId+1;
                _characters.Add(newData);
            }
            return newData.CharacterId;
        }

        [HttpPut("{id}")]
        public int Put(int id, DisneyCharacter newData)
        {
            DisneyCharacter? toUpdate = _characters.Find(cd => cd.CharacterId == id);
            if (toUpdate is null) throw new Exception();
            toUpdate.CharacterName = newData.CharacterName;
            toUpdate.FirstAppearanceMovie = newData.FirstAppearanceMovie;
            toUpdate.IsFriendly = newData.IsFriendly;
            return id;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            DisneyCharacter? toDelete = _characters.Find(cd => cd.CharacterId == id);
            if (toDelete is null) throw new Exception();
            _characters.Remove(toDelete);
            return true;
        }
    }
}
