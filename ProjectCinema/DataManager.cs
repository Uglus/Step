using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace ProjectCinema
{
    class DataManager : DbProvider
    {
        public List<Category> categories;
        public List<AgeRestriction> ageRestrictions;
        public List<Film> films;
        public List<Hall> halls;
        public List<Session> sessions;
        public List<Place> places;
        public List<Ticket> tickets;

        public DataManager()
        {
            categories = new List<Category>();
            ageRestrictions = new List<AgeRestriction>();
            films = new List<Film>();
            halls = new List<Hall>();
            sessions = new List<Session>();
            places = new List<Place>();
            tickets = new List<Ticket>();
            LoadData();
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
            connection.Close();
            connection.Open();

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
            connection.Close();
            connection.Open();
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
            connection.Close();
            connection.Open();
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
            connection.Close();
            connection.Open();
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
            connection.Close();
            connection.Open();
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
            connection.Close();
            connection.Open();
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
