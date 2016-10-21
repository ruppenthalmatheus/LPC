using MySql.Data.MySqlClient;
using Spends.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Spends.Models
{
    public class SpendRepository
    {
        ConnectionParameters connection;

        public SpendRepository()
        {
            connection = new ConnectionParameters();
        }

        //Função para buscar uma despesa no banco através do ID, recebido por parâmentro
        public Spend selectById(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("SELECT S.idSpend AS idSpend, C.idCategory as idCategory, C.name AS name, ");
            sql.Append("L.idLocation as idLocation, L.description AS description, S.spendDate AS spendDate, S.total as total ");
            sql.Append("FROM Spends S ");
            sql.Append("INNER JOIN Locations L  ON S.IdLocation = L.idLocation ");
            sql.Append("INNER JOIN Categories C  ON S.idCategory = C.idCategory ");
            sql.Append("WHERE S.idSpend=@idSpend;");

            command.Parameters.AddWithValue("idSpend", pId);
            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            Spend spend = null;

            //Verifica se o dataReader possui a despesa que está sendo buscada
            //Se tiver, retorna as informações do banco para um objeto do tipo Spend
            if (dataReader.Read())
            {
                spend = new Spend
                {
                    idSpend = (int)dataReader["idSpend"],
                    spendDate = (DateTime)dataReader["spendDate"],
                    total = (decimal)dataReader["total"],
                    category = new Category()
                    {
                        idCategory = (int)dataReader["idCategory"],
                        name = dataReader["name"].ToString()
                    },
                    location = new Location()
                    {
                        idLocation = (int)dataReader["idLocation"],
                        description = dataReader["description"].ToString()
                    }
                };
            }
            return spend;
        }

        //Função para presistir uma despesa recebida por parâmentro no banco de dados
        public void Create(Spend spend)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();


            sql.Append("INSERT INTO Spends(idLocation, idCategory, spendDate, total) ");
            sql.Append("values (@idLocation, @idCategory, @spendDate, @total)");

            command.Parameters.AddWithValue("@idLocation", spend.location.idLocation);
            command.Parameters.AddWithValue("@idCategory", spend.category.idCategory);
            command.Parameters.AddWithValue("@spendDate", spend.spendDate);
            command.Parameters.AddWithValue("@total", spend.total);

            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

        //Função que busca no banco todos as despesas cadastradas
        //Retorna uma lista com todas as despesas encontradas
        public List<Spend> getAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List<Spend> spends = new List<Spend>();

            sql.Append("SELECT S.idSpend AS idSpend, C.idCategory as idCategory, C.name AS name, L.idLocation as idLocation, L.description AS description, S.spendDate AS spendDate, S.total as total ");
            sql.Append("FROM Spends S ");
            sql.Append("INNER JOIN Locations L ON S.IdLocation = L.idLocation ");
            sql.Append("INNER JOIN Categories C ON S.idCategory = C.idCategory ");
            sql.Append("ORDER BY S.idSpend DESC ");
            sql.Append("LIMIT 7");

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while (dataReader.Read())
            {
                spends.Add(new Spend
                {
                    idSpend = (int)dataReader["idSpend"],
                    spendDate = (DateTime)dataReader["spendDate"],
                    total = (decimal)dataReader["total"],
                    category = new Category()
                    {
                        idCategory = (int)dataReader["idCategory"],
                        name = dataReader["name"].ToString()
                    },
                    location = new Location()
                    {
                        idLocation = (int)dataReader["idLocation"],
                        description = dataReader["description"].ToString()
                    }
                });
            }
            return spends;
        }

        //Função para salvar as alterações de uma despesa já persistida no banco, recebida como parâmetro
        public void Update(Spend spend)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();


            sql.Append("UPDATE spends SET idLocation=@idLocation, idCategory=@idCategory, spendDate=@spendDate, total=@total WHERE idSpend=@idSpend");

            command.Parameters.AddWithValue("@idSpend", spend.idSpend);
            command.Parameters.AddWithValue("@idLocation", spend.location.idLocation);
            command.Parameters.AddWithValue("@idCategory", spend.category.idCategory);
            command.Parameters.AddWithValue("@spendDate", spend.spendDate);
            command.Parameters.AddWithValue("@total", spend.total);

            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

        //Função para deletar uma despesa já persistida no banco, através de um ID recebido por parâmetro
        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();


            sql.Append("DELETE FROM spends WHERE `idSpend`=@idSpend");

            command.Parameters.AddWithValue("@idSpend", pId);
            command.CommandText = sql.ToString();

            connection.executeCommand(command);
        }

        //Função para retornar todos os gastos de um determinado período
        public List<Spend> spendsByPeriod(string startDate, string finalDate)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List<Spend> spends = new List<Spend>();

            sql.Append("SELECT S.idSpend AS idSpend, C.name AS name, L.description AS description, ");
            sql.Append("S.spendDate AS spendDate, S.total AS total, C.idCategory AS idCategory, L.idLocation AS idLocation ");
            sql.Append("FROM Spends S INNER JOIN Locations L ON S.IdLocation = L.idLocation ");
            sql.Append("INNER JOIN Categories C ON S.idCategory = C.idCategory ");
            sql.Append("WHERE S.spendDate BETWEEN @startDate AND @finalDate ");
            sql.Append("ORDER BY S.spendDate DESC;");

            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@finalDate", finalDate);

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while (dataReader.Read())
            {
                spends.Add(new Spend
                {
                    idSpend = (int)dataReader["idSpend"],
                    spendDate = (DateTime)dataReader["spendDate"],
                    total = (decimal)dataReader["total"],
                    category = new Category()
                    {
                        idCategory = (int)dataReader["idCategory"],
                        name = dataReader["name"].ToString()
                    },
                    location = new Location()
                    {
                        idLocation = (int)dataReader["idLocation"],
                        description = dataReader["description"].ToString()
                    }
                });
            }
            return spends;
        }

        //Função para retornar todos os gastos de uma determinada categoria e de um determinado período
        public List<Spend> spendsCategoryByPeriod(string startDate, string finalDate, int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List<Spend> spends = new List<Spend>();

            sql.Append("SELECT S.idSpend AS idSpend, C.name AS name, L.description AS description, ");
            sql.Append("S.spendDate AS spendDate, S.total AS total, C.idCategory AS idCategory, L.idLocation AS idLocation ");
            sql.Append("FROM Spends S INNER JOIN Locations L ON S.IdLocation = L.idLocation ");
            sql.Append("INNER JOIN Categories C ON S.idCategory = C.idCategory ");
            sql.Append("WHERE S.spendDate BETWEEN @startDate AND @finalDate ");
            sql.Append("AND C.idCategory = @category ");
            sql.Append("ORDER BY S.spendDate DESC;");

            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@finalDate", finalDate);
            command.Parameters.AddWithValue("@category", id);

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while (dataReader.Read())
            {
                spends.Add(new Spend
                {
                    idSpend = (int)dataReader["idSpend"],
                    spendDate = (DateTime)dataReader["spendDate"],
                    total = (decimal)dataReader["total"],
                    category = new Category()
                    {
                        idCategory = (int)dataReader["idCategory"],
                        name = dataReader["name"].ToString()
                    },
                    location = new Location()
                    {
                        idLocation = (int)dataReader["idLocation"],
                        description = dataReader["description"].ToString()
                    }
                });
            }
            return spends;
        }

        //Função para retornar todos os gastos de um determinado lugar e de um determinado período
        public List<Spend> spendsLocationByPeriod(string startDate, string finalDate, int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            List<Spend> spends = new List<Spend>();

            sql.Append("SELECT S.idSpend AS idSpend, C.name AS name, L.description AS description, ");
            sql.Append("S.spendDate AS spendDate, S.total AS total, C.idCategory AS idCategory, L.idLocation AS idLocation ");
            sql.Append("FROM Spends S INNER JOIN Locations L ON S.IdLocation = L.idLocation ");
            sql.Append("INNER JOIN Categories C ON S.idCategory = C.idCategory ");
            sql.Append("WHERE S.spendDate BETWEEN @startDate AND @finalDate ");
            sql.Append("AND L.idLocation = @location ");
            sql.Append("ORDER BY S.spendDate DESC;");

            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@finalDate", finalDate);
            command.Parameters.AddWithValue("@location", id);

            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = connection.getDataReader(command);

            while (dataReader.Read())
            {
                spends.Add(new Spend
                {
                    idSpend = (int)dataReader["idSpend"],
                    spendDate = (DateTime)dataReader["spendDate"],
                    total = (decimal)dataReader["total"],
                    category = new Category()
                    {
                        idCategory = (int)dataReader["idCategory"],
                        name = dataReader["name"].ToString()
                    },
                    location = new Location()
                    {
                        idLocation = (int)dataReader["idLocation"],
                        description = dataReader["description"].ToString()
                    }
                });
            }
            return spends;
        }

    }
}