namespace Hw1
{
    partial class FormEmployee
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
            this._tabControlEmployee = new System.Windows.Forms.TabControl();
            this._tabPageMealManager = new System.Windows.Forms.TabPage();
            this._buttonDeleteSelectedMeal = new System.Windows.Forms.Button();
            this._buttonAddNewMeal = new System.Windows.Forms.Button();
            this._groupBoxMeal = new System.Windows.Forms.GroupBox();
            this._buttonAddMeal = new System.Windows.Forms.Button();
            this._textBoxDescription = new System.Windows.Forms.TextBox();
            this._comboBoxCategory = new System.Windows.Forms.ComboBox();
            this._labelMealDescription = new System.Windows.Forms.Label();
            this._labelMealCategory = new System.Windows.Forms.Label();
            this._labelMealImageRelativePath = new System.Windows.Forms.Label();
            this._labelNewTaiwanDollars = new System.Windows.Forms.Label();
            this._textBoxPath = new System.Windows.Forms.TextBox();
            this._textBoxMealPrice = new System.Windows.Forms.TextBox();
            this._buttonBrowse = new System.Windows.Forms.Button();
            this._textBoxMealName = new System.Windows.Forms.TextBox();
            this._labelMealPrice = new System.Windows.Forms.Label();
            this._labelMealName = new System.Windows.Forms.Label();
            this._buttonSaveMeal = new System.Windows.Forms.Button();
            this._listBoxAllMeals = new System.Windows.Forms.ListBox();
            this._tabPageCategoryManager = new System.Windows.Forms.TabPage();
            this._buttonDeleteSelectedCategory = new System.Windows.Forms.Button();
            this._buttonAddNewCategory = new System.Windows.Forms.Button();
            this._groupBoxCategory = new System.Windows.Forms.GroupBox();
            this._buttonAddCategory = new System.Windows.Forms.Button();
            this._textBoxCategoryName = new System.Windows.Forms.TextBox();
            this._labelMealsUsingThisCategory = new System.Windows.Forms.Label();
            this._labelCategoryName = new System.Windows.Forms.Label();
            this._buttonSaveCategory = new System.Windows.Forms.Button();
            this._listBoxThisCategory = new System.Windows.Forms.ListBox();
            this._listBoxAllCategories = new System.Windows.Forms.ListBox();
            this._tabControlEmployee.SuspendLayout();
            this._tabPageMealManager.SuspendLayout();
            this._groupBoxMeal.SuspendLayout();
            this._tabPageCategoryManager.SuspendLayout();
            this._groupBoxCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControlEmployee
            // 
            this._tabControlEmployee.Controls.Add(this._tabPageMealManager);
            this._tabControlEmployee.Controls.Add(this._tabPageCategoryManager);
            this._tabControlEmployee.Location = new System.Drawing.Point(12, 12);
            this._tabControlEmployee.Name = "_tabControlEmployee";
            this._tabControlEmployee.SelectedIndex = 0;
            this._tabControlEmployee.Size = new System.Drawing.Size(759, 368);
            this._tabControlEmployee.TabIndex = 0;
            this._tabControlEmployee.SelectedIndexChanged += new System.EventHandler(this.DetectTabControlEmployeeSelectedIndexChanged);
            // 
            // _tabPageMealManager
            // 
            this._tabPageMealManager.Controls.Add(this._buttonDeleteSelectedMeal);
            this._tabPageMealManager.Controls.Add(this._buttonAddNewMeal);
            this._tabPageMealManager.Controls.Add(this._groupBoxMeal);
            this._tabPageMealManager.Controls.Add(this._listBoxAllMeals);
            this._tabPageMealManager.Location = new System.Drawing.Point(4, 22);
            this._tabPageMealManager.Name = "_tabPageMealManager";
            this._tabPageMealManager.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageMealManager.Size = new System.Drawing.Size(751, 342);
            this._tabPageMealManager.TabIndex = 0;
            this._tabPageMealManager.Text = "Meal Manager";
            this._tabPageMealManager.UseVisualStyleBackColor = true;
            // 
            // _buttonDeleteSelectedMeal
            // 
            this._buttonDeleteSelectedMeal.AccessibleName = "_deleteMeal";
            this._buttonDeleteSelectedMeal.Location = new System.Drawing.Point(250, 307);
            this._buttonDeleteSelectedMeal.Name = "_buttonDeleteSelectedMeal";
            this._buttonDeleteSelectedMeal.Size = new System.Drawing.Size(131, 29);
            this._buttonDeleteSelectedMeal.TabIndex = 7;
            this._buttonDeleteSelectedMeal.Text = "Delete Selected Meal";
            this._buttonDeleteSelectedMeal.UseVisualStyleBackColor = true;
            this._buttonDeleteSelectedMeal.Click += new System.EventHandler(this.ButtonDeleteSelectedMealClick);
            // 
            // _buttonAddNewMeal
            // 
            this._buttonAddNewMeal.AccessibleName = "_addNewMeals";
            this._buttonAddNewMeal.Location = new System.Drawing.Point(7, 307);
            this._buttonAddNewMeal.Name = "_buttonAddNewMeal";
            this._buttonAddNewMeal.Size = new System.Drawing.Size(86, 29);
            this._buttonAddNewMeal.TabIndex = 4;
            this._buttonAddNewMeal.Text = "Add New Meal";
            this._buttonAddNewMeal.UseVisualStyleBackColor = true;
            this._buttonAddNewMeal.Click += new System.EventHandler(this.ButtonAddNewMealClick);
            // 
            // _groupBoxMeal
            // 
            this._groupBoxMeal.Controls.Add(this._buttonAddMeal);
            this._groupBoxMeal.Controls.Add(this._textBoxDescription);
            this._groupBoxMeal.Controls.Add(this._comboBoxCategory);
            this._groupBoxMeal.Controls.Add(this._labelMealDescription);
            this._groupBoxMeal.Controls.Add(this._labelMealCategory);
            this._groupBoxMeal.Controls.Add(this._labelMealImageRelativePath);
            this._groupBoxMeal.Controls.Add(this._labelNewTaiwanDollars);
            this._groupBoxMeal.Controls.Add(this._textBoxPath);
            this._groupBoxMeal.Controls.Add(this._textBoxMealPrice);
            this._groupBoxMeal.Controls.Add(this._buttonBrowse);
            this._groupBoxMeal.Controls.Add(this._textBoxMealName);
            this._groupBoxMeal.Controls.Add(this._labelMealPrice);
            this._groupBoxMeal.Controls.Add(this._labelMealName);
            this._groupBoxMeal.Controls.Add(this._buttonSaveMeal);
            this._groupBoxMeal.Location = new System.Drawing.Point(387, 6);
            this._groupBoxMeal.Name = "_groupBoxMeal";
            this._groupBoxMeal.Size = new System.Drawing.Size(357, 330);
            this._groupBoxMeal.TabIndex = 6;
            this._groupBoxMeal.TabStop = false;
            this._groupBoxMeal.Text = "Add New Meal";
            // 
            // _buttonAddMeal
            // 
            this._buttonAddMeal.AccessibleName = "_addMeal";
            this._buttonAddMeal.Location = new System.Drawing.Point(269, 295);
            this._buttonAddMeal.Name = "_buttonAddMeal";
            this._buttonAddMeal.Size = new System.Drawing.Size(82, 29);
            this._buttonAddMeal.TabIndex = 15;
            this._buttonAddMeal.Text = "Add";
            this._buttonAddMeal.UseVisualStyleBackColor = true;
            this._buttonAddMeal.Click += new System.EventHandler(this.ButtonAddMealClick);
            // 
            // _textBoxDescription
            // 
            this._textBoxDescription.AccessibleName = "_textBoxMealInfo";
            this._textBoxDescription.Location = new System.Drawing.Point(14, 210);
            this._textBoxDescription.Multiline = true;
            this._textBoxDescription.Name = "_textBoxDescription";
            this._textBoxDescription.Size = new System.Drawing.Size(337, 79);
            this._textBoxDescription.TabIndex = 14;
            this._textBoxDescription.TextChanged += new System.EventHandler(this.DetectTextBoxDescriptionTextChanged);
            // 
            // _comboBoxCategory
            // 
            this._comboBoxCategory.AccessibleName = "_comboBoxMealCategory";
            this._comboBoxCategory.FormattingEnabled = true;
            this._comboBoxCategory.Location = new System.Drawing.Point(106, 96);
            this._comboBoxCategory.Name = "_comboBoxCategory";
            this._comboBoxCategory.Size = new System.Drawing.Size(121, 20);
            this._comboBoxCategory.TabIndex = 13;
            this._comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.DetectComboBoxCategorySelectedIndexChanged);
            this._comboBoxCategory.DropDownClosed += new System.EventHandler(this.DetectComboBoxCategoryDropDownClosed);
            this._comboBoxCategory.Click += new System.EventHandler(this.DetectComboBoxCategoryClick);
            // 
            // _labelMealDescription
            // 
            this._labelMealDescription.AutoSize = true;
            this._labelMealDescription.Location = new System.Drawing.Point(12, 195);
            this._labelMealDescription.Name = "_labelMealDescription";
            this._labelMealDescription.Size = new System.Drawing.Size(82, 12);
            this._labelMealDescription.TabIndex = 12;
            this._labelMealDescription.Text = "Meal description";
            // 
            // _labelMealCategory
            // 
            this._labelMealCategory.AutoSize = true;
            this._labelMealCategory.Location = new System.Drawing.Point(12, 99);
            this._labelMealCategory.Name = "_labelMealCategory";
            this._labelMealCategory.Size = new System.Drawing.Size(88, 12);
            this._labelMealCategory.TabIndex = 11;
            this._labelMealCategory.Text = "Meal category (*)";
            // 
            // _labelMealImageRelativePath
            // 
            this._labelMealImageRelativePath.AutoSize = true;
            this._labelMealImageRelativePath.Location = new System.Drawing.Point(12, 136);
            this._labelMealImageRelativePath.Name = "_labelMealImageRelativePath";
            this._labelMealImageRelativePath.Size = new System.Drawing.Size(136, 12);
            this._labelMealImageRelativePath.TabIndex = 10;
            this._labelMealImageRelativePath.Text = "Meal image relative path (*)";
            // 
            // _labelNewTaiwanDollars
            // 
            this._labelNewTaiwanDollars.AutoSize = true;
            this._labelNewTaiwanDollars.Location = new System.Drawing.Point(183, 62);
            this._labelNewTaiwanDollars.Name = "_labelNewTaiwanDollars";
            this._labelNewTaiwanDollars.Size = new System.Drawing.Size(28, 12);
            this._labelNewTaiwanDollars.TabIndex = 9;
            this._labelNewTaiwanDollars.Text = "NTD";
            // 
            // _textBoxPath
            // 
            this._textBoxPath.Location = new System.Drawing.Point(14, 163);
            this._textBoxPath.Name = "_textBoxPath";
            this._textBoxPath.ReadOnly = true;
            this._textBoxPath.Size = new System.Drawing.Size(249, 22);
            this._textBoxPath.TabIndex = 8;
            this._textBoxPath.TextChanged += new System.EventHandler(this.DetectTextBoxPathTextChanged);
            // 
            // _textBoxMealPrice
            // 
            this._textBoxMealPrice.AccessibleName = "_textBoxMealPrice";
            this._textBoxMealPrice.Location = new System.Drawing.Point(91, 59);
            this._textBoxMealPrice.Name = "_textBoxMealPrice";
            this._textBoxMealPrice.Size = new System.Drawing.Size(86, 22);
            this._textBoxMealPrice.TabIndex = 7;
            this._textBoxMealPrice.TextChanged += new System.EventHandler(this.DetectTextBoxMealPriceTextChanged);
            // 
            // _buttonBrowse
            // 
            this._buttonBrowse.AccessibleName = "_browse";
            this._buttonBrowse.Location = new System.Drawing.Point(269, 156);
            this._buttonBrowse.Name = "_buttonBrowse";
            this._buttonBrowse.Size = new System.Drawing.Size(82, 29);
            this._buttonBrowse.TabIndex = 6;
            this._buttonBrowse.Text = "Browse...";
            this._buttonBrowse.UseVisualStyleBackColor = true;
            this._buttonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // _textBoxMealName
            // 
            this._textBoxMealName.AccessibleName = "_textBoxMealName";
            this._textBoxMealName.Location = new System.Drawing.Point(91, 22);
            this._textBoxMealName.Name = "_textBoxMealName";
            this._textBoxMealName.Size = new System.Drawing.Size(260, 22);
            this._textBoxMealName.TabIndex = 5;
            this._textBoxMealName.TextChanged += new System.EventHandler(this.DetectTextBoxMealNameTextChanged);
            // 
            // _labelMealPrice
            // 
            this._labelMealPrice.AutoSize = true;
            this._labelMealPrice.Location = new System.Drawing.Point(12, 62);
            this._labelMealPrice.Name = "_labelMealPrice";
            this._labelMealPrice.Size = new System.Drawing.Size(71, 12);
            this._labelMealPrice.TabIndex = 4;
            this._labelMealPrice.Text = "Meal price (*)";
            // 
            // _labelMealName
            // 
            this._labelMealName.AccessibleName = "_labelMealName";
            this._labelMealName.AutoSize = true;
            this._labelMealName.Location = new System.Drawing.Point(12, 25);
            this._labelMealName.Name = "_labelMealName";
            this._labelMealName.Size = new System.Drawing.Size(73, 12);
            this._labelMealName.TabIndex = 3;
            this._labelMealName.Text = "Meal name (*)";
            // 
            // _buttonSaveMeal
            // 
            this._buttonSaveMeal.AccessibleName = "_saveMeal";
            this._buttonSaveMeal.Location = new System.Drawing.Point(269, 295);
            this._buttonSaveMeal.Name = "_buttonSaveMeal";
            this._buttonSaveMeal.Size = new System.Drawing.Size(82, 29);
            this._buttonSaveMeal.TabIndex = 2;
            this._buttonSaveMeal.Text = "Save";
            this._buttonSaveMeal.UseVisualStyleBackColor = true;
            this._buttonSaveMeal.Visible = false;
            this._buttonSaveMeal.Click += new System.EventHandler(this.ButtonSaveMealClick);
            // 
            // _listBoxAllMeals
            // 
            this._listBoxAllMeals.AccessibleName = "_listBoxAllMeals";
            this._listBoxAllMeals.FormattingEnabled = true;
            this._listBoxAllMeals.ItemHeight = 12;
            this._listBoxAllMeals.Location = new System.Drawing.Point(7, 6);
            this._listBoxAllMeals.Name = "_listBoxAllMeals";
            this._listBoxAllMeals.Size = new System.Drawing.Size(374, 292);
            this._listBoxAllMeals.TabIndex = 5;
            this._listBoxAllMeals.SelectedIndexChanged += new System.EventHandler(this.ListBoxAllMealsSelectedIndexChanged);
            // 
            // _tabPageCategoryManager
            // 
            this._tabPageCategoryManager.Controls.Add(this._buttonDeleteSelectedCategory);
            this._tabPageCategoryManager.Controls.Add(this._buttonAddNewCategory);
            this._tabPageCategoryManager.Controls.Add(this._groupBoxCategory);
            this._tabPageCategoryManager.Controls.Add(this._listBoxAllCategories);
            this._tabPageCategoryManager.Location = new System.Drawing.Point(4, 22);
            this._tabPageCategoryManager.Name = "_tabPageCategoryManager";
            this._tabPageCategoryManager.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageCategoryManager.Size = new System.Drawing.Size(751, 342);
            this._tabPageCategoryManager.TabIndex = 1;
            this._tabPageCategoryManager.Text = "Category Manager";
            this._tabPageCategoryManager.UseVisualStyleBackColor = true;
            // 
            // _buttonDeleteSelectedCategory
            // 
            this._buttonDeleteSelectedCategory.AccessibleName = "_deleteCategory";
            this._buttonDeleteSelectedCategory.Location = new System.Drawing.Point(249, 307);
            this._buttonDeleteSelectedCategory.Name = "_buttonDeleteSelectedCategory";
            this._buttonDeleteSelectedCategory.Size = new System.Drawing.Size(131, 29);
            this._buttonDeleteSelectedCategory.TabIndex = 3;
            this._buttonDeleteSelectedCategory.Text = "Delete Selected Category";
            this._buttonDeleteSelectedCategory.UseVisualStyleBackColor = true;
            this._buttonDeleteSelectedCategory.Click += new System.EventHandler(this.ButtonDeleteSelectedCategoryClick);
            // 
            // _buttonAddNewCategory
            // 
            this._buttonAddNewCategory.AccessibleName = "_addNewCategory";
            this._buttonAddNewCategory.Location = new System.Drawing.Point(6, 307);
            this._buttonAddNewCategory.Name = "_buttonAddNewCategory";
            this._buttonAddNewCategory.Size = new System.Drawing.Size(106, 29);
            this._buttonAddNewCategory.TabIndex = 1;
            this._buttonAddNewCategory.Text = "Add New Category";
            this._buttonAddNewCategory.UseVisualStyleBackColor = true;
            this._buttonAddNewCategory.Click += new System.EventHandler(this.ButtonAddNewCategoryClick);
            // 
            // _groupBoxCategory
            // 
            this._groupBoxCategory.Controls.Add(this._buttonAddCategory);
            this._groupBoxCategory.Controls.Add(this._textBoxCategoryName);
            this._groupBoxCategory.Controls.Add(this._labelMealsUsingThisCategory);
            this._groupBoxCategory.Controls.Add(this._labelCategoryName);
            this._groupBoxCategory.Controls.Add(this._buttonSaveCategory);
            this._groupBoxCategory.Controls.Add(this._listBoxThisCategory);
            this._groupBoxCategory.Location = new System.Drawing.Point(386, 6);
            this._groupBoxCategory.Name = "_groupBoxCategory";
            this._groupBoxCategory.Size = new System.Drawing.Size(357, 330);
            this._groupBoxCategory.TabIndex = 2;
            this._groupBoxCategory.TabStop = false;
            this._groupBoxCategory.Text = "Add New Category";
            // 
            // _buttonAddCategory
            // 
            this._buttonAddCategory.AccessibleName = "_addCategory";
            this._buttonAddCategory.Enabled = false;
            this._buttonAddCategory.Location = new System.Drawing.Point(269, 295);
            this._buttonAddCategory.Name = "_buttonAddCategory";
            this._buttonAddCategory.Size = new System.Drawing.Size(82, 29);
            this._buttonAddCategory.TabIndex = 16;
            this._buttonAddCategory.Text = "Add";
            this._buttonAddCategory.UseVisualStyleBackColor = true;
            this._buttonAddCategory.Click += new System.EventHandler(this.ButtonAddCategoryClick);
            // 
            // _textBoxCategoryName
            // 
            this._textBoxCategoryName.AccessibleName = "_textBoxCategoryName";
            this._textBoxCategoryName.Location = new System.Drawing.Point(111, 22);
            this._textBoxCategoryName.Name = "_textBoxCategoryName";
            this._textBoxCategoryName.Size = new System.Drawing.Size(240, 22);
            this._textBoxCategoryName.TabIndex = 5;
            this._textBoxCategoryName.TextChanged += new System.EventHandler(this.DetectTextBoxCategoryNameTextChanged);
            // 
            // _labelMealsUsingThisCategory
            // 
            this._labelMealsUsingThisCategory.AutoSize = true;
            this._labelMealsUsingThisCategory.Location = new System.Drawing.Point(12, 47);
            this._labelMealsUsingThisCategory.Name = "_labelMealsUsingThisCategory";
            this._labelMealsUsingThisCategory.Size = new System.Drawing.Size(125, 12);
            this._labelMealsUsingThisCategory.TabIndex = 4;
            this._labelMealsUsingThisCategory.Text = "Meals using this category:";
            // 
            // _labelCategoryName
            // 
            this._labelCategoryName.AutoSize = true;
            this._labelCategoryName.Location = new System.Drawing.Point(12, 25);
            this._labelCategoryName.Name = "_labelCategoryName";
            this._labelCategoryName.Size = new System.Drawing.Size(93, 12);
            this._labelCategoryName.TabIndex = 3;
            this._labelCategoryName.Text = "Category name (*)";
            // 
            // _buttonSaveCategory
            // 
            this._buttonSaveCategory.AccessibleName = "_saveCategory";
            this._buttonSaveCategory.Location = new System.Drawing.Point(269, 295);
            this._buttonSaveCategory.Name = "_buttonSaveCategory";
            this._buttonSaveCategory.Size = new System.Drawing.Size(82, 29);
            this._buttonSaveCategory.TabIndex = 2;
            this._buttonSaveCategory.Text = "Save";
            this._buttonSaveCategory.UseVisualStyleBackColor = true;
            this._buttonSaveCategory.Visible = false;
            this._buttonSaveCategory.Click += new System.EventHandler(this.ButtonSaveCategoryClick);
            // 
            // _listBoxThisCategory
            // 
            this._listBoxThisCategory.FormattingEnabled = true;
            this._listBoxThisCategory.ItemHeight = 12;
            this._listBoxThisCategory.Location = new System.Drawing.Point(14, 69);
            this._listBoxThisCategory.Name = "_listBoxThisCategory";
            this._listBoxThisCategory.Size = new System.Drawing.Size(337, 220);
            this._listBoxThisCategory.TabIndex = 0;
            // 
            // _listBoxAllCategories
            // 
            this._listBoxAllCategories.AccessibleName = "_listBoxAllCategories";
            this._listBoxAllCategories.FormattingEnabled = true;
            this._listBoxAllCategories.ItemHeight = 12;
            this._listBoxAllCategories.Location = new System.Drawing.Point(6, 6);
            this._listBoxAllCategories.Name = "_listBoxAllCategories";
            this._listBoxAllCategories.Size = new System.Drawing.Size(374, 292);
            this._listBoxAllCategories.TabIndex = 1;
            this._listBoxAllCategories.SelectedIndexChanged += new System.EventHandler(this.ListBoxAllCategoriesSelectedIndexChanged);
            // 
            // FormEmployee
            // 
            this.AccessibleName = "formEmployee";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 387);
            this.Controls.Add(this._tabControlEmployee);
            this.Name = "FormEmployee";
            this.Text = "formEmployee";
            this._tabControlEmployee.ResumeLayout(false);
            this._tabPageMealManager.ResumeLayout(false);
            this._groupBoxMeal.ResumeLayout(false);
            this._groupBoxMeal.PerformLayout();
            this._tabPageCategoryManager.ResumeLayout(false);
            this._groupBoxCategory.ResumeLayout(false);
            this._groupBoxCategory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControlEmployee;
        private System.Windows.Forms.TabPage _tabPageMealManager;
        private System.Windows.Forms.TabPage _tabPageCategoryManager;
        private System.Windows.Forms.Button _buttonSaveCategory;
        private System.Windows.Forms.Button _buttonDeleteSelectedCategory;
        private System.Windows.Forms.GroupBox _groupBoxCategory;
        private System.Windows.Forms.Button _buttonAddNewCategory;
        private System.Windows.Forms.ListBox _listBoxThisCategory;
        private System.Windows.Forms.ListBox _listBoxAllCategories;
        private System.Windows.Forms.TextBox _textBoxCategoryName;
        private System.Windows.Forms.Label _labelMealsUsingThisCategory;
        private System.Windows.Forms.Label _labelCategoryName;
        private System.Windows.Forms.Button _buttonDeleteSelectedMeal;
        private System.Windows.Forms.Button _buttonAddNewMeal;
        private System.Windows.Forms.GroupBox _groupBoxMeal;
        private System.Windows.Forms.TextBox _textBoxMealName;
        private System.Windows.Forms.Label _labelMealPrice;
        private System.Windows.Forms.Label _labelMealName;
        private System.Windows.Forms.Button _buttonSaveMeal;
        private System.Windows.Forms.ListBox _listBoxAllMeals;
        private System.Windows.Forms.Label _labelMealCategory;
        private System.Windows.Forms.Label _labelMealImageRelativePath;
        private System.Windows.Forms.Label _labelNewTaiwanDollars;
        private System.Windows.Forms.TextBox _textBoxPath;
        private System.Windows.Forms.TextBox _textBoxMealPrice;
        private System.Windows.Forms.Button _buttonBrowse;
        private System.Windows.Forms.ComboBox _comboBoxCategory;
        private System.Windows.Forms.Label _labelMealDescription;
        private System.Windows.Forms.TextBox _textBoxDescription;
        private System.Windows.Forms.Button _buttonAddMeal;
        private System.Windows.Forms.Button _buttonAddCategory;

    }
}