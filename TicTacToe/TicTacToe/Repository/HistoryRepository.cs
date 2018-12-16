using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TicTacToe
{
    public class HistoryRepository : IHistory
    {
        Database db;

        public HistoryRepository()
        {
            db =  new Database();
        }

        public bool DeleteDB(HistoryGame us)
        {
            return db.DeleteHistory(us);
        }

        public bool InsertDB(HistoryGame us)
        {
            return db.InsertHistory(us);
        }

        public ObservableCollection<HistoryGame> GetAllHG()
        {
            return new ObservableCollection<HistoryGame>(db.GetAll());
        }

    }
}
