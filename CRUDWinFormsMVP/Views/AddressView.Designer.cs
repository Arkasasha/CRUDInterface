namespace CRUDWinFormsMVP.Views
{
    partial class AddressView
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
            this.tabPageAddressList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageAddressDetail = new System.Windows.Forms.TabPage();
            this.txtAddressCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddressStreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddressPostalCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddressUserId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddressId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAddressList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageAddressDetail.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1122, 80);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1040, 12);
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
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Addresses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAddressList);
            this.tabControl1.Controls.Add(this.tabPageAddressDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1122, 504);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageAddressList
            // 
            this.tabPageAddressList.Controls.Add(this.dataGridView1);
            this.tabPageAddressList.Controls.Add(this.btnDelete);
            this.tabPageAddressList.Controls.Add(this.btnEdit);
            this.tabPageAddressList.Controls.Add(this.btnAddNew);
            this.tabPageAddressList.Controls.Add(this.btnSearch);
            this.tabPageAddressList.Controls.Add(this.txtSearch);
            this.tabPageAddressList.Controls.Add(this.label2);
            this.tabPageAddressList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAddressList.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddressList.Name = "tabPageAddressList";
            this.tabPageAddressList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddressList.Size = new System.Drawing.Size(1114, 478);
            this.tabPageAddressList.TabIndex = 0;
            this.tabPageAddressList.Text = "Address List";
            this.tabPageAddressList.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Size = new System.Drawing.Size(940, 400);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(971, 153);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(971, 112);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(971, 72);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(107, 30);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(866, 38);
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
            this.txtSearch.Size = new System.Drawing.Size(828, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search user:";
            // 
            // tabPageAddressDetail
            // 
            this.tabPageAddressDetail.Controls.Add(this.txtAddressCity);
            this.tabPageAddressDetail.Controls.Add(this.label8);
            this.tabPageAddressDetail.Controls.Add(this.button6);
            this.tabPageAddressDetail.Controls.Add(this.btnSave);
            this.tabPageAddressDetail.Controls.Add(this.txtAddressStreet);
            this.tabPageAddressDetail.Controls.Add(this.label7);
            this.tabPageAddressDetail.Controls.Add(this.txtAddressPostalCode);
            this.tabPageAddressDetail.Controls.Add(this.label5);
            this.tabPageAddressDetail.Controls.Add(this.txtAddressUserId);
            this.tabPageAddressDetail.Controls.Add(this.label4);
            this.tabPageAddressDetail.Controls.Add(this.txtAddressId);
            this.tabPageAddressDetail.Controls.Add(this.label3);
            this.tabPageAddressDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAddressDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddressDetail.Name = "tabPageAddressDetail";
            this.tabPageAddressDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddressDetail.Size = new System.Drawing.Size(1114, 478);
            this.tabPageAddressDetail.TabIndex = 1;
            this.tabPageAddressDetail.Text = "Address Detail";
            this.tabPageAddressDetail.UseVisualStyleBackColor = true;
            // 
            // txtAddressCity
            // 
            this.txtAddressCity.Location = new System.Drawing.Point(22, 103);
            this.txtAddressCity.Name = "txtAddressCity";
            this.txtAddressCity.Size = new System.Drawing.Size(274, 26);
            this.txtAddressCity.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "City";
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
            // txtAddressStreet
            // 
            this.txtAddressStreet.Location = new System.Drawing.Point(351, 103);
            this.txtAddressStreet.Name = "txtAddressStreet";
            this.txtAddressStreet.Size = new System.Drawing.Size(325, 26);
            this.txtAddressStreet.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Street";
            // 
            // txtAddressPostalCode
            // 
            this.txtAddressPostalCode.Location = new System.Drawing.Point(22, 174);
            this.txtAddressPostalCode.Name = "txtAddressPostalCode";
            this.txtAddressPostalCode.Size = new System.Drawing.Size(274, 26);
            this.txtAddressPostalCode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Postal Code";
            // 
            // txtAddressUserId
            // 
            this.txtAddressUserId.Location = new System.Drawing.Point(351, 35);
            this.txtAddressUserId.Name = "txtAddressUserId";
            this.txtAddressUserId.Size = new System.Drawing.Size(302, 26);
            this.txtAddressUserId.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "User ID";
            // 
            // txtAddressId
            // 
            this.txtAddressId.Location = new System.Drawing.Point(22, 35);
            this.txtAddressId.Name = "txtAddressId";
            this.txtAddressId.ReadOnly = true;
            this.txtAddressId.Size = new System.Drawing.Size(241, 26);
            this.txtAddressId.TabIndex = 1;
            this.txtAddressId.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address ID";
            // 
            // AddressView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 584);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "AddressView";
            this.Text = "AddressView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAddressList.ResumeLayout(false);
            this.tabPageAddressList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageAddressDetail.ResumeLayout(false);
            this.tabPageAddressDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAddressList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageAddressDetail;
        private System.Windows.Forms.TextBox txtAddressCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAddressStreet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddressPostalCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddressUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddressId;
        private System.Windows.Forms.Label label3;
    }
}