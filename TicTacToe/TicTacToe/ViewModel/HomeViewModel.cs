using System.Threading.Tasks;
using TicTacToe.View;
using Xamarin.Forms;

namespace TicTacToe
{
    public class HomeViewModel
    {
        INavigation Navigation;

        public HomeViewModel(INavigation MainNaV)
        {
            Navigation = MainNaV;
        }

        public HomeViewModel()
        {
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

        async Task StartGame()
        {
            await Navigation.PushAsync(new GamePage(Player1, Player2));
        }


        Command historyCommand;
        public Command HistoryCommand
        {
            get
            {
                return historyCommand ?? (historyCommand = new Command(async () => await HistoryGame()));
                   
            }

        }
       
        async Task HistoryGame()
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}
