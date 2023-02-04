namespace tester.Models;

public record Character(
    string id,
    string categoryId,
    string categoryName,
    string name,
    string description,
    int ST,
    int DX,
    int IQ,
    int HT,
    string playerName
);

 public record Skill
    (
     
        string Id,
     
        string PartitionKey,

        string SkillName,

        string Description,

        string Notes,

        string Difficulty,

        string Attribute,

        Boolean Tech,

       int? TechLevel,

         Boolean SpecialtyRequired,

        string[]? Specialty,

        string[]? Prerequisites,

        SkillDefault[]? Defaults

        
    );


    public record SkillDefault
        (
        string AttributeName,
        string SkillName,
        int SkillModifier 

        );