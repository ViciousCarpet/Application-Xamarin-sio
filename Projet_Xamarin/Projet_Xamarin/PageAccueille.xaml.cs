using Projet_Xamarin.Class;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAccueille : ContentPage
    {
        public ObservableCollection<Livre> lesLivres;
        public PageAccueille(ObservableCollection<Livre> l)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            LivreView.ItemsSource = l;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void livreClick(object sender, SelectedItemChangedEventArgs e)
        {
            Livre l = (Livre)this.LivreView.SelectedItem;

            if (l != null)
            {
                App.Current.MainPage = new NoterLivre(l);
            }
        }
    }
}