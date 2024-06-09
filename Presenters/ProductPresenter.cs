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
    public class ProductPresenter
    {
        //Fields
        private IProductView view;
        private IProductRepository repository;
        private BindingSource productsBindingSource;
        private IEnumerable<ProductModel> productList;

        //Constructor
        public ProductPresenter(IProductView view, IProductRepository repository)
        {
            this.productsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchProduct;
            this.view.AddNewEvent += AddNewProduct;
            this.view.EditEvent += LoadSelectedProductToEdit;
            this.view.DeleteEvent += DeleteSelectedProduct;
            this.view.SaveEvent += SaveProduct;
            this.view.CancelEvent += CancelAction;

            //Set products binding source
            this.view.SetProductListBindingSource(productsBindingSource);

            //Load product list view
            LoadAllProductList();

            //Show view
            this.view.Show();
        }

        private void LoadAllProductList()
        {
            productList = repository.GetAll();
            productsBindingSource.DataSource = productList; //Set data source
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                productList = repository.GetByValue(this.view.SearchValue);
            else productList = repository.GetAll();
            productsBindingSource.DataSource = productList;
        }
        private void AddNewProduct(object sender, EventArgs e)
        {
            view.IsEdit = false;
            view.ProductGrade = "0";
        }

        private void LoadSelectedProductToEdit(object sender, EventArgs e)
        {
            var product = (ProductModel)productsBindingSource.Current;
            view.ProductId = product.Id.ToString();
            view.ProductTitle = product.Title;
            view.ProductPrice = product.Price.ToString();
            view.ProductAmmount = product.Ammount.ToString();
            view.ProductGrade = product.Grade.ToString();
            view.ProductGrade = product.Grade.ToString();
            view.IsEdit = true;
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            try
            {
                var model = new ProductModel();
                model.Id = Convert.ToInt32(view.ProductId);
                model.Title = view.ProductTitle;
                model.Price = Convert.ToInt32(view.ProductPrice);
                model.Ammount = Convert.ToInt32(view.ProductAmmount);
                model.Grade = Convert.ToSingle(view.ProductGrade);
                try
                {
                    new Common.ModelDataValidation().Validate(model);
                    if (view.IsEdit)
                    {
                        repository.Edit(model);
                        view.Message = "Product edited successfully";
                    }
                    else
                    {
                        repository.Add(model);
                        view.Message = "Product added successfully";
                    }
                    view.IsSuccessful = true;
                    LoadAllProductList();
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
            view.ProductId = "0";
            view.ProductTitle = "";
            view.ProductPrice = "";
            view.ProductAmmount = "";
            view.ProductGrade = "0";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteSelectedProduct(object sender, EventArgs e)
        {
            try
            {
                var user = (ProductModel)productsBindingSource.Current;
                repository.Delete(user.Id);
                view.IsSuccessful = true;
                view.Message = "Product deleted successfully";
                LoadAllProductList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
