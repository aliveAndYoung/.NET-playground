﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName( "Category Name" )]
        [MaxLength( 100 )]
        public string Name { get; set; }

        [DisplayName( "Display Order" )]
        [Range(1 , 100 , ErrorMessage =" dsipaly order takes values in range 1 to 100")]

        public int DisplayOrder { get; set; }
    }
}
