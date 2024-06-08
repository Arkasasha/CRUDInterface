using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnUsers.Click += delegate { ShowUserView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowUserView;
        public event EventHandler ShowOrderView;
        public event EventHandler ShowPaymentView;
    }
}
