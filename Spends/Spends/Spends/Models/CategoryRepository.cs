using System.Text;
using Spends.Connection;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Spends.Models
{
    public class CategoryRepository
    {
        ConnectionParameters connection;

        public CategoryRepository()
        {
            connection = new ConnectionParameters();
        }

        //Função para buscar uma categoria no banco através do ID, recebido por parâmentro
        public Category selectById(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("SELECT * FROM Categories WHERE idCategory=@idCategory");
            command.Parameters.AddWithValue("idCategory", pId);
            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            Category category = null;

            //Verifica se o dataReader possui a categoria que está sendo buscada
            //Se tiver, retorna as informações do banco para um objeto do tipo Category
            if (dataReader.Read())
            {
                category = new Category
                {
                    idCategory = (int)dataReader["idCategory"],
                    name = dataReader["name"].ToString()
                };
            }
            return category;
        }

        //Função para presistir no banco de dados uma categoria recebida por parâmentro 
        public void Create(Category c)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("INSERT INTO Categories (name) ");
            sql.Append("values (@name)");

            cmm.Parameters.AddWithValue("@name", c.name);
            cmm.CommandText = sql.ToString();

            connection.executeCommand(cmm);
        }

        //Função que busca no banco todas categorias cadastradas
        //Retorna uma lista com todos as categorias encontradas
        public List<Category> getAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List <Category> category = new List<Category>();

            sql.Append("SELECT * FROM Categories ");
            sql.Append("ORDER BY name ASC");

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while(dataReader.Read())
            {
                category.Add(new Category
                {
                    idCategory = (int)dataReader["idCategory"],
                    name = dataReader["name"].ToString()
                });
            }
            return category;
        }

        //Função para salvar as alterações de uma categoria já persistida no banco, recebida como parâmetro
        public void Update(Category c)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("UPDATE Categories SET `name`=@name WHERE `idCategory`=@idCategory");

            cmm.Parameters.AddWithValue("@idCategory", c.idCategory);
            cmm.Parameters.AddWithValue("@name", c.name);

            cmm.CommandText = sql.ToString();

            connection.executeCommand(cmm);
        }

        //Função para deletar uma categoria já persistida no banco, através de um ID recebido por parâmetro
        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM `Categories` WHERE `idCategory`=@idCategory");

            cmm.Parameters.AddWithValue("@idCategory", pId);
            cmm.CommandText = sql.ToString();

            connection.executeCommand(cmm);
        }

    }
}