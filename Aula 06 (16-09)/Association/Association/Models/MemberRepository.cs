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


        public Member SelectById(int pId)
        {
            StringBuilder sb = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            sb.Append("SELECT * FROM members WHERE id=@id");
            command.Parameters.AddWithValue("@id", pId);
            command.CommandText = sb.ToString();
            MySqlDataReader dataReader = fioTerra.getDataReader(command);

            Member member = null;
            
            //Verificação para ver se o dataReader possui o elemento que está sendo buscado
            if (dataReader.Read())
            {
                member = new Member
                {
                    id = (int)dataReader["id"],
                    name = dataReader["name"].ToString()
                };
            }
            return member;
        }

        public void Create(Member member)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("INSERT INTO members(name) ");
            sql.Append("values (@name)");

            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

        public List<Member> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            List<Member> members = new List<Member>();

            sql.Append("SELECT * FROM members");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = fioTerra.getDataReader(cmm);

            while (dr.Read())
            {
                members.Add(new Member
                {
                    id = (int)dr["id"],
                    name = dr["name"].ToString()
                });
            }

            return members;
        }

        public void Update(Member member)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("UPDATE members SET name=@name WHERE id=@id");

            cmm.Parameters.AddWithValue("@name", member.name);
            cmm.Parameters.AddWithValue("@id", member.id);
            cmm.CommandText = sql.ToString();

            fioTerra.ExecuteCommand(cmm);
        }

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