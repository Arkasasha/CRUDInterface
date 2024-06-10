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
    public class DeliveryPresenter
    {
        //Fields
        private IDeliveryView view;
        private IDeliveryRepository repository;
        private BindingSource deliverysBindingSource;
        private IEnumerable<DeliveryModel> deliveryList;

        //Constructor
        public DeliveryPresenter(IDeliveryView view, IDeliveryRepository repository)
        {
            this.deliverysBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchDelivery;
            this.view.AddNewEvent += AddNewDelivery;
            this.view.EditEvent += LoadSelectedDeliveryToEdit;
            this.view.DeleteEvent += DeleteSelectedDelivery;
            this.view.SaveEvent += SaveDelivery;
            this.view.CancelEvent += CancelAction;

            //Set deliverys binding source
            this.view.SetDeliveryListBindingSource(deliverysBindingSource);

            //Load delivery list view
            LoadAllDeliveryList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllDeliveryList()
        {
            deliveryList = repository.GetAll();
            deliverysBindingSource.DataSource = deliveryList; //Set data source
        }
        private void SearchDelivery(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                deliveryList = repository.GetByValue(this.view.SearchValue);
            else deliveryList = repository.GetAll();
            deliverysBindingSource.DataSource = deliveryList;
        }
        private void AddNewDelivery(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedDeliveryToEdit(object sender, EventArgs e)
        {
            var delivery = (DeliveryModel)deliverysBindingSource.Current;
            view.DeliveryId = delivery.Id.ToString();
            view.DeliveryName = delivery.Name;
            view.IsEdit = true;
        }

        private void SaveDelivery(object sender, EventArgs e)
        {
            try
            {
                var model = new DeliveryModel();
                model.Id = Convert.ToInt32(view.DeliveryId);
                model.Name = view.DeliveryName;
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Delivery edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Delivery added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllDeliveryList();
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
            view.DeliveryId = "0";
            view.DeliveryName = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteSelectedDelivery(object sender, EventArgs e)
        {
            try
            {
                var delivery = (DeliveryModel)deliverysBindingSource.Current;
                repository.Delete(delivery.Id);
                view.IsSuccessful = true;
                view.Message = "Delivery deleted successfully";
                LoadAllDeliveryList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
