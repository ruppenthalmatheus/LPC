using Association.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Association.Models
{
    public class CityRepository
    {
        FioTerra fioTerra;        

        public CityRepository()
        {
            fioTerra = new FioTerra();
        }

        //Função para buscar uma cidade no banco através do ID, recebido por parâmentro
        public City SelectById(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("SELECT * FROM cities WHERE id=@id");
            command.Parameters.AddWithValue("@id", pId);
            command.CommandText = sql.ToString();

            MySqlDataReader dr = fioTerra.getDataReader(command);

            City city = null;

            //Verifica se o dataReader possui a cidade que está sendo buscada
            //Se tiver, retorna as informações do banco para um objeto do tipo City
            if (dr.Read())
            {
                city = new City
                {
                    id = (int)dr["id"],
                    name = dr["name"].ToString(),
                    state = dr["state"].ToString()
                };
            }
            return city;
        }

        //Função para presistir no banco de dados uma cidade recebida por parâmentro 
        public void Create(City city)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("INSERT INTO cities(name, state) ");
            sql.Append("values (@name, @state)");

            cmm.Parameters.AddWithValue("@name", city.name);
            cmm.Parameters.AddWithValue("@state", city.state);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        //Função que busca no banco todas cidades cadastradas
        //Retorna uma lista com todos as cidades encontradas
        public List<City> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            List<City> city = new List<City>();

            sql.Append("SELECT * FROM cities");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = fioTerra.getDataReader(cmm);

            while (dr.Read())
            {
                city.Add(new City
                {
                    id = (int)dr["id"],
                    name = dr["name"].ToString(),
                    state = dr["state"].ToString()
                });
            }

            return city;
        }

        //Função para salvar as alterações de uma cidade já persistida no banco, recebida como parâmetro
        public void Update(City city)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("UPDATE cities SET `name`=@name, `state`=@state WHERE `id`=@id;");

            cmm.Parameters.AddWithValue("@id", city.id);
            cmm.Parameters.AddWithValue("@name", city.name);
            cmm.Parameters.AddWithValue("@state", city.state);

            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        //Função para deletar uma cidade já persistida no banco, através de um ID recebido por parâmetro
        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM `cities` WHERE `id`=@id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }
    }
}