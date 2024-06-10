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
    public partial class PaymentView : Form, IPaymentView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public PaymentView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPagePaymentDetail);
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
                tabControl1.TabPages.Remove(tabPagePaymentList);
                tabControl1.TabPages.Add(tabPagePaymentDetail);
                tabPagePaymentDetail.Text = "Add new payment";
            };

            //Edit
            btnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePaymentList);
                tabControl1.TabPages.Add(tabPagePaymentDetail);
                tabPagePaymentDetail.Text = "Edit payment";
            };

            //Save
            btnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPagePaymentDetail);
                    tabControl1.TabPages.Add(tabPagePaymentList);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            button6.Click += delegate {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePaymentDetail);
                tabControl1.TabPages.Add(tabPagePaymentList);
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

        public string PaymentId
        {
            get { return txtPaymentId.Text; }
            set { txtPaymentId.Text = value; }
        }
        public string PaymentOrderId
        {
            get { return txtPaymentOrderId.Text; }
            set { txtPaymentOrderId.Text = value; }
        }
        public string PaymentUserId
        {
            get { return txtPaymentUserId.Text; }
            set { txtPaymentUserId.Text = value; }
        }
        public string PaymentUserPaymentId
        {
            get { return txtPaymentUserPaymentId.Text; }
            set { txtPaymentUserPaymentId.Text = value; }
        }
        public string PaymentPrice
        {
            get { return txtPaymentPrice.Text; }
            set { txtPaymentPrice.Text = value; }
        }
        public string PaymentTime
        {
            get { return txtPaymentTime.Text; }
            set { txtPaymentTime.Text = value; }
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

        public void SetPaymentListBindingSource(BindingSource paymentList)
        {
            dataGridView.DataSource = paymentList;
        }

        private static PaymentView instance;
        public static PaymentView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PaymentView();
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
