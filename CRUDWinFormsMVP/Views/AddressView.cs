﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public partial class AddressView : Form, IAddressView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Constructor
        public AddressView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageAddressDetail);
            btnClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            //Add new
            btnAddNew.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageAddressList);
                tabControl1.TabPages.Add(tabPageAddressDetail);
                tabPageAddressDetail.Text = "Add new user";
            };

            //Edit
            btnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageAddressList);
                tabControl1.TabPages.Add(tabPageAddressDetail);
                tabPageAddressDetail.Text = "Edit user";
            };

            //Save
            btnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageAddressDetail);
                    tabControl1.TabPages.Add(tabPageAddressList);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            button6.Click += delegate {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageAddressDetail);
                tabControl1.TabPages.Add(tabPageAddressList);
            };

            //Delete
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Are you sure you want to delete the selected user?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string AddressId
        {
            get { return txtAddressId.Text; }
            set { txtAddressId.Text = value; }
        }
        public string AddressUserId
        {
            get { return txtAddressUserId.Text; }
            set { txtAddressUserId.Text = value; }
        }
        public string AddressCity
        {
            get { return txtAddressCity.Text; }
            set { txtAddressCity.Text = value; }
        }
        public string AddressStreet
        {
            get { return txtAddressStreet.Text; }
            set { txtAddressStreet.Text = value; }
        }
        public string AddressPostalCode
        {
            get { return txtAddressPostalCode.Text; }
            set { txtAddressPostalCode.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetAddressListBindingSource(BindingSource addressList)
        {
            dataGridView1.DataSource = addressList;
        }

        //Singleton pattern (Open a single form instance)
        private static AddressView instance;
        public static AddressView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AddressView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Maximized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}