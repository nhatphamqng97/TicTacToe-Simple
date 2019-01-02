using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe.View
{
	public partial class GamePage : ContentPage
	{
        public Button[] buttons = new Button[9];

        public void setButtonArr()
        {
            buttons[0] = button0;
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
            buttons[5] = button5;
            buttons[6] = button6;
            buttons[7] = button7;
            buttons[8] = button8;
        }

        public GamePage(string x, string y)
        {
            InitializeComponent();
            setButtonArr();
            BindingContext = new GameViewModel(x, y, buttons);
        }
    }
}