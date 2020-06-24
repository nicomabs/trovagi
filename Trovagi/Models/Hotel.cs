using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trovagi.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [StringLength(75)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(25)]
        public string PhotoName { get; set; }

        public Boolean IsSelected { get; set; }

        //ManyToOne
        public int CityId { get; set; }                 // PROPRIETE DE CLE : clé étrangère / cela empeche entityframework de l'ajouter !
        public virtual City City { get; set; }      // PROPRIETE DE NAVIGATION car à partir d'un produit je peux avoir des infos sur la catégorie...
        //les attributs d'association doivent être virtuel car les frameworks utilisent le mode Lazy Loading afin de ne récupérer que les données pertinentes ici
        //la catégorie d'un produit n'est necessaire que si on en fait la demande ici donc à entityframework
    }
}

