using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoLivre : ContentPage
    {
        public InfoLivre()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            InfoLivre il = new InfoLivre();
        }
    }
}