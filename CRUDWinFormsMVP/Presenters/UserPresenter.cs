﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;

namespace CRUDWinFormsMVP.Presenters
{
    internal class UserPresenter
    {
        //Fields
        private IUserView view;
        private IUserRepository repository;
        private BindingSource usersBindingSource;
        private IEnumerable<UserModel> userList;

        //Constructor
        public UserPresenter(IUserView view, IUserRepository repository)
        {
            this.usersBindingSource = new BindingSource();
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
            this.view.SetUserListBindingSource(usersBindingSource);

            //Load user list view
            LoadAllUserList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllUserList()
        {
            userList = repository.GetAll();
            usersBindingSource.DataSource = userList; //Set data source
        }
        private void SearchUser(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                userList = repository.GetByValue(this.view.SearchValue);
            else userList = repository.GetAll();
            usersBindingSource.DataSource = userList;
        }
        private void AddNewUser(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedUserToEdit(object sender, EventArgs e)
        {
            var user = (UserModel)usersBindingSource.Current;
            view.UserId = user.Id.ToString();
            view.UserUsername = user.Username;
            view.UserName = user.Name;
            view.UserSurname = user.Surname;
            view.UserEmail = user.Email;
            view.UserPassword = user.Password;
            view.IsEdit = true;
        }
        private void SaveUser(object sender, EventArgs e)
        {
            var model = new UserModel();
            model.Id = Convert.ToInt32(view.UserId);
            model.Username = view.UserUsername;
            model.Name = view.UserName;
            model.Surname = view.UserSurname;
            model.Email = view.UserEmail;
            model.Password = view.UserPassword;
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
                LoadAllUserList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.UserId = "0";
            view.UserUsername = "";
            view.UserName = "";
            view.UserSurname = "";
            view.UserEmail = "";
            view.UserPassword = "";
            view.UserPassword = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedUser(object sender, EventArgs e)
        {
            try
            {
                var user = (UserModel)usersBindingSource.Current;
                repository.Delete(user.Id);
                view.IsSuccessful = true;
                view.Message = "User deleted successfully";
                LoadAllUserList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
