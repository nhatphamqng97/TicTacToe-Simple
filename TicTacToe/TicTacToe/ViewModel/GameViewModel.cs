using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

using System.Windows;
using System.Windows.Input;

namespace TicTacToe
{
    public class GameViewModel : INotifyPropertyChanged
    {
        #region Init
        public IHistory IHistoryrepository; //Insert
        public HistoryGame hg;  //SetData
        public Button[] buttons = new Button[9];
        private int playerTurn = 1;
        public string Title { get; set; }
        public string getP1 { get; set; }
        public string getP2 { get; set; }
        public string gameStatus { get; set; } //Win or lose
        #endregion

        #region Constructor
        public GameViewModel(string x, string y, Button[] b)
        {
            this.getP1 = x;
            this.getP2 = y;
            this.Title = x + " vs " + y;
            buttons = b;

            hg = new HistoryGame();
            IHistoryrepository = new HistoryRepository();
        }
        #endregion

        #region Command Check Winner
        private int[,] Winners = new int[,]
       {
            {0,1,2},{3,4,5},{6,7,8},{0,3,6},{1,4,7},{2,5,8},{0,4,8},{2,4,6}// Mảng 2 chiều 5 dòng 3 cột
       };

        public bool checkWWinner()
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];//Lấy Index Đầu tiên là {0,1,2}
                Button b1 = buttons[a], b2 = buttons[b], b3 = buttons[c];//Lấy ra các button trường hợp win

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackgroundColor = b2.BackgroundColor = b3.BackgroundColor = Color.Aqua;
                    gameOver = true;
                    DisableBtn();
                    break;
                }
            }

            bool isTie = true;
            if (gameOver == false)
            {
                foreach (Button b in buttons)
                {
                    if (b.Text == "")//Tìm kiếm ô trống
                    {
                        isTie = false;
                        break;
                    }
                }
                if (isTie)//Nếu hết ô thì GameOver => Hòa
                {
                    gameOver = true;
                    DisableBtn();
                    gameStatus = " Draw ";
                }
            }
            return gameOver;
        }

        public void SetButton(Button b)
        {
            if (b.Text == "")
            {
                b.Text = playerTurn == 1 ? "X" : "O";
                gameStatus = playerTurn == 1 ? " Win " : " Lose ";
                playerTurn = playerTurn == 1 ? 2 : 1;
            }
        }

        #region Disable Button
        public void DisableBtn()
        {
            foreach (Button b in buttons)
            {
                b.IsEnabled = false;
            }
        }

        #endregion

        public void ClickEvent(object param)
        {
            switch (int.Parse(param.ToString()))
            {
                case 0:
                    SetButton(buttons[0]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    
                    break;
                case 1:
                    SetButton(buttons[1]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 2:
                    SetButton(buttons[2]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 3:
                    SetButton(buttons[3]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 4:
                    SetButton(buttons[4]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 5:
                    SetButton(buttons[5]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 6:
                    SetButton(buttons[6]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 7:
                    SetButton(buttons[7]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                case 8:
                    SetButton(buttons[8]);
                    if (checkWWinner())
                    {
                        Status = checkWWinner();
                        setValueHg();
                        IHistoryrepository.InsertDB(hg);
                    }
                    break;
                default:
                    break;
            }
        }

        Command onClicked;
        public Command OnClicked
        {
            get
            {
                return onClicked ?? (onClicked = new Command<object>(ClickEvent));
            }
        }

        #endregion



        #region Reset Game And Insert Database


       
        public void setValueHg()
        {
            hg.Player1 = getP1;
            hg.Player2 = getP2;
            hg.Details = (getP1 + gameStatus + getP2).ToUpper();
            Detailgame = (getP1 + gameStatus + getP2).ToUpper();
            string currentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            hg.Date = currentTime;
        }

        public string _detaisGame = string.Empty;
        public string Detailgame
        {
            get { return _detaisGame; }
            set
            {
                _detaisGame = value;
                RaisePropertyChanged("Detailgame");
            }
        }

        public void Reset()
        {
            playerTurn = 1;
            foreach (Button b in buttons)
            {
                b.IsEnabled = true;
                b.Text = "";
                b.BackgroundColor = Color.Gray;
            }
            Status = false;
           
        }

        Command resetGame;
        public Command ResetGame
        {
            get
            {
                return resetGame ??
                    (resetGame = new Command(Reset));
            }
        }

        bool _status = false;
        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
