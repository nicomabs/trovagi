using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Trovagi.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }     // par convention, il faut que le nom de l'attribut corresponde à l'att de Hotel(clé étrangère) sans quoi il faudra ajouter des mécanismes d'annotations suplémentaire...

        [StringLength(25)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Hotel> Hotels { get; set; }  //virtual pour lazy loading
    }
}