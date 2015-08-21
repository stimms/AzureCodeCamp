using System;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Npgsql;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;
using Dapper;

namespace PancakeProwler.Data.Postgres.Repositories
{
    public class RecipeRepository : IRecipeRepository, IPostgresRepository
    {
        public IEnumerable<Recipe> List()
        {
            using ( var conn = new NpgsqlConnection( ConnectionString ) ) {
                conn.Open( );
                return conn.Query<Recipe>("SELECT * FROM Recipes");
            }
        }

        public void Create(Recipe recipe)
        {
        }

        public void Edit(Recipe recipe)
        {
        }

        public Recipe GetById(Guid id)
        {

            using ( var conn = new NpgsqlConnection( ConnectionString ) ) {
                conn.Open( );
                return conn.Query<Recipe>("SELECT * FROM Recipes WHERE Id=@id", new { id }).SingleOrDefault();
            }
        }

        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString; }
        }

        public void InitPostgresStorage()
        {
            var sql = @"DROP TABLE IF EXISTS recipes;
CREATE TABLE recipes
(
  ""id"" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid,
  ""name"" text NOT NULL DEFAULT ''::text,
  ""contributor"" text,
  ""ingredients"" text,
  ""steps"" text,
  ""image_location"" text,
  CONSTRAINT ""pk_recipes"" PRIMARY KEY (""id"")
);";
            using ( var conn = new NpgsqlConnection( ConnectionString ) )
            {
                conn.Open();
                conn.Execute(sql);
            }
        }
    }
}
