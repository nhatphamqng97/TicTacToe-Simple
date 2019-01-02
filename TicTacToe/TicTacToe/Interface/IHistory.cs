using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace TicTacToe
{
    public interface IHistory
    {
        ObservableCollection<HistoryGame> GetAllHG();
        HistoryGame GetHistoryGameByID(int id);
        bool InsertDB(HistoryGame us);
        bool DeleteDB(HistoryGame us);
    }
}
