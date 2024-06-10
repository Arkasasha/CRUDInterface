using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public interface IUserPaymentView
    {
        //Properties - Fields
        string UserPaymentId { get; set;  }
        string UserPaymentUserId { get; set; }
        string UserPaymentPaymentType { get; set; }
        string UserPaymentAccountNumber { get; set; }
        string UserPaymentExpireDate { get; set; }

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
        void SetUserPaymentListBindingSource(BindingSource userpaymentList);
        void Show();
    }
}
