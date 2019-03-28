using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModelLibrary;

namespace RestService.DBUtil
{
    public class Manage_Frontpage : IManage_Frontpage
    {
        public List<Frontpage> GetAllFrontpages()
        {
            List<Frontpage> frontpages = new List<Frontpage>();
            string queryString = "SELECT * FROM Frontpage";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Frontpage frontpage = new Frontpage();

                        frontpage.ProcessOrder_No = reader.GetInt32(0);
                        frontpage.Date = reader.GetDateTime(1);
                        frontpage.FinishedProduct_No = reader.GetInt32(2);
                        frontpage.Note = reader.GetString(3);

                        frontpages.Add(frontpage);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    reader.Close();
                    command.Connection.Close();
                }
            }
            return frontpages;
        }

        public Frontpage GetFrontpageFromID(int processOrderNo)
        {
            string queryString = $"SELECT * FROM Frontpage WHERE ProcessOrder_No = {processOrderNo}";
            Frontpage frontpage = new Frontpage();

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        frontpage.ProcessOrder_No = reader.GetInt32(0);
                        frontpage.Date = reader.GetDateTime(1);
                        frontpage.FinishedProduct_No = reader.GetInt32(2);
                        frontpage.Note = reader.GetString(3);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    reader.Close();
                    command.Connection.Close();
                }

                return frontpage;
            }
        }

        public bool CreateFrontpage(Frontpage frontpage)
        {
            string queryString = "INSERT INTO Frontpage (ProcessOrder_No, Date, FinishedProduct_No, Note) VALUES (@ProcessOrder_No, @Date, @FinishedProduct_No, @Note)";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                
                command.Parameters.AddWithValue("@ProcessOrder_No", frontpage.ProcessOrder_No);
                command.Parameters.AddWithValue("@Date", frontpage.Date);
                command.Parameters.AddWithValue("@FinishedProduct_No", frontpage.FinishedProduct_No);
                command.Parameters.AddWithValue("@Note", frontpage.Note);

                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public bool UpdateFrontpage(Frontpage frontpage, int processOrderNo)
        {
            string queryString = $"UPDATE Frontpage SET ProcessOrder_No = @ProcessOrder_No, Date = @Date, FinishedProduct_No = @FinishedProduct_No, Note = @Note WHERE ProcessOrder_No = {processOrderNo}";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);

                command.Parameters.AddWithValue("@ProcessOrder_No", frontpage.ProcessOrder_No);
                command.Parameters.AddWithValue("@Date", frontpage.Date);
                command.Parameters.AddWithValue("@FinishedProduct_No", frontpage.FinishedProduct_No);
                command.Parameters.AddWithValue("@Note", frontpage.Note);

                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public bool DeleteFrontpage(int processOrderNo)
        {
            string queryString = $"DELETE FROM Frontpage WHERE ProcessOrder_No = {processOrderNo}";

            using (Connection.MyConnection)
            {
                SqlCommand command = new SqlCommand(queryString, Connection.MyConnection);
                command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
    }
}