using DeLaSalle.Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSalle.Ecommerce.Core.Dto
{
    public class BrandDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public BrandDto()
        {

        }
        public BrandDto(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            Description = brand.Description;
        }
    }
}