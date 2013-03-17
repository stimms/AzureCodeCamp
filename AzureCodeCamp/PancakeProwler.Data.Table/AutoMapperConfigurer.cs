using System;
using System.Linq;
using System.Collections.Generic;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Table.TableEntities;

namespace PancakeProwler.Data.Table
{
    class AutoMapperConfigurer
    {
        
        public static void Configure()
        {
            AutoMapper.Mapper.Configuration.CreateMap<Recipe, RecipeTableEntity>();
            AutoMapper.Mapper.Configuration.CreateMap<RecipeTableEntity, Recipe>();

            AutoMapper.Mapper.Configuration.CreateMap<Meal, MealTableEntity>();
            AutoMapper.Mapper.Configuration.CreateMap<MealTableEntity, Meal>();
        }
    }
}
