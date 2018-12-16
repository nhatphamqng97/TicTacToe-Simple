using Acr.UserDialogs;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.View;
using Xamarin.Forms;

namespace TicTacToe
{
    public class HomeViewModel: BaseViewModel, INotifyPropertyChanged
    {

        public IHistory historyRepositoty;
        
        INavigation Navigation;

        public HomeViewModel(INavigation MainNaV)
        {
            Navigation = MainNaV;
            historyRepositoty = new HistoryRepository();
        }

        public HomeViewModel()
        {
        }

        Command startGameCommand;
        public Command StartGameCommand
        {
            get
            {
                return startGameCommand ??
                    (startGameCommand = new Command(async () => await StartGame(),
                    () =>
                    {
                        if (string.IsNullOrWhiteSpace(Player1) || string.IsNullOrWhiteSpace(Player2))
                            return false;
                        return true;
                    }));
            }

        }

        Command historyCommand;
        public Command HistoryCommand
        {
            get
            {
                return historyCommand ?? (historyCommand = new Command(async () => await HistoryGame()));
                   
            }

        }

       


        string _player1 = string.Empty;
        string _player2 = string.Empty;

        public string Player1
        {
            get { return _player1; }
            set
            {
                _player1 = value;
                StartGameCommand.ChangeCanExecute();//Thay đồi Text
            }
        }

        public string Player2
        {
            get { return _player2; }
            set
            {
                _player2 = value;
                StartGameCommand.ChangeCanExecute();
            }
        }

        async Task StartGame()
        {
           await Navigation.PushAsync(new GamePage(Player1, Player2));
        }

        async Task HistoryGame()
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}
