using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ModelLibrary;
using UniBase.Annotations;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        private string test= "hej";
        private const string URI = "http://localhost:12736/api/Product";
        private HttpClient client = new HttpClient();


        public WorkViewModel()
        {
            
            Product v = ModelGenerics.GetById(new Product(), 1);

            test = v.ProductName;
        }

        

        private Product GetOneFacility(int id)
        {
            Task<string> resTask = client.GetStringAsync(URI + "/" + id);

            return JsonConvert.DeserializeObject<Product>(resTask.Result);
        }

        public string Test
        {
            get { return test; }
            set
            {
                test = value; 
                OnPropertyChanged();
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
