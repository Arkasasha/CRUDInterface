using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDWinFormsMVP.Views;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP._Repositories;
using System.Windows.Forms;


namespace CRUDWinFormsMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string mySqlConnectionString;

        public MainPresenter(IMainView mainView, string mySqlConnectionString)
        {
            this.mainView = mainView;
            this.mySqlConnectionString = mySqlConnectionString;
            this.mainView.ShowUserView += ShowUsersView;
            this.mainView.ShowPaymentView += ShowPaymentsView;
            this.mainView.ShowUserPaymentView += ShowUserPaymentsView;
            this.mainView.ShowOrderView += ShowOrdersView;
            this.mainView.ShowOrderItemView += ShowOrderItemsView;
            this.mainView.ShowAddressView += ShowAddressesView;
            this.mainView.ShowDeliveryView += ShowDeliverysView;
            this.mainView.ShowProductView += ShowProductsView;

            this.mainView.ShowProductCategotyView += ShowProductCategoriesView;
            this.mainView.ShowCategoryView += ShowCategoriesView;
            this.mainView.ShowProductDiscountView += ShowProductDiscountsView;
            this.mainView.ShowDiscountView += ShowDiscountsView;
            this.mainView.ShowProductSizeView += ShowProductSizesView;
            this.mainView.ShowCommentView += ShowCommentsView;
            this.mainView.ShowContactUsView += ShowContactUsView;
        }

        private void ShowUsersView(object sender, EventArgs e)
        {
            IUserView view = UserView.GetInstance((MainView)mainView);
            IUserRepository repository = new UserRepository(mySqlConnectionString);
            new UserPresenter(view, repository);
        }

        private void ShowPaymentsView(object sender, EventArgs e)
        {
            IPaymentView view = PaymentView.GetInstance((MainView)mainView);
            IPaymentRepository repository = new PaymentRepository(mySqlConnectionString);
            new PaymentPresenter(view, repository);
        }

        private void ShowUserPaymentsView(object sender, EventArgs e)
        {
            IUserPaymentView view = UserPaymentView.GetInstance((MainView)mainView);
            IUserPaymentRepository repository = new UserPaymentRepository(mySqlConnectionString);
            new UserPaymentPresenter(view, repository);
        }

        private void ShowOrdersView(object sender, EventArgs e)
        {
            IOrderView view = OrderView.GetInstance((MainView)mainView);
            IOrderRepository repository = new OrderRepository(mySqlConnectionString);
            new OrderPresenter(view, repository);
        }

        private void ShowOrderItemsView(object sender, EventArgs e)
        {
            IOrderItemView view = OrderItem.GetInstance((MainView)mainView);
            IOrderItemRepository repository = new OrderItemRepository(mySqlConnectionString);
            new OrderItemPresenter(view, repository);
        }

        private void ShowAddressesView(object sender, EventArgs e)
        {
            IAddressView view = AddressView.GetInstance((MainView)mainView);
            IAddressRepository repository = new AddressRepository(mySqlConnectionString);
            new AddressPresenter(view, repository);
        }

        private void ShowDeliverysView(object sender, EventArgs e)
        {
            IDeliveryView view = DeliveryView.GetInstance((MainView)mainView);
            IDeliveryRepository repository = new DeliveryRepository(mySqlConnectionString);
            new DeliveryPresenter(view, repository);
        }

        private void ShowProductsView(object sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance((MainView)mainView);
            IProductRepository repository = new ProductRepository(mySqlConnectionString);
            new ProductPresenter(view, repository);
        }

        private void ShowProductCategoriesView(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }

        private void ShowCategoriesView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowProductDiscountsView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowDiscountsView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowProductSizesView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowCommentsView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowContactUsView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
