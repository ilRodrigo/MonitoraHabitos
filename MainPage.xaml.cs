using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new HabitsViewModel();

        }

        private void OnAddHabitClicked(object sender, EventArgs e)
        {
            var title = HabitTitleEntry.Text;
            var frequency = HabitFrequencyEntry.Text;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(frequency))
            {
                var viewModel = (HabitsViewModel)BindingContext;
                viewModel.AddHabit(title, frequency);

                HabitTitleEntry.Text = string.Empty;
                HabitFrequencyEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            }
        }

        private void OnCompleteHabitClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Habit habit)
            {
                habit.CompleteHabit();
                OnPropertyChanged();
            }
        }



    }

}