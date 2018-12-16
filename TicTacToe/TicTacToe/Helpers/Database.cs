using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace TicTacToe
{
    public class Database
    {   //Get thư mục lưu trữ DB:
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public Database()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "historyGame.db3")))
                {
                    connection.CreateTable<HistoryGame>();
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLEx", ex.Message);
                return;
            }
        }

        //Insert History
        public bool InsertHistory(HistoryGame hg)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "historyGame.db3")))
                {
                    connection.Insert(hg);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool DeleteHistory(HistoryGame hg)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "historyGame.db3")))
                {
                    connection.Delete(hg);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        //Select Last Record User:
        public List<HistoryGame> GetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "historyGame.db3")))
                {
                    return connection.Table<HistoryGame>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
    }
}
