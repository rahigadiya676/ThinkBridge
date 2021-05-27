using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ItemAccessLayer
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public IEnumerable<Inventory> GetAllItem()
        {
            try
            {
                List<Inventory> lstStudent = new List<Inventory>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Inventory Item = new Inventory();
                        Item.id = Convert.ToInt32((rdr["Id"]));
                        Item.Name = (rdr["Name"]).ToString();
                        Item.Description = (rdr["Description"]).ToString();
                        Item.Price = Convert.ToInt32(rdr["Price"]);


                        lstStudent.Add(Item);
                    }
                    con.Close();
                }
                return lstStudent;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public Inventory GetItemById(int? id)
        {
            Inventory Item = new Inventory();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM ItemInventory WHERE Id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Item.id = Convert.ToInt32(rdr["Id"]);
                        Item.Name = rdr["Name"].ToString();
                        Item.Description = rdr["Description"].ToString();
                        Item.Price = Convert.ToInt32(rdr["Price"]);

                    }
                    return Item;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public string AddItem(Inventory Item)
        {
            string message = "success";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", Item.Name);
                    cmd.Parameters.AddWithValue("@Description", Item.Description);
                    cmd.Parameters.AddWithValue("@Price", Item.Price);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return message;
                }
            }
            catch (Exception ex)
            {
                return "exception";
            }

        } 
        public void UpdateItem(Inventory Item)
    {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", Item.id);
                    cmd.Parameters.AddWithValue("@Name", Item.Name);
                    cmd.Parameters.AddWithValue("@Description", Item.Description);
                    cmd.Parameters.AddWithValue("@Price", Item.Price);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch(Exception ex)
            {

            }
    }
        public void DeleteItem(int? id)
    {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
       
      }


   }
}
    

