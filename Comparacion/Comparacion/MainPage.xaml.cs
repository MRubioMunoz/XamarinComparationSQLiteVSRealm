using Comparacion.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Comparacion
{
   
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.CambioCreate.Clicked += CambioCreateView;
            this.CambioDelete.Clicked += CambioDeleteView;
            this.CambioRead.Clicked += CambioReadView;
            this.CambioUpdate.Clicked += CambioUpdateView;
        }
        private async void CambioCreateView(object sender, EventArgs e)
        {
            CreateView view = new CreateView();
            await Navigation.PushModalAsync(view);
        }

        private async void CambioDeleteView(object sender, EventArgs e)
        {
            DeleteView view = new DeleteView();
            await Navigation.PushModalAsync(view);
        }

        private async void CambioUpdateView(object sender, EventArgs e)
        {
            UpdateView view = new UpdateView();
            await Navigation.PushModalAsync(view);
        }

        private async void CambioReadView(object sender, EventArgs e)
        {
            ReadAllView view = new ReadAllView();
            await Navigation.PushModalAsync(view);
        }
    }
}
