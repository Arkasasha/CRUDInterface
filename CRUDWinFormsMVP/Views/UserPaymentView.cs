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
    public partial class UserPaymentView : Form, IUserPaymentView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Constructor
        public UserPaymentView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageUserPaymentDetail);
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
                tabControl1.TabPages.Remove(tabPageUserPaymentList);
                tabControl1.TabPages.Add(tabPageUserPaymentDetail);
                tabPageUserPaymentDetail.Text = "Add new payment method";
            };

            //Edit
            btnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageUserPaymentList);
                tabControl1.TabPages.Add(tabPageUserPaymentDetail);
                tabPageUserPaymentDetail.Text = "View payment method";
            };

            //Save
            btnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageUserPaymentDetail);
                    tabControl1.TabPages.Add(tabPageUserPaymentList);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            button6.Click += delegate {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageUserPaymentDetail);
                tabControl1.TabPages.Add(tabPageUserPaymentList);
            };

            //Delete
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Are you sure you want to delete the selected payment method?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string UserPaymentId
        {
            get { return txtUserPaymentId.Text; }
            set { txtUserPaymentId.Text = value; }
        }
        public string UserPaymentUserId
        {
            get { return txtUserPaymentUserId.Text; }
            set { txtUserPaymentUserId.Text = value; }
        }
        public string UserPaymentPaymentType
        {
            get { return txtUserPaymentPaymentType.Text; }
            set { txtUserPaymentPaymentType.Text = value; }
        }
        public string UserPaymentAccountNumber
        {
            get { return txtUserPaymentAccountNumber.Text; }
            set { txtUserPaymentAccountNumber.Text = value; }
        }
        public string UserPaymentExpireDate
        {
            get { return txtUserPaymentExpireDate.Text; }
            set { txtUserPaymentExpireDate.Text = value; }
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

        public void SetUserPaymentListBindingSource(BindingSource userpaymentList)
        {
            dataGridView1.DataSource = userpaymentList;
        }

        //Singleton pattern (Open a single form instance)
        private static UserPaymentView instance;
        public static UserPaymentView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new UserPaymentView();
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
