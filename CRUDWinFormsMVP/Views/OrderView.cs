using System;
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
    public partial class OrderView : Form, IOrderView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Constructor
        public OrderView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageOrderDetail);
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
                tabControl1.TabPages.Remove(tabPageOrderList);
                tabControl1.TabPages.Add(tabPageOrderDetail);
                tabPageOrderDetail.Text = "Add new user";
            };

            //Edit
            btnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageOrderList);
                tabControl1.TabPages.Add(tabPageOrderDetail);
                tabPageOrderDetail.Text = "Edit user";
            };

            //Save
            btnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageOrderDetail);
                    tabControl1.TabPages.Add(tabPageOrderList);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            button6.Click += delegate {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageOrderDetail);
                tabControl1.TabPages.Add(tabPageOrderList);
            };

            //Delete
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Are you sure you want to delete the selected order?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string OrderId
        {
            get { return txtOrderId.Text; }
            set { txtOrderId.Text = value; }
        }
        public string OrderUserId
        {
            get { return txtOrderUserId.Text; }
            set { txtOrderUserId.Text = value; }
        }
        public string OrderAdressId
        {
            get { return txtOrderAddressId.Text; }
            set { txtOrderAddressId.Text = value; }
        }
        public string OrderDeliveryId
        {
            get { return txtOrderDeliveryId.Text; }
            set { txtOrderDeliveryId.Text = value; }
        }
        public string OrderTime
        {
            get { return txtOrderTime.Text; }
            set { txtOrderTime.Text = value; }
        }
        public string OrderStatus
        {
            get { return txtOrderStatus.Text; }
            set { txtOrderStatus.Text = value; }
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

        public void SetOrderListBindingSource(BindingSource orderList)
        {
            dataGridView1.DataSource = orderList;
        }

        //Singleton pattern (Open a single form instance)
        private static OrderView instance;
        public static OrderView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new OrderView();
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
