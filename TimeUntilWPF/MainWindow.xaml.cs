using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeUntilWPF.Services;
using Microsoft.Extensions.DependencyInjection;
using Root.Interfaces;

namespace TimeUntilWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddSingleton<ILocalStorage, LocalStorage>();
            serviceCollection.AddSingleton<IFormFactor, FormFactor>();
            serviceCollection.AddSingleton<IPhotoManager, PhotoManager>();

            Resources.Add("services", serviceCollection.BuildServiceProvider());

        }
    }
}
