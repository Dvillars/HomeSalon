using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
    public class Client
    {
        private int _id;
        private string _name;
        private int _idStylist;

        public Client(string Name, int IdStylist, int Id = 0)
        {
            _id = Id;
            _name = Name;
            _idStylist = IdStylist;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string newName)
        {
            _name = newName;
        }

        public int GetIdStylist()
        {
            return _idStylist;
        }
        public void SetIdStylist(int newIdStylist)
        {
            _idStylist = newIdStylist;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.GetId() == newClient.GetId();
                bool nameEquality = this.GetName() == newClient.GetName();
                bool IdStylistEquality = this.GetIdStylist() == newClient.GetIdStylist();
                return (idEquality && nameEquality && IdStylistEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientIdStylist = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientIdStylist, clientId);
                allClients.Add(newClient);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allClients;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientIdStylist);", conn);

            SqlParameter nameParameter = new SqlParameter();
            SqlParameter idStylistParameter = new SqlParameter();
            nameParameter.ParameterName = "@ClientName";
            idStylistParameter.ParameterName = "@ClientIdStylist";
            nameParameter.Value = this.GetName();
            idStylistParameter.Value = this.GetIdStylist();
            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(idStylistParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Client Find(int id)
        {
           SqlConnection conn = DB.Connection();
           conn.Open();

           SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
           SqlParameter clientIdParameter = new SqlParameter();
           clientIdParameter.ParameterName = "@ClientId";
           clientIdParameter.Value = id.ToString();
           cmd.Parameters.Add(clientIdParameter);
           SqlDataReader rdr = cmd.ExecuteReader();

           int foundClientId = 0;
           string foundClientName = null;
           int foundClientIdStylist = 0;

           while(rdr.Read())
           {
               foundClientId = rdr.GetInt32(0);
               foundClientName = rdr.GetString(1);
               foundClientIdStylist = rdr.GetInt32(2);
           }
           Client foundClient = new Client(foundClientName, foundClientIdStylist, foundClientId);

           if (rdr != null)
           {
               rdr.Close();
           }
           if (conn != null)
           {
               conn.Close();
           }
           return foundClient;
       }

       public string GetStylistName(int id)
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
          SqlParameter idStylistParameter = new SqlParameter();
          idStylistParameter.ParameterName = "@StylistId";
          idStylistParameter.Value = id.ToString();
          cmd.Parameters.Add(idStylistParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          string foundStylistName = null;

          while(rdr.Read())
          {
            foundStylistName = rdr.GetString(1);
          }


          if (rdr != null)
          {
            rdr.Close();
          }
          if (conn != null)
          {
            conn.Close();
          }
          return foundStylistName;
        }

        public static List<Client> GetByStylist(int id)
        {

            List<Client> foundByStylistClients = new List<Client>{};
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);

            SqlParameter stylistParameter = new SqlParameter();
            stylistParameter.ParameterName = "@StylistId";
            stylistParameter.Value = id;
            cmd.Parameters.Add(stylistParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int foundId = rdr.GetInt32(0);
                string foundName = rdr.GetString(1);
                int foundStylistId = rdr.GetInt32(2);
                Client foundClient = new Client(foundName, foundStylistId, foundId);
                foundByStylistClients.Add(foundClient);
            }

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }

            return foundByStylistClients;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
