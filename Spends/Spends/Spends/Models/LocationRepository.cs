using MySql.Data.MySqlClient;
using Spends.Connection;
using System.Collections.Generic;
using System.Text;


namespace Spends.Models
{
    public class LocationRepository
    {
        ConnectionParameters connection;

        public LocationRepository()
        {
            connection = new ConnectionParameters();
        }

        //Função para buscar uma localidade no banco através do ID, recebido por parâmentro
        public Location selectById(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("SELECT * FROM Locations WHERE idLocation=@idLocation");
            command.Parameters.AddWithValue("idLocation", pId);
            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            Location location = null;

            //Verifica se o dataReader possui a localidade que está sendo buscada
            //Se tiver, retorna as informações do banco para um objeto do tipo Location
            if (dataReader.Read())
            {
                location = new Location
                {
                    idLocation = (int)dataReader["idLocation"],
                    description = dataReader["description"].ToString()
                };
            }
            return location;
        }

        //Função para presistir no banco de dados uma localidade recebida por parâmentro 
        public void Create(Location l)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("INSERT INTO Locations (description) ");
            sql.Append("values (@description)");

            command.Parameters.AddWithValue("@description", l.description);
            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

        //Função que busca no banco todas as localidades cadastradas
        //Retorna uma lista com todos as localidades encontradas
        public List<Location> getAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List<Location> location = new List<Location>();

            sql.Append("SELECT * FROM Locations ");
            sql.Append("ORDER BY description ASC");

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while (dataReader.Read())
            {
                location.Add(new Location
                {
                    idLocation = (int)dataReader["idLocation"],
                    description = dataReader["description"].ToString()
                });
            }
            return location;
        }

        //Função para salvar as alterações de uma localidade já persistida no banco, recebida como parâmetro
        public void Update(Location l)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("UPDATE Locations SET `description`=@description WHERE `idLocation`=@idLocation");

            command.Parameters.AddWithValue("@idLocation", l.idLocation);
            command.Parameters.AddWithValue("@description", l.description);

            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

        //Função para deletar uma localidade já persistida no banco, através de um ID recebido por parâmetro
        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("DELETE FROM `Locations` WHERE `idLocation`=@idLocation");

            command.Parameters.AddWithValue("@idLocation", pId);
            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

    }
}