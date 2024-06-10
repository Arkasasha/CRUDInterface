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
    public class UserPaymentPresenter
    {
        //Fields
        private IUserPaymentView view;
        private IUserPaymentRepository repository;
        private BindingSource userpaymentsBindingSource;
        private IEnumerable<UserPaymentModel> userpaymentList;

        //Constructor
        public UserPaymentPresenter(IUserPaymentView view, IUserPaymentRepository repository)
        {
            this.userpaymentsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchUser;
            this.view.AddNewEvent += AddNewUser;
            this.view.EditEvent += LoadSelectedUserToEdit;
            this.view.DeleteEvent += DeleteSelectedUser;
            this.view.SaveEvent += SaveUser;
            this.view.CancelEvent += CancelAction;

            //Set users binding source
            this.view.SetUserPaymentListBindingSource(userpaymentsBindingSource);

            //Load user list view
            LoadAllUserPaymentList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllUserPaymentList()
        {
            userpaymentList = repository.GetAll();
            userpaymentsBindingSource.DataSource = userpaymentList; //Set data source
        }
        private void SearchUser(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                userpaymentList = repository.GetByValue(this.view.SearchValue);
            else userpaymentList = repository.GetAll();
            userpaymentsBindingSource.DataSource = userpaymentList;
        }
        private void AddNewUser(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
        private void LoadSelectedUserToEdit(object sender, EventArgs e)
        {
            var userPayment = (UserPaymentModel)userpaymentsBindingSource.Current;
            view.UserPaymentId = userPayment.Id.ToString();
            view.UserPaymentUserId = userPayment.UserId.ToString();
            view.UserPaymentPaymentType = userPayment.PaymentType;
            view.UserPaymentAccountNumber = userPayment.AccountNumber;
            view.UserPaymentExpireDate = userPayment.ExpireDate;
            view.IsEdit = true;
        }
        private void SaveUser(object sender, EventArgs e)
        {
            try
            {
                var model = new UserPaymentModel();
                model.Id = Convert.ToInt32(view.UserPaymentId);
                model.UserId = Convert.ToInt32(view.UserPaymentUserId);
                model.PaymentType = view.UserPaymentPaymentType;
                model.AccountNumber = view.UserPaymentAccountNumber;
                model.ExpireDate = view.UserPaymentExpireDate;
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "User edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "User added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllUserPaymentList();
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
            view.UserPaymentId = "0";
            view.UserPaymentUserId = "0";
            view.UserPaymentPaymentType = "";
            view.UserPaymentAccountNumber = "";
            view.UserPaymentExpireDate = "";
        }
        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedUser(object sender, EventArgs e)
        {
            try
            {
                var userPayment = (UserPaymentModel)userpaymentsBindingSource.Current;
                repository.Delete(userPayment.Id);
                view.IsSuccessful = true;
                view.Message = "Payment Method deleted successfully";
                LoadAllUserPaymentList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
