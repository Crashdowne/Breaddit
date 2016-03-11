using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadit.Models
{
    public class WebViewerModel : AsyncModelBase
    {
        // m_ means member variable
        // model means this is where all the data will be stored (data model)
        private string m_url = "";

        public string Url
        {
            get
            {
                return m_url;
            }

            set
            {
                m_url = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public WebViewerModel(string url)
        {
            Url = url;
        }
    }
}
