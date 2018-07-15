using CharacterList.Model.Sqlite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CharacterList.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        private ObservableCollection<Character> Characters { get;}

        private string _title;

        private string Title
        {
            set
            {
                if (_title == value) return;
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public CharacterViewModel()
        {
            Title = "Characters";
            Characters = new ObservableCollection<Character>();
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            var characters = await App.LocalDb.GetItems<Character>();
            foreach (var c in characters)
            {
                await Task.Delay(1000);
                Characters.Add(c);
            }
            await Task.Delay(3000);
            Characters.RemoveAt(2);
        }
    }
}
