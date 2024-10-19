using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace YourNamespace
{
    public class HabitsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Habit> Habits { get; set; }

        public HabitsViewModel()
        {
            Habits = new ObservableCollection<Habit>
        {
            new Habit("Beber 2L de água", "2 vezes por dia"),
            new Habit("Estudar 30 minutos", "1 vez por dia"),
        };
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CompleteHabitCommand => new Command<Habit>((habit) =>
        {
            if (habit != null)
            {
                Console.WriteLine($"Concluindo hábito: {habit.Title}");
                habit.CompleteHabit();
            }
        });

        public void AddHabit(string title, string frequency)
        {
            Habits.Add(new Habit(title, frequency));
            OnPropertyChanged(nameof(Habits));
        }

        public ICommand DeleteHabitCommand => new Command<Habit>((habit) =>
        {
            if (Habits.Contains(habit))
            {
                Habits.Remove(habit);
            }
        });

    }
}