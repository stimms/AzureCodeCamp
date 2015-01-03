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
            AutoMapper.Mapper.Configuration.CreateMap<Recipe, RecipeTableEntity>().ForMember(x => x.RowKey, y => y.MapFrom(z => z.Id));
            AutoMapper.Mapper.Configuration.CreateMap<RecipeTableEntity, Recipe>();

            AutoMapper.Mapper.Configuration.CreateMap<Meal, MealTableEntity>().ForMember(x => x.RowKey, y => y.MapFrom(z => z.Id));
            AutoMapper.Mapper.Configuration.CreateMap<MealTableEntity, Meal>();
        }
    }
}
