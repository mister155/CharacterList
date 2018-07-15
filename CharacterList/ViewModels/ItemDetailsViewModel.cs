using CharacterList.Model.Sqlite;
using CharacterList.Utils;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CharacterList.ViewModels
{
    public class ItemDetailsViewModel : BaseViewModel
    {
        public Command<string> SaveItemCommand { get; private set; }

        private readonly int _itemId;
        private string _itemName;

        public string ItemName
        {
            get => _itemName;
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    RaisePropertyChanged(nameof(ItemName));
                }
            }
        }

        private string _itemType;

        public string ItemType
        {
            get => _itemType;
            set
            {
                if (_itemType != value)
                {
                    _itemType = value;
                    RaisePropertyChanged(nameof(ItemType));
                }
            }
        }

        private string _specialTraits;

        public string SpecialTraits
        {
            get => _specialTraits;
            set
            {
                if (_specialTraits != value)
                {
                    _specialTraits = value;
                    RaisePropertyChanged(nameof(SpecialTraits));
                }
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged(nameof(Description));
                }
            }
        }

        public ItemDetailsViewModel()
        {
            _itemId = 1;
            ItemName = string.Empty;
            ItemType = string.Empty;
            SaveItemCommand = new Command<string>(async (s) => await SaveStudent(s));
            Init();
        }

        private async Task SaveStudent(string s)
        {
            var item = new Item
            {
                ItemName = ItemName,
                ItemType = ItemType,
                SpecialTraits = SpecialTraits,
                Description = Description,
                CharacterId = 1
            };

            if (s == "UPDATE")
            {
                item.ID = _itemId;
            }

            await App.LocalDb.SaveItem(item);

            await AlertService.DisplayAlert("Success", "Data has been saved");
            await NavigationService.Pop();
        }

        private async void Init()
        {
            await Task.Delay(1000);
            var student = await App.LocalDb.GetItemById<Item>(_itemId);
            ItemName = student.ItemName;
            ItemType = student.ItemType;
            SpecialTraits = student.SpecialTraits;
            Description = student.Description;
        }
    }
}
