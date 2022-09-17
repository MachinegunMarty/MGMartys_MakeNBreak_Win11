
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using MGMartys_MakeNBreak_Win11.Model;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class DocumentViewModel : INotifyPropertyChanged
    {
        private CollectionViewSource DocumentItemsCollection;
        public ICollectionView DocumentSourceCollection => DocumentItemsCollection.View;       

        public DocumentViewModel()
        {
            ObservableCollection<DocumentItems> documentItems = new ObservableCollection<DocumentItems>
            {

                new DocumentItems { DocumentName = "Books", DocumentImage = @"/Resources/Icons/book_icon.png" },
                new DocumentItems { DocumentName = "Studio", DocumentImage = @"/Resources/Icons/studio_icon.png" },
                new DocumentItems { DocumentName = "Export", DocumentImage = @"/Resources/Icons/export_icon.png" },
                new DocumentItems { DocumentName = "Print", DocumentImage = @"/Resources/Icons/print_icon.png" },                  
                new DocumentItems { DocumentName = "Orders", DocumentImage = @"/Resources/Icons/order_icon.png" },              
                new DocumentItems { DocumentName = "Stocks", DocumentImage = @"/Resources/Icons/stock_icon.png" },
                new DocumentItems { DocumentName = "Invoice", DocumentImage = @"/Resources/Icons/invoice_icon.png" }               

            };

            DocumentItemsCollection = new CollectionViewSource { Source = documentItems };
            DocumentItemsCollection.Filter += MenuItems_Filter;

        }

        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                DocumentItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            DocumentItems _item = e.Item as DocumentItems;
            if (_item.DocumentName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
