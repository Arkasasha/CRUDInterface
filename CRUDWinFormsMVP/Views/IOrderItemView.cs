using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public interface IOrderItemView
    {
        //Fields
        string OrderItemId { get; set; }
        string OrderItemOrderId { get; set; }
        string OrderItemProductId { get; set; }
        string OrderItemSize { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetOrderItemListBindingSource(BindingSource orderItemList);
        void Show();
    }
}
