using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;

namespace CRUDWinFormsMVP.Presenters
{
    public class PaymentPresenter
    {
        //Fields
        private IPaymentView view;
        private IPaymentRepository repository;
        private BindingSource paymentsBindingSource;
        private IEnumerable<PaymentModel> paymentList;

        //Constructor
        public PaymentPresenter(IPaymentView view, IPaymentRepository repository)
        {
            this.paymentsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPayment;
            this.view.AddNewEvent += AddNewPayment;
            this.view.EditEvent += LoadSelectedPaymentToEdit;
            this.view.DeleteEvent += DeleteSelectedPayment;
            this.view.SaveEvent += SavePayment;
            this.view.CancelEvent += CancelAction;

            //Set payments binding source
            this.view.SetPaymentListBindingSource(paymentsBindingSource);

            //Load payment list view
            LoadAllPaymentList();

            //Show view
            this.view.Show();
        }

        private void LoadAllPaymentList()
        {
            paymentList = repository.GetAll();
            paymentsBindingSource.DataSource = paymentList; //Set data source
        }
        private void SearchPayment(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                paymentList = repository.GetByValue(this.view.SearchValue);
            else paymentList = repository.GetAll();
            paymentsBindingSource.DataSource = paymentList;
        }

        private void AddNewPayment(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedPaymentToEdit(object sender, EventArgs e)
        {
            var payment = (PaymentModel)paymentsBindingSource.Current;
            view.PaymentId = payment.Id.ToString();
            view.PaymentOrderId = payment.OrderId.ToString();
            view.PaymentUserId = payment.UserId.ToString();
            view.PaymentUserPaymentId = payment.UserPaymentId.ToString();
            view.PaymentPrice = payment.Price.ToString();
            view.PaymentTime = payment.Time.ToString();
            view.IsEdit = true;
        }

        private void SavePayment(object sender, EventArgs e)
        {
            try
            {
                var model = new PaymentModel();
                model.Id = Convert.ToInt32(view.PaymentId);
                model.OrderId = Convert.ToInt32(view.PaymentOrderId);
                model.UserId = Convert.ToInt32(view.PaymentUserId);
                model.UserPaymentId = Convert.ToInt32(view.PaymentUserPaymentId);
                model.Price = Convert.ToInt32(view.PaymentPrice);
                model.Time = Convert.ToDateTime(view.PaymentTime);
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Payment edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Payment added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllPaymentList();
                    CleanviewFields();
                }
                catch (Exception ex)
                {
                    view.IsSuccessful = false;
                    view.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
            
        }

        private void CleanviewFields()
        {
            view.PaymentId = "0";
            view.PaymentOrderId = "";
            view.PaymentUserId = "";
            view.PaymentUserPaymentId = "";
            view.PaymentPrice = "";
            view.PaymentTime = Convert.ToString(DateTime.Now);
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteSelectedPayment(object sender, EventArgs e)
        {
            try
            {
                var payment = (PaymentModel)paymentsBindingSource.Current;
                repository.Delete(payment.Id);
                view.IsSuccessful = true;
                view.Message = "Payment deleted successfully";
                LoadAllPaymentList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
