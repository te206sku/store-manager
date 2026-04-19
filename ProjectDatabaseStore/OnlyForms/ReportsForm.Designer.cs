namespace ProjectDatabaseStore
{
    partial class ReportsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGoodsStoreBase = new System.Windows.Forms.Button();
            this.btnMissingGoods = new System.Windows.Forms.Button();
            this.btnGoodsByDepartment = new System.Windows.Forms.Button();
            this.btnManagers = new System.Windows.Forms.Button();
            this.btnDepartmentCost = new System.Windows.Forms.Button();
            this.btnSuppliersByProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 435);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnGoodsStoreBase
            // 
            this.btnGoodsStoreBase.Location = new System.Drawing.Point(516, 42);
            this.btnGoodsStoreBase.Name = "btnGoodsStoreBase";
            this.btnGoodsStoreBase.Size = new System.Drawing.Size(272, 61);
            this.btnGoodsStoreBase.TabIndex = 1;
            this.btnGoodsStoreBase.Text = "Товары в магазине и на базе";
            this.btnGoodsStoreBase.UseVisualStyleBackColor = true;
            this.btnGoodsStoreBase.Click += new System.EventHandler(this.btnGoodsStoreBase_Click);
            // 
            // btnMissingGoods
            // 
            this.btnMissingGoods.Location = new System.Drawing.Point(516, 109);
            this.btnMissingGoods.Name = "btnMissingGoods";
            this.btnMissingGoods.Size = new System.Drawing.Size(272, 61);
            this.btnMissingGoods.TabIndex = 2;
            this.btnMissingGoods.Text = "Отсутствующие товары для заказа";
            this.btnMissingGoods.UseVisualStyleBackColor = true;
            this.btnMissingGoods.Click += new System.EventHandler(this.btnMissingGoods_Click);
            // 
            // btnGoodsByDepartment
            // 
            this.btnGoodsByDepartment.Location = new System.Drawing.Point(516, 176);
            this.btnGoodsByDepartment.Name = "btnGoodsByDepartment";
            this.btnGoodsByDepartment.Size = new System.Drawing.Size(272, 61);
            this.btnGoodsByDepartment.TabIndex = 3;
            this.btnGoodsByDepartment.Text = "Товары по отделам";
            this.btnGoodsByDepartment.UseVisualStyleBackColor = true;
            this.btnGoodsByDepartment.Click += new System.EventHandler(this.btnGoodsByDepartment_Click);
            // 
            // btnManagers
            // 
            this.btnManagers.Location = new System.Drawing.Point(516, 243);
            this.btnManagers.Name = "btnManagers";
            this.btnManagers.Size = new System.Drawing.Size(272, 61);
            this.btnManagers.TabIndex = 4;
            this.btnManagers.Text = "Список заведующих";
            this.btnManagers.UseVisualStyleBackColor = true;
            this.btnManagers.Click += new System.EventHandler(this.btnManagers_Click);
            // 
            // btnDepartmentCost
            // 
            this.btnDepartmentCost.Location = new System.Drawing.Point(516, 310);
            this.btnDepartmentCost.Name = "btnDepartmentCost";
            this.btnDepartmentCost.Size = new System.Drawing.Size(272, 61);
            this.btnDepartmentCost.TabIndex = 5;
            this.btnDepartmentCost.Text = "Стоимость по отделам";
            this.btnDepartmentCost.UseVisualStyleBackColor = true;
            this.btnDepartmentCost.Click += new System.EventHandler(this.btnDepartmentCost_Click);
            // 
            // btnSuppliersByProduct
            // 
            this.btnSuppliersByProduct.Location = new System.Drawing.Point(516, 377);
            this.btnSuppliersByProduct.Name = "btnSuppliersByProduct";
            this.btnSuppliersByProduct.Size = new System.Drawing.Size(272, 61);
            this.btnSuppliersByProduct.TabIndex = 6;
            this.btnSuppliersByProduct.Text = "Наличие товара у поставщиков";
            this.btnSuppliersByProduct.UseVisualStyleBackColor = true;
            this.btnSuppliersByProduct.Click += new System.EventHandler(this.btnSuppliersByProduct_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSuppliersByProduct);
            this.Controls.Add(this.btnDepartmentCost);
            this.Controls.Add(this.btnManagers);
            this.Controls.Add(this.btnGoodsByDepartment);
            this.Controls.Add(this.btnMissingGoods);
            this.Controls.Add(this.btnGoodsStoreBase);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGoodsStoreBase;
        private System.Windows.Forms.Button btnMissingGoods;
        private System.Windows.Forms.Button btnGoodsByDepartment;
        private System.Windows.Forms.Button btnManagers;
        private System.Windows.Forms.Button btnDepartmentCost;
        private System.Windows.Forms.Button btnSuppliersByProduct;
    }
}