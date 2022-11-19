using DeLaSalle.Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSalle.Ecommerce.Core.Dto
{
    public class ProductCategoryDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductCategoryDto()
        {

        }
        public ProductCategoryDto(ProductCategory category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
    }
}