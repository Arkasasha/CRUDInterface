using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Views
{
    public interface IMainView
    {
        event EventHandler ShowUserView;
        event EventHandler ShowPaymentView;
        event EventHandler ShowUserPaymentView;
        event EventHandler ShowOrderView;
        event EventHandler ShowOrderItemView;
        event EventHandler ShowAddressView;
        event EventHandler ShowDeliveryView;
        event EventHandler ShowProductView;
        event EventHandler ShowProductCategotyView;
        event EventHandler ShowCategoryView;
        event EventHandler ShowProductDiscountView;
        event EventHandler ShowDiscountView;
        event EventHandler ShowProductSizeView;
        event EventHandler ShowCommentView;
        event EventHandler ShowContactUsView;
    }
}
