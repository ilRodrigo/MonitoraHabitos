using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YourNamespace
{
    public class Habit : INotifyPropertyChanged
    {
        private int completedTimes;

        public string Title { get; set; }
        public string Frequency { get; set; }

        public int CompletedTimes
        {
            get => completedTimes;
            private set
            {
                completedTimes = value;
                OnPropertyChanged();
            }
        }

        public Habit(string title, string frequency)
        {
            Title = title;
            Frequency = frequency;
            CompletedTimes = 0;
        }

        public void CompleteHabit()
        {
            CompletedTimes++;
            OnPropertyChanged(nameof(CompletedTimes));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
