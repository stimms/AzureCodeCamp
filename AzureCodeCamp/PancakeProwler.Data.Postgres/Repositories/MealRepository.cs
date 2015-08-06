using System;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Npgsql;
using PancakeProwler.Data.Common.Models;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Data.Postgres.Repositories
{
    public class MealRepository : IMealRepository, IPostgresRepository
    {
        public IEnumerable<Meal> List()
        {
            using ( var conn = new NpgsqlConnection( ConnectionString ) ) {
                conn.Open( );
                return conn.Query<Meal>("SELECT * FROM meals");
            }
        }

        public void Create(Meal meal)
        {
            var sql =
                @"INSERT INTO meals (id, name, sponsor_name, sponsor_website, sponsor_email, sponsor_twitter, contact_name, contact_email, contact_phone_number, address, latitude, longitude, date, description, image_location)
VALUES (@Id, @Name, @SponsorName, @SponsorWebSite, @SponsorEmail, @SponsorTwitter, @ContactName, @ContactEmail, @ContactPhoneNumber, @Address, @Latitude, @Longitude, @Date, @Description, @ImageLocation);";
            using ( var conn = new NpgsqlConnection( ConnectionString ) ) {
                conn.Open( );
                conn.Execute(sql, new
                                  {
                                      meal.Id,
                                      meal.Name,
                                      meal.SponsorName,
                                      meal.SponsorWebSite,
                                      meal.SponsorEMail,
                                      meal.SponsorTwitter,
                                      meal.ContactName,
                                      meal.ContactEMail,
                                      meal.ContactPhoneNumber,
                                      meal.Address,
                                      meal.Latitude,
                                      meal.Longitude,
                                      meal.Date,
                                      meal.Description,
                                      meal.ImageLocation
                                  });
            }
        }

        public void Edit(Meal meal)
        {
        }

        public Meal GetById(Guid id)
        {
            using ( var conn = new NpgsqlConnection( ConnectionString ) ) {
                conn.Open( );
                return conn.Query<Meal>("SELECT * FROM meals WHERE Id=@id", new { id }).SingleOrDefault();
            }
        }

        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString; }
        }

        public void InitPostgresStorage()
        {
            var sql = @"DROP TABLE IF EXISTS meals;
CREATE TABLE meals
(
  ""id"" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'::uuid,
  ""name"" text NOT NULL DEFAULT ''::text,
  ""sponsor_name"" text,
  ""sponsor_website"" text,
  ""sponsor_email"" text,
  ""sponsor_twitter"" text,
  ""contact_name"" text NOT NULL DEFAULT ''::text,
  ""contact_email"" text,
  ""contact_phone_number"" text,
  ""address"" text,
  ""latitude"" numeric(18,2) NOT NULL DEFAULT 0,
  ""longitude"" numeric(18,2) NOT NULL DEFAULT 0,
  ""date"" timestamp without time zone NOT NULL DEFAULT '-infinity'::timestamp without time zone,
  ""description"" text,
  ""image_location"" text,
  CONSTRAINT ""pk_meals"" PRIMARY KEY (""id"")
);";
            using ( var conn = new NpgsqlConnection( ConnectionString ) )
            {
                conn.Open();
                conn.Execute(sql);
            }
        }
    }
}