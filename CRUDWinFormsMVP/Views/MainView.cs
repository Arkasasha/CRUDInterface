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
            btnPayments.Click += delegate { ShowPaymentView?.Invoke(this, EventArgs.Empty); };
            btnUserPayments.Click += delegate { ShowUserPaymentView?.Invoke(this, EventArgs.Empty); };
            btnOrders.Click += delegate { ShowOrderView?.Invoke(this, EventArgs.Empty); };
            btnOrderItems.Click += delegate { ShowOrderItemView?.Invoke(this, EventArgs.Empty); };
            btnAddresses.Click += delegate { ShowAddressView?.Invoke(this, EventArgs.Empty); };
            btnDelivery.Click += delegate { ShowDeliveryView?.Invoke(this, EventArgs.Empty); };
            btnProducts.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };

            btnProductCategory.Click += delegate { ShowProductCategotyView?.Invoke(this, EventArgs.Empty); };
            btnCategory.Click += delegate { ShowCategoryView?.Invoke(this, EventArgs.Empty); };
            btnProductDiscount.Click += delegate { ShowProductDiscountView?.Invoke(this, EventArgs.Empty); };
            btnDiscount.Click += delegate { ShowDiscountView?.Invoke(this, EventArgs.Empty); };
            btnProductSize.Click += delegate { ShowProductSizeView?.Invoke(this, EventArgs.Empty); };
            btnComment.Click += delegate { ShowCommentView?.Invoke(this, EventArgs.Empty); };
            btnContactUs.Click += delegate { ShowContactUsView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowUserView;
        public event EventHandler ShowPaymentView;
        public event EventHandler ShowUserPaymentView;
        public event EventHandler ShowOrderView;
        public event EventHandler ShowOrderItemView;
        public event EventHandler ShowAddressView;
        public event EventHandler ShowDeliveryView;
        public event EventHandler ShowProductView;

        public event EventHandler ShowProductCategotyView;
        public event EventHandler ShowCategoryView;
        public event EventHandler ShowProductDiscountView;
        public event EventHandler ShowDiscountView;
        public event EventHandler ShowProductSizeView;
        public event EventHandler ShowCommentView;
        public event EventHandler ShowContactUsView;
    }
}
