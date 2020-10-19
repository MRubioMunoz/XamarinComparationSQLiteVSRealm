using Comparacion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comparacion.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadAllView : ContentPage
    {
        public ReadAllView()
        {
            InitializeComponent();
        }

        private void Compare(object sender, EventArgs e)
        {
        }
    }
}