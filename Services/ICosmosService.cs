using tester.Models;

namespace tester.Services;

public interface ICosmosService
{
    public async Task<IEnumerable<Character>> RetrieveActiveProductsAsync()
    {
        await Task.Delay(1);

        return new List<Character>()
        {
            new Character(id: "def0", categoryId: "def", categoryName: "def", name: "def1", description: "def1", ST: 1, DX:1, IQ:1, HT:1,playerName:"def")
          //  new Character(id: "bd43543e-024c-4cda-a852-e29202310214", categoryId: "973B839C-BF5D-485D-9D17-863C59B262E3", categoryName: "Components, Forks",  name: """ML Fork""", description: """The product called "ML Fork".""", ST: 17, DX:9, IQ:8, HT:14,playerName:"def"),
           
                   };
    }

    public async Task<IEnumerable<Character>> RetrieveAllProductsAsync()
    {
        await Task.Delay(1);

        return new List<Character>()
        {
             new Character(id: "def1", categoryId: "def", categoryName: "def", name: "def2", description: "def2", ST: 1, DX:1, IQ:1, HT:1,playerName:"def")
           // new Character(id: "b1a8a599-f876-468f-be58-d96ed1f21ca8", categoryId: "AE48F0AA-4F65-4734-A4CF-D48B8F82267F", categoryName: "Bikes, Road Bikes", name: """Road-650 Red, 48""", description: """The product called "Road-650 Red, 48".""", ST: 12, DX:9, IQ:16, HT:11,playerName:"def"),
      };
    }


     public async Task<IEnumerable<Character>> ReplaceCharacterAsync()
    {
      await Task.Delay(1);
      return new List<Character>()
      { new Character(id: "def1", categoryId: "def", categoryName: "def", name: "def2", description: "def2", ST: 1, DX:1, IQ:1, HT:1,playerName:"def")
      };
    }


    public async Task<IEnumerable<Skill>> RetrieveActiveSkillsAsync(string pKey)
    {
 await Task.Delay(1);
      return new List<Skill>()
      { new Skill(Id:"def1",PartitionKey:"def1",SkillName:"def1",Description:"def1",Notes:"",Difficulty:"",Attribute:"",false,0,false,null,null,null)
      };

    }
}