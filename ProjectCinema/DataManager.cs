using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using ProjectCinema.Models;

namespace ProjectCinema
{
    class DataManager : DbProvider
    {
        List<Category> categories;
        List<AgeRestriction> ageRestrictions;
        List<Film> films;
        List<Hall> halls;
        List<Session> sessions;
        List<Place> places;
        List<Ticket> tickets;



        public DataManager()
        {
            categories = new List<Category>();
            ageRestrictions = new List<AgeRestriction>();
            films = new List<Film>();
            halls = new List<Hall>();
            sessions = new List<Session>();
            places = new List<Place>();
            tickets = new List<Ticket>();

        }

        public void LoadData()
        {
            string queryCategories = "SELECT * FROM Category";
            string queryaAgeRestriction = "SELECT * FROM AgeRestriction";
            string queryFilm = "SELECT * FROM Films";
            string queryHall = "SELECT * FROM Halls";
            string querySession = "SELECT * FROM Session";
            string queryPlace = "SELECT * FROM Plases";
            string queryTicket = "SELECT * FROM Tickets";
            connection.Open();
            SqlCommand cmd;
            SqlDataReader reader;

            //queryCategories
            cmd = new SqlCommand(queryCategories, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category c = new Category(
                    reader["Name"].ToString()
                    );
                categories.Add(c);
            }

            //AgeRestriction
            cmd = new SqlCommand(queryaAgeRestriction, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AgeRestriction ar = new AgeRestriction(
                    (int)reader["Age"]
                    );
                ageRestrictions.Add(ar);
            }

            //queryFilm
            cmd = new SqlCommand(queryFilm, connection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Film f = new Film(
                    reader["Name"].ToString(),
                    (int)reader["CategoryId"],
                    (int)reader["AgeId"]
                    );
                films.Add(f);
            }

            //queryHall
            cmd = new SqlCommand(queryHall, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Hall h = new Hall(
                    reader["Name"].ToString()
                    );
                halls.Add(h);
            }

            //querySession
            cmd = new SqlCommand(querySession, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Session s = new Session(
                    (int)reader["HallId"],
                    (DateTime)reader["DateTime"],
                    (int)reader["FilmId"]
                    );
                sessions.Add(s);
            }

            //queryPlace
            cmd = new SqlCommand(queryPlace, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Place p = new Place(
                    (int)reader["HallId"],
                    (int)reader["Row"]
                    );
                places.Add(p);
            }

            //queryTicket
            cmd = new SqlCommand(queryTicket, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket t = new Ticket(
                    (int)reader["PlaceId"],
                    (int)reader["SessionId"],
                    (DateTime)reader["DateTime"]
                    );
                tickets.Add(t);
            }

            connection.Close();
        }


    }
}
