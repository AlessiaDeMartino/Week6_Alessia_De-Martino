using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_WEEK6
{
    class DbAgentiManager : IDbManager
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<Agente> GetAllAgents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agenti";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();
                while (reader.Read())
                {                    
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice Fiscale"];
                    string area = (string)reader["AreaGeografica"];
                    int anno = (int)reader["AnnoInizioAttivita"];

                    Agente agente = new Agente(nome, cognome, cf, area, anno);
                    agenti.Add(agente);
                }
                connection.Close();
                return agenti;
            }
        }

        public bool AddAgent(string nome, string cognome, string codicefiscale, string areagrografica, int annoInizioAttivita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agenti values(@Nome, @Cognome, @CodiceFiscale, @Area, @AnnoInizioAttivita)";
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Cognome", cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", codicefiscale);
                command.Parameters.AddWithValue("@Area", areagrografica);
                command.Parameters.AddWithValue("@AnnoInizioAttivita", annoInizioAttivita);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        internal List <Agente> PrintAreeGeografiche()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agenti";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agentiAree = new List<Agente>();
                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice Fiscale"];
                    string area = (string)reader["AreaGeografica"];
                    int anno = (int)reader["AnnoInizioAttivita"];


                    Agente agente = new Agente(nome, cognome, cf, area, anno);
                    agentiAree.Add(agente);           
                 }
                connection.Close();
                foreach (var ag in agentiAree)
                {
                    Console.WriteLine($"{ag.AreaGeografica}");
                }
                return agentiAree;

            }
        }        

        public Agente GetAgentByCF(string codicefiscale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agenti where [Codice Fiscale] = @cf"; //nelle query metti le quadreee
                command.Parameters.AddWithValue("@cf", codicefiscale);

                SqlDataReader reader = command.ExecuteReader();

                Agente agenteCheck = null;

                while (reader.Read())
                {

                    string cf = (string)reader["Codice Fiscale"];
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int anno = (int)reader["AnnoInizioAttivita"];
                    
                    agenteCheck = new Agente(nome, cognome, cf, areaGeografica, anno);
                    
                }
                connection.Close();
                return agenteCheck;
            }
        }

        public List<Agente> GetAgentByYear(int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agenti where AnnoInizioAttivita <= @anno";
                command.Parameters.AddWithValue("@anno", (DateTime.Now.Year - year));

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti_Anni = new List<Agente>();

                while (reader.Read())
                {
                    string cf = (string)reader["Codice Fiscale"];
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int anno = (int)reader["AnnoInizioAttivita"];

                    Agente agenteAnniServizio = new Agente(nome, cognome, cf, areaGeografica, anno);
                    agenti_Anni.Add(agenteAnniServizio);
                }

                connection.Close();
                return agenti_Anni;
            }
        }

        public List<Agente> GetAgentsByArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agenti where AreaGeografica = @Area";
                command.Parameters.AddWithValue("@Area", area);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti_Area = new List<Agente>();

                while (reader.Read())
                {
                    string cf = (string)reader["Codice Fiscale"];
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int anno = (int)reader["AnnoInizioAttivita"];

                    Agente agenteArea = new Agente(nome, cognome, cf, area, anno);
                    agenti_Area.Add(agenteArea);
                }

                connection.Close();
                return agenti_Area;
            }


        }
    }
}
