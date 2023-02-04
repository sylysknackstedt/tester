using tester.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using tester.Services;


namespace tester.Services;

public class CosmosService : ICosmosService
{ 
    private readonly CosmosClient _client;

    public CosmosService()
    {

       




 _client = new CosmosClient(
            connectionString: "AccountEndpoint=https://delphi1.documents.azure.com:443/;AccountKey=23PHq3K8nsNPzV0RACq4Y2f96T4ksN5r0xoauFqudGNDFlswFWO6n44Dxzph8Ol34XoVm9AHjTozACDbemJy0A==;"
        );





     
    }

    private Container container
    {
        get => _client.GetDatabase("GURPS").GetContainer("Characters");
    }

     private Container container2
    {
        get => _client.GetDatabase("GURPS").GetContainer("Skills");
    }



 public async Task<IEnumerable<Character>> ReplaceCharacterAsync()
    { 
        var queryable = container.GetItemLinqQueryable<Character>();




        using FeedIterator<Character> feed = queryable
           // .Where(p => p.playerName =="Sy")
            .OrderByDescending(p => p.ST)
            .ToFeedIterator();

        List<Character> results = new();

        while (feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync();
            foreach (Character item in response)
            {
                Character fix=new Character(id: item.id, categoryId: item.categoryId, categoryName: item.categoryName, name: item.name, description: item.description, ST: item.ST, DX:item.DX, IQ:item.IQ, HT:item.HT+5,playerName:"Sy");
                
                ItemResponse<Character> item2 = await this.container.ReplaceItemAsync<Character>(fix,fix.id);
            }
        }

        return results;
    }


//  RetrieveActiveSkillsAsync()

 public async Task<IEnumerable<Skill>> RetrieveActiveSkillsAsync(string pKey)
{ 

//string param = "WHERE p.partitionKey =\""+pKey+"\"" ;



        string sql = """
        SELECT
            p.id,
            p.partitionKey,
            p.SkillName,
            p.Defaults,
            p.Description,
            p.Difficulty,
            p.Attribute,
            p.Notes,
            p.Tech,
            p.TechLevel,
            p.Prerequisites,
            p.Specialty,
            p.SpecialtyRequired
        FROM Skills p
        WHERE p.partitionKey = @tagFilter
        ORDER BY p.SkillName
        """;
// WHERE p.partitionKey = "social"
        var query = new QueryDefinition(
            query: sql
        ).WithParameter("@tagFilter", pKey);
        
        //.WithParameter("@tagFilter", pKey);;
        
        //.WithParameter("@tagFilter", pKey);
        //.WithParameter("@tagFilter", "Sy");

        using FeedIterator<Skill> feed = container2.GetItemQueryIterator<Skill>(
            queryDefinition: query
        );

        List<Skill> results = new();

        while (feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync();
            foreach (Skill item in response)
            {
                results.Add(item);
            }
        }
        return results;
    }


    public async Task<IEnumerable<Character>> RetrieveAllProductsAsync()
    { 
        var queryable = container.GetItemLinqQueryable<Character>();

        using FeedIterator<Character> feed = queryable
            .Where(p => p.playerName =="Sy")
            .OrderByDescending(p => p.ST)
            .ToFeedIterator();

        List<Character> results = new();

        while (feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync();
            foreach (Character item in response)
            {
                results.Add(item);
            }
        }

        return results;
    }

    public async Task<IEnumerable<Character>> RetrieveActiveProductsAsync()
    { 
        string sql = """
        SELECT
            p.id,
            p.categoryId,
            p.categoryName,
            p.name,
            p.description,
            p.ST,
            p.DX,
            p.IQ,
            p.HT,
            p.playerName
        FROM Characters p
        WHERE p.playerName="Sy"
""";

   //     JOIN t IN p.tags
      //  WHERE t.playerName = @tagFilter
     //   """;

        var query = new QueryDefinition(
            query: sql
        );
        //.WithParameter("@tagFilter", "Sy");

        using FeedIterator<Character> feed = container.GetItemQueryIterator<Character>(
            queryDefinition: query
        );

        List<Character> results = new();

        while (feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync();
            foreach (Character item in response)
            {
                results.Add(item);
            }
        }

        return results;
    }
}