using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public class TerminplanerViewModel : INotifyPropertyChanged
    {
        public ICommand NeuerTerminCommand { get; }
        public ICommand TerminLöschenCommand { get; }

        public TerminplanerViewModel()
        {
            NeuerTerminCommand = new RelayCommand(() => TerminHinzufügen(new Termin { Titel = "Neuer Termin", Datum = DateTime.Now }));
            TerminLöschenCommand = new RelayCommand(() => TerminLöschen(AusgewählterTermin), () => AusgewählterTermin != null);
        }

        public ObservableCollection<Termin> Termine { get; set; } = new ObservableCollection<Termin>();

        private Termin _ausgewählterTermin;
        public Termin AusgewählterTermin
        {
            get { return _ausgewählterTermin; }
            set
            {
                _ausgewählterTermin = value;
                OnPropertyChanged(nameof(AusgewählterTermin));
            }
        }

        public void TerminHinzufügen(Termin termin)
        {
            Termine.Add(termin);
        }

        public void TerminLöschen(Termin termin)
        {
            Termine.Remove(termin);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}