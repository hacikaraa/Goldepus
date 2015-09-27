using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Aybala.Tool._Data
{
    class DBConn
    {
        private LibraryContainer libraryContainer;

        public DBConn() 
        {
            this.libraryContainer = new LibraryContainer();
        }

        private SqlConnection conn;

        protected SqlConnection Connnection { get { return conn; } }

        protected bool ConnectToDB(string connectionString) 
        {
            bool result = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Veri Tabanına Bağlanılamıyor. Hata : " + ex.Message);
            }
            return result;
        }

        private void SelectConnect(DataBase db) 
        {
            switch (db)
            {
                case DataBase.ErrorLog:
                    ConnectToDB(this.libraryContainer.ErrorLogConnectionString);
                    break;
                default:
                    throw new Exception("Database Belirlenemedi.");
            }
        }

        public bool Insert(SqlCommand cmd,DataBase db) 
        {
            bool result = false;
            try
            {
                this.SelectConnect(db);
                cmd.Connection = this.Connnection;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Insert İşlemi Gerçekleştirilemedi. Hata : " + ex.Message);
            }
            return result;
        }


        

    }
    public enum DataBase 
    {
        ErrorLog = 1,
    }
}
