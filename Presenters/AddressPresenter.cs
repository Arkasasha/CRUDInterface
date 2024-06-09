using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Presenters
{
    public class AddressPresenter
    {
        //Fields
        private IAddressView view;
        private IAddressRepository repository;
        private BindingSource addresssBindingSource;
        private IEnumerable<AddressModel> addressList;

        //Constructor
        public AddressPresenter(IAddressView view, IAddressRepository repository)
        {
            this.addresssBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchAddress;
            this.view.AddNewEvent += AddNewAddress;
            this.view.EditEvent += LoadSelectedAddressToEdit;
            this.view.DeleteEvent += DeleteSelectedAddress;
            this.view.SaveEvent += SaveAddress;
            this.view.CancelEvent += CancelAction;

            //Set addresss binding source
            this.view.SetAddressListBindingSource(addresssBindingSource);

            //Load address list view
            LoadAllAddressList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllAddressList()
        {
            addressList = repository.GetAll();
            addresssBindingSource.DataSource = addressList; //Set data source
        }

        private void SearchAddress(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                addressList = repository.GetByValue(this.view.SearchValue);
            else addressList = repository.GetAll();
            addresssBindingSource.DataSource = addressList;
        }

        private void AddNewAddress(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedAddressToEdit(object sender, EventArgs e)
        {
            var address = (AddressModel)addresssBindingSource.Current;
            view.AddressId = address.Id.ToString();
            view.AddressUserId = address.UserId.ToString();
            view.AddressCity = address.City;
            view.AddressStreet = address.Street;
            view.AddressPostalCode = address.PostalCode;
            view.IsEdit = true;
        }
        private void SaveAddress(object sender, EventArgs e)
        {
            try
            {
                var model = new AddressModel();
                model.Id = Convert.ToInt32(view.AddressId);
                model.UserId = Convert.ToInt32(view.AddressUserId);
                model.City = view.AddressCity;
                model.Street = view.AddressStreet;
                model.PostalCode = view.AddressPostalCode;
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Address edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Address added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllAddressList();
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
            view.AddressId = "0";
            view.AddressUserId = "";
            view.AddressCity = "";
            view.AddressStreet = "";
            view.AddressPostalCode = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteSelectedAddress(object sender, EventArgs e)
        {
            try
            {
                var address = (AddressModel)addresssBindingSource.Current;
                repository.Delete(address.Id);
                view.IsSuccessful = true;
                view.Message = "Address deleted successfully";
                LoadAllAddressList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
