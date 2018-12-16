using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace TicTacToe
{
    class HistoryViewModel : INotifyPropertyChanged
    {
        public IHistory IHistoryrepository;
        public HistoryGame hg;
        public HistoryViewModel()
        {
            hg = new HistoryGame();
            IHistoryrepository = new HistoryRepository();
            LoadAllHistory();
        }

        ObservableCollection<HistoryGame> hgList;
        public ObservableCollection<HistoryGame> GetAllHistory
        {
            get { return hgList; }
            set
            {
                if (hgList != value)
                    hgList = value;
                RaisePropertyChanged("GetAllHistory");
            }
        }
        public void LoadAllHistory()
        {
            GetAllHistory = IHistoryrepository.GetAllHG();
        }


        public string Details
        {
            get { return hg.Details; }
            set
            {
                hg.Details = value;
                RaisePropertyChanged("Details");
            }
        }

        public string Date
        {
            get { return hg.Date; }
            set
            {
                hg.Date = value;
                RaisePropertyChanged("Date");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


    }
}
