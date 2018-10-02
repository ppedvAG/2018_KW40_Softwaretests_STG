using ppedv.Koffeinator.Logik;
using ppedv.Koffeinator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Koffeinator.UI.WPF.ViewModels
{
    public class KaffeeRezeptViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<KaffeeRezept> Rezepte { get; set; }

        KaffeeRezept selectedRezept;

        public KaffeeRezept SelectedRezept
        {
            get
            {
                return selectedRezept;
            }

            set
            {
                selectedRezept = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedRezept)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Summe)));

            }
        }

        public string Summe
        {
            get
            {
                if (SelectedRezept == null)
                    return "---";
                return (SelectedRezept.Kaffee +
                        SelectedRezept.Kakao +
                       SelectedRezept.Milch).ToString();
            }
        }

        private Core core = new Core(new Data.EF.EfRepository());

        public event PropertyChangedEventHandler PropertyChanged;

        public KaffeeRezeptViewModel()
        {
            Rezepte = new ObservableCollection<KaffeeRezept>(core.Repository.GetAll<KaffeeRezept>());

        }
    }
}
