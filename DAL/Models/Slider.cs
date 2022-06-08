using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;
using Microsoft.AspNetCore.Http;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Body { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }

}
