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

        private string _title;

        private string _descripton;

        private DateTime _selectedDate;

        private Termin _ausgewählterTermin;

        public TerminplanerViewModel()
        {
            SelectedDate = DateTime.Today;

            NeuerTerminCommand = new RelayCommand(() => TerminHinzufügen(new Termin { Titel = $"{_title}", Datum = SelectedDate, Beschreibung = Description }));
            TerminLöschenCommand = new RelayCommand(() => TerminLöschen(AusgewählterTermin), () => true);
        }

        public ObservableCollection<Termin> Termine { get; set; } = new ObservableCollection<Termin>();

        public Termin AusgewählterTermin
        {
            get { return _ausgewählterTermin; }
            set
            {
                _ausgewählterTermin = value;
                OnPropertyChanged(nameof(AusgewählterTermin));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string Description
        {
            get => _descripton;
            set
            {
                _descripton = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public void TerminHinzufügen(Termin termin)
        {
            if (Title == null || Title.Length == 0)
            {
                MessageBox.Show("Bitte gib einen Titel an!");
                return;
            }
            if (Description == null || Description.Length == 0)
            {
                MessageBox.Show("Bitte gib einen Beschreibung an!");
                return;
            }
            Termine.Add(termin);
        }

        public void TerminLöschen(Termin termin)
        {
            if (termin == null)
            {
                MessageBox.Show("Bitte wähle einen Termin aus!");
                return;
            }
            Termine.Remove(termin);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}