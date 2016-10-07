using Association.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Association.Models
{
    public class MemberRepository
    {

        FioTerra fioTerra;

        public MemberRepository()
        {
            fioTerra = new FioTerra();
        }

        //Função para buscar um membro no banco através do ID, recebido por parâmentro
        public Member SelectById(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sql.Append("SELECT m.id as id_member, m.name as member, c.id as id_city,c.name as city FROM members M ");
            sql.Append("INNER JOIN cities C ON m.idC = c.id ");
            sql.Append("WHERE m.id=@id");
            command.Parameters.AddWithValue("@id", pId);
            command.CommandText = sql.ToString();

            MySqlDataReader dataReader = fioTerra.getDataReader(command);

            Member member = null;
            
            //Verifica se o dataReader possui o elemento que está sendo buscado
            //Se tiver, retorna as informações do banco para um objeto do tipo Member
            if (dataReader.Read())
            {
                member = new Member
                {
                    id = (int)dataReader["id_member"],
                    name = dataReader["member"].ToString(),
                    city = new City()
                    {
                        id = (int)dataReader["id_city"],
                        name = dataReader["city"].ToString()
                    }
                };
            }
            return member;
        }

        //Função para presistir um membro recebido por parâmentro no banco de dados
        public void Create(Member member)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("INSERT INTO members(name, idC) ");
            sql.Append("values (@name, @idC)");

            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.Parameters.AddWithValue("@idC", member.city.id);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        //Função que busca no banco todos os membros cadastrados
        //Retorna uma lista com todos os membros encontrados
        public List<Member> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            List<Member> members = new List<Member>();

            sql.Append("SELECT m.id as id_member, m.name as member, c.id as id_city, c.name as city FROM members M ");
            sql.Append("INNER JOIN cities C ON m.idC = c.id; ");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = fioTerra.getDataReader(cmm);

            while (dr.Read())
            {
                members.Add(new Member
                {
                    id = (int)dr["id_member"],
                    name = dr["member"].ToString(),
                    city = new City()
                    {
                        id = (int)dr["id_city"],
                        name = dr["city"].ToString()
                    }
                });
            }

            return members;
        }

        //Função para salvar as alterações de um membro já persistido no banco, recebido como parâmetro
        public void Update(Member member)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("UPDATE members SET name=@name, idC=@idC WHERE id=@id");

            cmm.Parameters.AddWithValue("@id", member.id);
            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.Parameters.AddWithValue("@idC", member.city.id);


            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        //Função para deletar um membro já persistido no banco, através de um ID recebido por parâmetro
        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM `members` WHERE `id`=@id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

    }

}