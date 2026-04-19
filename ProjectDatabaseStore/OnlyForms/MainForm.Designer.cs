namespace ProjectDatabaseStore
{
    partial class MainForm
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
            this.btnStore = new System.Windows.Forms.Button();
            this.btnProductCategory = new System.Windows.Forms.Button();
            this.btnSupplierProduct = new System.Windows.Forms.Button();
            this.btnDepartmentProduct = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnPurchaseRequest = new System.Windows.Forms.Button();
            this.btnMonthlyReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(27, 157);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(223, 91);
            this.btnStore.TabIndex = 3;
            this.btnStore.Text = "Магазины";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnProductCategory
            // 
            this.btnProductCategory.Location = new System.Drawing.Point(296, 157);
            this.btnProductCategory.Name = "btnProductCategory";
            this.btnProductCategory.Size = new System.Drawing.Size(223, 91);
            this.btnProductCategory.TabIndex = 4;
            this.btnProductCategory.Text = "Категории товаров";
            this.btnProductCategory.UseVisualStyleBackColor = true;
            this.btnProductCategory.Click += new System.EventHandler(this.btnProductCategory_Click);
            // 
            // btnSupplierProduct
            // 
            this.btnSupplierProduct.Location = new System.Drawing.Point(27, 38);
            this.btnSupplierProduct.Name = "btnSupplierProduct";
            this.btnSupplierProduct.Size = new System.Drawing.Size(223, 91);
            this.btnSupplierProduct.TabIndex = 5;
            this.btnSupplierProduct.Text = "Товары у поставщиков";
            this.btnSupplierProduct.UseVisualStyleBackColor = true;
            this.btnSupplierProduct.Click += new System.EventHandler(this.btnSupplierProduct_Click);
            // 
            // btnDepartmentProduct
            // 
            this.btnDepartmentProduct.Location = new System.Drawing.Point(565, 157);
            this.btnDepartmentProduct.Name = "btnDepartmentProduct";
            this.btnDepartmentProduct.Size = new System.Drawing.Size(223, 91);
            this.btnDepartmentProduct.TabIndex = 6;
            this.btnDepartmentProduct.Text = "Товары в отделах";
            this.btnDepartmentProduct.UseVisualStyleBackColor = true;
            this.btnDepartmentProduct.Click += new System.EventHandler(this.btnDepartmentProduct_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Location = new System.Drawing.Point(27, 300);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(223, 91);
            this.btnDepartment.TabIndex = 7;
            this.btnDepartment.Text = "Отделы";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(296, 300);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(223, 91);
            this.btnSupplier.TabIndex = 8;
            this.btnSupplier.Text = "Поставщики";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(565, 300);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(223, 91);
            this.btnProduct.TabIndex = 9;
            this.btnProduct.Text = "Товары";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(296, 38);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(223, 91);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "Отчёты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnPurchaseRequest
            // 
            this.btnPurchaseRequest.Location = new System.Drawing.Point(565, 38);
            this.btnPurchaseRequest.Name = "btnPurchaseRequest";
            this.btnPurchaseRequest.Size = new System.Drawing.Size(223, 91);
            this.btnPurchaseRequest.TabIndex = 11;
            this.btnPurchaseRequest.Text = "Заявка на закупку";
            this.btnPurchaseRequest.UseVisualStyleBackColor = true;
            this.btnPurchaseRequest.Click += new System.EventHandler(this.btnPurchaseRequest_Click);
            // 
            // btnMonthlyReport
            // 
            this.btnMonthlyReport.Location = new System.Drawing.Point(61, 397);
            this.btnMonthlyReport.Name = "btnMonthlyReport";
            this.btnMonthlyReport.Size = new System.Drawing.Size(679, 49);
            this.btnMonthlyReport.TabIndex = 12;
            this.btnMonthlyReport.Text = "Ежемесячный отчёт";
            this.btnMonthlyReport.UseVisualStyleBackColor = true;
            this.btnMonthlyReport.Click += new System.EventHandler(this.btnMonthlyReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMonthlyReport);
            this.Controls.Add(this.btnPurchaseRequest);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnDepartment);
            this.Controls.Add(this.btnDepartmentProduct);
            this.Controls.Add(this.btnSupplierProduct);
            this.Controls.Add(this.btnProductCategory);
            this.Controls.Add(this.btnStore);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет магазина";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnProductCategory;
        private System.Windows.Forms.Button btnSupplierProduct;
        private System.Windows.Forms.Button btnDepartmentProduct;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnPurchaseRequest;
        private System.Windows.Forms.Button btnMonthlyReport;
    }
}