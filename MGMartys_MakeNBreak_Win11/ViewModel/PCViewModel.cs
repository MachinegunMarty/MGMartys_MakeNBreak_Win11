
using MGMartys_MakeNBreak_Win11.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class PCViewModel : INotifyPropertyChanged
    {
        private readonly CollectionViewSource PCItemsCollection;
        public ICollectionView PCSourceCollection => PCItemsCollection.View;

        public PCViewModel()
        {
            ObservableCollection<PCItems> pcItems = new ObservableCollection<PCItems>
            {
                new PCItems { PCName = "Local Disk (C:)", PCImage = @"/Resources/Icons/drive_icon.png" },
                new PCItems { PCName = "Local Disk (D:)", PCImage = @"/Resources/Icons/drive_icon.png" },
                new PCItems { PCName = "Local Disk (E:)", PCImage = @"/Resources/Icons/drive_icon.png" },
                new PCItems { PCName = "Local Disk (F:)", PCImage = @"/Resources/Icons/drive_icon.png" }

            };

            PCItemsCollection = new CollectionViewSource { Source = pcItems };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
