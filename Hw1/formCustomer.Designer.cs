namespace Hw1
{
    partial class FormCustomer
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
            this._groupBoxMenu = new System.Windows.Forms.GroupBox();
            this._tabControlMealButtons = new System.Windows.Forms.TabControl();
            this._richTextBoxMeal = new System.Windows.Forms.RichTextBox();
            this._labelPage = new System.Windows.Forms.Label();
            this._buttonNextPage = new System.Windows.Forms.Button();
            this._buttonPreviousPage = new System.Windows.Forms.Button();
            this._dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.columnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnMeal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSinglePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMealNumbers = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.columnSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._labelTotal = new System.Windows.Forms.Label();
            this._groupBoxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBoxMenu
            // 
            this._groupBoxMenu.Controls.Add(this._tabControlMealButtons);
            this._groupBoxMenu.Controls.Add(this._richTextBoxMeal);
            this._groupBoxMenu.Controls.Add(this._labelPage);
            this._groupBoxMenu.Controls.Add(this._buttonNextPage);
            this._groupBoxMenu.Controls.Add(this._buttonPreviousPage);
            this._groupBoxMenu.Location = new System.Drawing.Point(12, 12);
            this._groupBoxMenu.Name = "_groupBoxMenu";
            this._groupBoxMenu.Size = new System.Drawing.Size(327, 493);
            this._groupBoxMenu.TabIndex = 0;
            this._groupBoxMenu.TabStop = false;
            this._groupBoxMenu.Text = "餐點";
            // 
            // _tabControlMealButtons
            // 
            this._tabControlMealButtons.Location = new System.Drawing.Point(6, 21);
            this._tabControlMealButtons.Name = "_tabControlMealButtons";
            this._tabControlMealButtons.SelectedIndex = 0;
            this._tabControlMealButtons.Size = new System.Drawing.Size(315, 349);
            this._tabControlMealButtons.TabIndex = 4;
            this._tabControlMealButtons.SelectedIndexChanged += new System.EventHandler(this.DetectTabControlMealButtonsSelectedIndexChanged);
            // 
            // _richTextBoxMeal
            // 
            this._richTextBoxMeal.Location = new System.Drawing.Point(6, 376);
            this._richTextBoxMeal.Name = "_richTextBoxMeal";
            this._richTextBoxMeal.ReadOnly = true;
            this._richTextBoxMeal.Size = new System.Drawing.Size(315, 74);
            this._richTextBoxMeal.TabIndex = 3;
            this._richTextBoxMeal.Text = "";
            // 
            // _labelPage
            // 
            this._labelPage.AccessibleName = "_labelPage";
            this._labelPage.AutoSize = true;
            this._labelPage.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._labelPage.Location = new System.Drawing.Point(7, 474);
            this._labelPage.Name = "_labelPage";
            this._labelPage.Size = new System.Drawing.Size(86, 16);
            this._labelPage.TabIndex = 2;
            this._labelPage.Text = "_labelPage";
            // 
            // _buttonNextPage
            // 
            this._buttonNextPage.AccessibleName = "_nextPage";
            this._buttonNextPage.Location = new System.Drawing.Point(252, 456);
            this._buttonNextPage.Name = "_buttonNextPage";
            this._buttonNextPage.Size = new System.Drawing.Size(69, 31);
            this._buttonNextPage.TabIndex = 1;
            this._buttonNextPage.Text = "下一頁";
            this._buttonNextPage.UseVisualStyleBackColor = true;
            this._buttonNextPage.Click += new System.EventHandler(this.ButtonNextPageClick);
            // 
            // _buttonPreviousPage
            // 
            this._buttonPreviousPage.AccessibleName = "_previousPage";
            this._buttonPreviousPage.Enabled = false;
            this._buttonPreviousPage.Location = new System.Drawing.Point(177, 456);
            this._buttonPreviousPage.Name = "_buttonPreviousPage";
            this._buttonPreviousPage.Size = new System.Drawing.Size(69, 31);
            this._buttonPreviousPage.TabIndex = 0;
            this._buttonPreviousPage.Text = "上一頁";
            this._buttonPreviousPage.UseVisualStyleBackColor = true;
            this._buttonPreviousPage.Click += new System.EventHandler(this.ButtonPreviousPageClick);
            // 
            // _dataGridViewOrders
            // 
            this._dataGridViewOrders.AccessibleName = "_dataGridViewOrders";
            this._dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDelete,
            this.columnMeal,
            this.columnCategory,
            this.columnSinglePrice,
            this.columnMealNumbers,
            this.columnSum});
            this._dataGridViewOrders.Location = new System.Drawing.Point(345, 12);
            this._dataGridViewOrders.Name = "_dataGridViewOrders";
            this._dataGridViewOrders.RowTemplate.Height = 24;
            this._dataGridViewOrders.Size = new System.Drawing.Size(437, 395);
            this._dataGridViewOrders.TabIndex = 1;
            this._dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewOrdersCellContent);
            this._dataGridViewOrders.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeDataGridViewOrdersCellValue);
            // 
            // columnDelete
            // 
            this.columnDelete.HeaderText = "刪除";
            this.columnDelete.Name = "columnDelete";
            this.columnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDelete.Text = "X";
            this.columnDelete.UseColumnTextForButtonValue = true;
            this.columnDelete.Width = 60;
            // 
            // columnMeal
            // 
            this.columnMeal.HeaderText = "餐點";
            this.columnMeal.Name = "columnMeal";
            this.columnMeal.ReadOnly = true;
            this.columnMeal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // columnCategory
            // 
            this.columnCategory.HeaderText = "種類";
            this.columnCategory.Name = "columnCategory";
            this.columnCategory.ReadOnly = true;
            this.columnCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnCategory.Width = 70;
            // 
            // columnSinglePrice
            // 
            this.columnSinglePrice.HeaderText = "單價";
            this.columnSinglePrice.Name = "columnSinglePrice";
            this.columnSinglePrice.ReadOnly = true;
            this.columnSinglePrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnSinglePrice.Width = 60;
            // 
            // columnMealNumbers
            // 
            this.columnMealNumbers.HeaderText = "數量";
            this.columnMealNumbers.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnMealNumbers.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.columnMealNumbers.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.columnMealNumbers.Name = "columnMealNumbers";
            this.columnMealNumbers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnMealNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnMealNumbers.Width = 60;
            // 
            // columnSum
            // 
            this.columnSum.HeaderText = "小計";
            this.columnSum.Name = "columnSum";
            this.columnSum.ReadOnly = true;
            this.columnSum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnSum.Width = 60;
            // 
            // _labelTotal
            // 
            this._labelTotal.AccessibleName = "_labelTotal";
            this._labelTotal.AutoSize = true;
            this._labelTotal.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._labelTotal.Location = new System.Drawing.Point(345, 412);
            this._labelTotal.Name = "_labelTotal";
            this._labelTotal.Size = new System.Drawing.Size(139, 27);
            this._labelTotal.TabIndex = 2;
            this._labelTotal.Text = "_labelTotal";
            // 
            // FormCustomer
            // 
            this.AccessibleName = "formCustomer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 517);
            this.Controls.Add(this._labelTotal);
            this.Controls.Add(this._dataGridViewOrders);
            this.Controls.Add(this._groupBoxMenu);
            this.Name = "FormCustomer";
            this.Text = "formCustomer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOrderFrontFormClosed);
            this._groupBoxMenu.ResumeLayout(false);
            this._groupBoxMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxMenu;
        private System.Windows.Forms.Button _buttonNextPage;
        private System.Windows.Forms.Button _buttonPreviousPage;
        private System.Windows.Forms.DataGridView _dataGridViewOrders;
        private System.Windows.Forms.Label _labelTotal;
        private System.Windows.Forms.Label _labelPage;
        private System.Windows.Forms.RichTextBox _richTextBoxMeal;
        private System.Windows.Forms.DataGridViewButtonColumn _columnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnMeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnSinglePrice;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _columnMealNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnSum;
        private System.Windows.Forms.TabControl _tabControlMealButtons;
        private System.Windows.Forms.DataGridViewButtonColumn columnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSinglePrice;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn columnMealNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSum;
    }
}

