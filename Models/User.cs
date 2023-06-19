using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoFramework;

namespace WebApplication1.Models
{
    public class User
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }

        //JsonIgnore]
        //public List<Review>? Reviews { get; set; } //navigation property




    }
}
