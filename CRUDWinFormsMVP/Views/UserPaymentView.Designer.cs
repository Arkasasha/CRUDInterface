namespace CRUDWinFormsMVP.Views
{
    partial class UserPaymentView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUserPaymentList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageUserPaymentDetail = new System.Windows.Forms.TabPage();
            this.txtUserPaymentPaymentType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserPaymentExpireDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserPaymentAccountNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserPaymentUserId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserPaymentId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageUserPaymentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageUserPaymentDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 80);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1056, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Methods";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUserPaymentList);
            this.tabControl1.Controls.Add(this.tabPageUserPaymentDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1138, 495);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageUserPaymentList
            // 
            this.tabPageUserPaymentList.Controls.Add(this.dataGridView1);
            this.tabPageUserPaymentList.Controls.Add(this.btnDelete);
            this.tabPageUserPaymentList.Controls.Add(this.btnEdit);
            this.tabPageUserPaymentList.Controls.Add(this.btnAddNew);
            this.tabPageUserPaymentList.Controls.Add(this.btnSearch);
            this.tabPageUserPaymentList.Controls.Add(this.txtSearch);
            this.tabPageUserPaymentList.Controls.Add(this.label2);
            this.tabPageUserPaymentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageUserPaymentList.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserPaymentList.Name = "tabPageUserPaymentList";
            this.tabPageUserPaymentList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserPaymentList.Size = new System.Drawing.Size(1130, 469);
            this.tabPageUserPaymentList.TabIndex = 0;
            this.tabPageUserPaymentList.Text = "Payment Method List";
            this.tabPageUserPaymentList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(956, 391);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(987, 153);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(987, 112);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(987, 72);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(107, 30);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(882, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(25, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(844, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search payment method:";
            // 
            // tabPageUserPaymentDetail
            // 
            this.tabPageUserPaymentDetail.Controls.Add(this.txtUserPaymentPaymentType);
            this.tabPageUserPaymentDetail.Controls.Add(this.label8);
            this.tabPageUserPaymentDetail.Controls.Add(this.button6);
            this.tabPageUserPaymentDetail.Controls.Add(this.btnSave);
            this.tabPageUserPaymentDetail.Controls.Add(this.txtUserPaymentExpireDate);
            this.tabPageUserPaymentDetail.Controls.Add(this.label6);
            this.tabPageUserPaymentDetail.Controls.Add(this.txtUserPaymentAccountNumber);
            this.tabPageUserPaymentDetail.Controls.Add(this.label5);
            this.tabPageUserPaymentDetail.Controls.Add(this.txtUserPaymentUserId);
            this.tabPageUserPaymentDetail.Controls.Add(this.label4);
            this.tabPageUserPaymentDetail.Controls.Add(this.txtUserPaymentId);
            this.tabPageUserPaymentDetail.Controls.Add(this.label3);
            this.tabPageUserPaymentDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageUserPaymentDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserPaymentDetail.Name = "tabPageUserPaymentDetail";
            this.tabPageUserPaymentDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserPaymentDetail.Size = new System.Drawing.Size(1130, 469);
            this.tabPageUserPaymentDetail.TabIndex = 1;
            this.tabPageUserPaymentDetail.Text = "Payment Method Detail";
            this.tabPageUserPaymentDetail.UseVisualStyleBackColor = true;
            // 
            // txtUserPaymentPaymentType
            // 
            this.txtUserPaymentPaymentType.Location = new System.Drawing.Point(22, 103);
            this.txtUserPaymentPaymentType.Name = "txtUserPaymentPaymentType";
            this.txtUserPaymentPaymentType.Size = new System.Drawing.Size(274, 26);
            this.txtUserPaymentPaymentType.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Payment Type";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(164, 237);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 37);
            this.button6.TabIndex = 11;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 37);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtUserPaymentExpireDate
            // 
            this.txtUserPaymentExpireDate.Location = new System.Drawing.Point(351, 174);
            this.txtUserPaymentExpireDate.Name = "txtUserPaymentExpireDate";
            this.txtUserPaymentExpireDate.Size = new System.Drawing.Size(274, 26);
            this.txtUserPaymentExpireDate.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Expire Date";
            // 
            // txtUserPaymentAccountNumber
            // 
            this.txtUserPaymentAccountNumber.Location = new System.Drawing.Point(22, 174);
            this.txtUserPaymentAccountNumber.Name = "txtUserPaymentAccountNumber";
            this.txtUserPaymentAccountNumber.Size = new System.Drawing.Size(274, 26);
            this.txtUserPaymentAccountNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Account Number";
            // 
            // txtUserPaymentUserId
            // 
            this.txtUserPaymentUserId.Location = new System.Drawing.Point(351, 35);
            this.txtUserPaymentUserId.Name = "txtUserPaymentUserId";
            this.txtUserPaymentUserId.Size = new System.Drawing.Size(302, 26);
            this.txtUserPaymentUserId.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "User ID";
            // 
            // txtUserPaymentId
            // 
            this.txtUserPaymentId.Location = new System.Drawing.Point(22, 35);
            this.txtUserPaymentId.Name = "txtUserPaymentId";
            this.txtUserPaymentId.ReadOnly = true;
            this.txtUserPaymentId.Size = new System.Drawing.Size(241, 26);
            this.txtUserPaymentId.TabIndex = 1;
            this.txtUserPaymentId.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment ID";
            // 
            // UserPaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 575);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "UserPaymentView";
            this.Text = "UserPaymentView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageUserPaymentList.ResumeLayout(false);
            this.tabPageUserPaymentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageUserPaymentDetail.ResumeLayout(false);
            this.tabPageUserPaymentDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUserPaymentList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageUserPaymentDetail;
        private System.Windows.Forms.TextBox txtUserPaymentPaymentType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUserPaymentExpireDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserPaymentAccountNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserPaymentUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserPaymentId;
        private System.Windows.Forms.Label label3;
    }
}