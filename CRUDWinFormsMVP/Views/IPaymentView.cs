using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public interface IPaymentView
    {
        //Properties - Fields
        string PaymentId { get; set; }
        string PaymentOrderId { get; set; }
        string PaymentUserId { get; set; }
        string PaymentUserPaymentId { get; set; }
        string PaymentPrice { get; set; }
        string PaymentTime { get; set; }

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
        void SetPaymentListBindingSource(BindingSource paymentList);
        void Show();
    }
}
