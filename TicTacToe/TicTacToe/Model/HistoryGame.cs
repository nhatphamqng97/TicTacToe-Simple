using SQLite;

namespace TicTacToe
{
     public class HistoryGame
    {
        [PrimaryKey, AutoIncrement]
        public int HistoryID { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }

    }
}
