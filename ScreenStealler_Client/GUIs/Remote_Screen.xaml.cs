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
using System.Windows.Shapes;

namespace ScreenStealler_Client.GUIs
{
    /// <summary>
    /// Remote_Screen.xaml 的互動邏輯
    /// </summary>
    public partial class Remote_Screen : Window
    {
        private long ID;
        public Remote_Screen(long ID)
        {
            this.ID = ID;
            InitializeComponent();
            Title = ID.ToString();
            Closing += delegate { Global.Dispose_Screen(this); };
        }
        public long Get_ID() => ID;
        public void Display(ImageSource image)
        {
            screen_displayer.Source = image;
            Show();
        }
    }
}
