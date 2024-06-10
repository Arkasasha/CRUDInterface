using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Presenters
{
    public class OrderPresenter
    {
        //Fields
        private IOrderView view;
        private IOrderRepository repository;
        private BindingSource ordersBindingSource;
        private IEnumerable<OrderModel> orderList;

        //Constructor
        public OrderPresenter(IOrderView view, IOrderRepository repository)
        {
            this.ordersBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchOrder;
            this.view.AddNewEvent += AddNewOrder;
            this.view.EditEvent += LoadSelectedOrderToEdit;
            this.view.DeleteEvent += DeleteSelectedOrder;
            this.view.SaveEvent += SaveOrder;
            this.view.CancelEvent += CancelAction;

            //Set Orders binding source
            this.view.SetOrderListBindingSource(ordersBindingSource);

            //Load Order list view
            LoadAllOrderList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllOrderList()
        {
            orderList = repository.GetAll();
            ordersBindingSource.DataSource = orderList; //Set data source
        }
        private void SearchOrder(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                orderList = repository.GetByValue(this.view.SearchValue);
            else orderList = repository.GetAll();
            ordersBindingSource.DataSource = orderList;
        }

        private void AddNewOrder(object sender, EventArgs e)
        {
            view.IsEdit = false;
            view.OrderTime = Convert.ToString(DateTime.Now);
            view.OrderStatus = "Dont fill";
        }

        private void LoadSelectedOrderToEdit(object sender, EventArgs e)
        {
            var order = (OrderModel)ordersBindingSource.Current;
            view.OrderId = order.Id.ToString();
            view.OrderUserId = order.UserId.ToString();
            view.OrderAdressId = order.AddressId.ToString();
            view.OrderDeliveryId = order.DeliveryId.ToString();
            view.OrderTime = order.Time.ToString();
            view.OrderStatus = order.Status;
            view.IsEdit = true;
        }
        private void SaveOrder(object sender, EventArgs e)
        {
            try
            {
                var model = new OrderModel();
                model.Id = Convert.ToInt32(view.OrderId);
                model.UserId = Convert.ToInt32(view.OrderUserId);
                model.AddressId = Convert.ToInt32(view.OrderAdressId);
                model.DeliveryId = Convert.ToInt32(view.OrderDeliveryId);
                model.Time = Convert.ToDateTime(view.OrderTime);
                model.Status = view.OrderStatus;
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Order edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Order added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllOrderList();
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
            view.OrderId = "0";
            view.OrderUserId = "";
            view.OrderAdressId = "";
            view.OrderDeliveryId = "";
            view.OrderTime = Convert.ToString(DateTime.Now);
            view.OrderStatus = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedOrder(object sender, EventArgs e)
        {
            try
            {
                var order = (OrderModel)ordersBindingSource.Current;
                repository.Delete(order.Id);
                view.IsSuccessful = true;
                view.Message = "Order deleted successfully";
                LoadAllOrderList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
