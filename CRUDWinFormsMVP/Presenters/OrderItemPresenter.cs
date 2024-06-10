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
    public class OrderItemPresenter
    {
        //Fields
        private IOrderItemView view;
        private IOrderItemRepository repository;
        private BindingSource orderItemsBindingSource;
        private IEnumerable<OrderItemModel> orderItemList;

        //Constructor
        public OrderItemPresenter(IOrderItemView view, IOrderItemRepository repository)
        {
            this.orderItemsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchOrderItem;
            this.view.AddNewEvent += AddNewOrderItem;
            this.view.EditEvent += LoadSelectedOrderItemToEdit;
            this.view.DeleteEvent += DeleteSelectedOrderItem;
            this.view.SaveEvent += SaveOrderItem;
            this.view.CancelEvent += CancelAction;

            //Set orderItems binding source
            this.view.SetOrderItemListBindingSource(orderItemsBindingSource);

            //Load orderItem list view
            LoadAllOrderItemList();

            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllOrderItemList()
        {
            orderItemList = repository.GetAll();
            orderItemsBindingSource.DataSource = orderItemList; //Set data source
        }
        private void SearchOrderItem(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                orderItemList = repository.GetByValue(this.view.SearchValue);
            else orderItemList = repository.GetAll();
            orderItemsBindingSource.DataSource = orderItemList;
        }

        private void AddNewOrderItem(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedOrderItemToEdit(object sender, EventArgs e)
        {
            var orderItem = (OrderItemModel)orderItemsBindingSource.Current;
            view.OrderItemId = orderItem.Id.ToString();
            view.OrderItemOrderId = orderItem.OrderId.ToString();
            view.OrderItemProductId = orderItem.ProductId.ToString();
            view.OrderItemSize = orderItem.Size.ToString();
            view.IsEdit = true;
        }

        private void SaveOrderItem(object sender, EventArgs e)
        {
            try
            {
                var model = new OrderItemModel();
                model.Id = Convert.ToInt32(view.OrderItemId);
                model.OrderId = Convert.ToInt32(view.OrderItemOrderId);
                model.ProductId = Convert.ToInt32(view.OrderItemProductId);
                model.Size = Convert.ToInt32(view.OrderItemSize);
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Order item edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Order item added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllOrderItemList();
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
            view.OrderItemId = "0";
            view.OrderItemOrderId = "";
            view.OrderItemProductId = "";
            view.OrderItemSize = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteSelectedOrderItem(object sender, EventArgs e)
        {
            try
            {
                var orderItem = (OrderItemModel)orderItemsBindingSource.Current;
                repository.Delete(orderItem.Id);
                view.IsSuccessful = true;
                view.Message = "Order item deleted successfully";
                LoadAllOrderItemList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
