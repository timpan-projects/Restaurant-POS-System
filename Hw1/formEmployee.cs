using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Hw1
{
    public partial class FormEmployee : Form
    {
        private Model _model;
        private FormEmployeePresentationModel _viewModel;
        private const string ADD_NEW_CATEGORY = "Add New Category";
        private const string ADD_NEW_MEAL = "Add New Meal";
        public FormEmployee(Model model)
        {
            _model = model;
            _viewModel = new FormEmployeePresentationModel(_model);
            InitializeComponent();
            RefreshControls();
            _viewModel.LoadMealList(_listBoxAllMeals);
        }
        void RefreshControls()//每個事件裡面都放一個，控制所有Controllers
        {
            _buttonAddNewMeal.Enabled = _viewModel.EnableButtonAddNewMeal(_groupBoxMeal);
            _buttonDeleteSelectedMeal.Enabled = _viewModel.EnableButtonDeleteSelectedMeal(_listBoxAllMeals);
            _buttonSaveMeal.Visible = _viewModel.DecideButtonSaveMealVisible(_groupBoxMeal);
            _buttonSaveMeal.Enabled = _viewModel.EnableButtonSaveMeal(_buttonSaveMeal, _textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _listBoxAllMeals);
            _buttonAddMeal.Visible = _viewModel.DecideButtonAddMealVisible(_groupBoxMeal);
            _buttonAddMeal.Enabled = _viewModel.EnableButtonAddMeal(_buttonAddMeal, _textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath , _listBoxAllMeals);
            _buttonAddNewCategory.Enabled = _viewModel.EnableButtonAddNewCategory(_groupBoxCategory);
            _buttonDeleteSelectedCategory.Enabled = _viewModel.EnableButtonDeleteSelectedCategory(_listBoxAllCategories, _listBoxThisCategory);
            _buttonSaveCategory.Visible = _viewModel.DecideButtonSaveCategoryVisible(_groupBoxCategory);
            _buttonSaveCategory.Enabled = _viewModel.EnableButtonSaveCategory(_buttonSaveCategory, _textBoxCategoryName, _listBoxAllCategories);
            _buttonAddCategory.Visible = _viewModel.DecideButtonAddCategoryVisible(_groupBoxCategory);
            _buttonAddCategory.Enabled = _viewModel.EnableButtonAddCategory(_buttonAddCategory, _textBoxCategoryName, _listBoxAllCategories);
        }

        //通用
        private void DetectTabControlEmployeeSelectedIndexChanged(object sender, EventArgs e)
        {
            //全部更新
            _listBoxAllMeals.ClearSelected();
            _listBoxAllCategories.ClearSelected();
            _viewModel.ClearAllMealTextBoxes(_textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);
            _viewModel.ClearAllCategoryTextBoxes(_textBoxCategoryName, _listBoxThisCategory);
            _viewModel.LoadCategoryList(_listBoxAllCategories);
            _viewModel.LoadMealList(_listBoxAllMeals);
            RefreshControls();
        }

        //page1
        private void ListBoxAllMealsSelectedIndexChanged(object sender, EventArgs e)//餐點ListBox選擇的餐點改變
        {
            if (_listBoxAllMeals.SelectedItem != null)
            {
                _viewModel.ChangeGroupBoxText(_groupBoxMeal, "Edit Meal");
                _viewModel.ShowMealData(_viewModel.SearchSelectedMealID(_viewModel.ChangeSelectedItemToString(_listBoxAllMeals))/*回傳餐點ID*/, _textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);//把餐點資料顯示在各個TextBox
                //textBoxMealName.ReadOnly = true;
            }
            else
                _textBoxMealName.ReadOnly = false;
            RefreshControls();
        }

        private void ButtonAddNewMealClick(object sender, EventArgs e)//切換成『新增餐點』模式
        {
            _listBoxAllMeals.ClearSelected();
            _viewModel.ChangeGroupBoxText(_groupBoxMeal,ADD_NEW_MEAL);
            _viewModel.ClearAllMealTextBoxes(_textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);
            RefreshControls();
        }

        private void ButtonDeleteSelectedMealClick(object sender, EventArgs e)//點擊『刪除餐點』按鈕時觸發
        {
            _viewModel.DeleteSelectedMeal(_listBoxAllMeals);
            _listBoxAllMeals.ClearSelected();
            _viewModel.ClearAllMealTextBoxes(_textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);
            _viewModel.LoadMealList(_listBoxAllMeals);
            _viewModel.ChangeGroupBoxText(_groupBoxMeal, ADD_NEW_MEAL);
            RefreshControls();
            _model.NotifyMealObserver();
        }

        private void ButtonAddMealClick(object sender, EventArgs e)//點擊『新增餐點』按鈕時觸發
        {
            _viewModel.ReadTextBoxesAndAddMeal(_listBoxAllMeals, _textBoxMealName.Text, _textBoxMealPrice.Text, _comboBoxCategory.Text, _textBoxPath.Text, _textBoxDescription.Text);
            _listBoxAllMeals.ClearSelected();
            _viewModel.ClearAllMealTextBoxes(_textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);
            RefreshControls();
            _model.NotifyMealObserver();
        }

        private void ButtonSaveMealClick(object sender, EventArgs e)//點擊『儲存餐點』按鈕時觸發
        {
            _viewModel.ReadTextBoxesAndSaveMeal(_listBoxAllMeals, _textBoxMealName.Text, _textBoxMealPrice.Text, _comboBoxCategory.Text, _textBoxPath.Text, _textBoxDescription.Text);
            _viewModel.ClearAllMealTextBoxes(_textBoxMealName, _textBoxMealPrice, _comboBoxCategory, _textBoxPath, _textBoxDescription);
            _viewModel.ChangeGroupBoxText(_groupBoxMeal, ADD_NEW_MEAL);
            RefreshControls();
            _viewModel.LoadMealList(_listBoxAllMeals);
            _model.NotifyMealObserver();
        }

        //page2
        private void ListBoxAllCategoriesSelectedIndexChanged(object sender, EventArgs e)//種類ListBox選擇的種類改變時
        {
            if (_listBoxAllCategories.SelectedItem != null)
            {
                _viewModel.ChangeGroupBoxText(_groupBoxCategory, "Edit Category");
                _viewModel.ClearAllCategoryTextBoxes(_textBoxCategoryName, _listBoxThisCategory);
                _viewModel.ShowCategoryData(_listBoxAllCategories, _textBoxCategoryName, _listBoxThisCategory);
                //textBoxCategoryName.ReadOnly = true;
            }
            else
                _textBoxCategoryName.ReadOnly = false;
            RefreshControls();
        }

        private void ButtonAddNewCategoryClick(object sender, EventArgs e)//切換成『新增種類』模式
        {
            _listBoxAllCategories.ClearSelected();
            _viewModel.ChangeGroupBoxText(_groupBoxCategory,ADD_NEW_CATEGORY);
            _viewModel.ClearAllCategoryTextBoxes(_textBoxCategoryName, _listBoxThisCategory);
            RefreshControls();
        }

        private void ButtonDeleteSelectedCategoryClick(object sender, EventArgs e)//點擊『刪除種類』按鈕時觸發
        {
            _viewModel.DeleteSelectedEmptyCategory(_listBoxAllCategories, _listBoxThisCategory, _textBoxCategoryName, _groupBoxCategory);
            RefreshControls();
            _model.NotifyCategoryObserver();
            _model.NotifyMealObserver();
        }

        private void ButtonAddCategoryClick(object sender, EventArgs e)//點擊『新增種類』按鈕時觸發
        {
            _viewModel.ReadTextBoxesAndAddCategory(_textBoxCategoryName, _listBoxAllCategories);
            _viewModel.ClearAllCategoryTextBoxes(_textBoxCategoryName, _listBoxThisCategory);
            RefreshControls();
            _model.NotifyCategoryObserver();
        }

        private void ButtonSaveCategoryClick(object sender, EventArgs e)//點擊『儲存種類』按鈕時觸發
        {
            _viewModel.ReadTextBoxesAndSaveCategory(_listBoxAllCategories, _textBoxCategoryName.Text);

            _viewModel.ClearAllCategoryTextBoxes(_textBoxCategoryName, _listBoxThisCategory);
            _viewModel.ChangeGroupBoxText(_groupBoxCategory, ADD_NEW_CATEGORY);
            RefreshControls();
            _viewModel.LoadCategoryList(_listBoxAllCategories);
            _model.NotifyCategoryObserver();
            _model.NotifyMealObserver();
        }

        private void DetectComboBoxCategoryClick(object sender, EventArgs e)//展開種類ComboBox
        {
            _viewModel.LoadComboBox(_comboBoxCategory);
        }

        //refreshControls
        private void DetectTextBoxMealNameTabIndexChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxMealPriceTabIndexChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxPathTabIndexChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxCategoryNameTabIndexChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectComboBoxCategorySelectedValueChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxMealNameTextChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxMealPriceTextChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxPathTextChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxDescriptionTextChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectTextBoxCategoryNameTextChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectComboBoxCategorySelectedIndexChanged(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void DetectComboBoxCategoryDropDownClosed(object sender, EventArgs e)//觸發refreshControls的事件
        {
            RefreshControls();
        }

        private void ButtonBrowseClick(object sender, EventArgs e)//觸發refreshControls的事件
        {
            OpenFileDialog openImageDialog;
            openImageDialog = new System.Windows.Forms.OpenFileDialog(); 
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())); 
            openImageDialog.InitialDirectory = projectPath + "\\Resources"; 
            openImageDialog.Multiselect = false;
            openImageDialog.Filter = "Image|*.png;*.jpg;*.jpeg"; 
            DialogResult result = openImageDialog.ShowDialog(); 
            if (result == DialogResult.OK) 
            { 
                _textBoxPath.Text = openImageDialog.FileName;
            } 
            else
            {
                MessageBox.Show("Unexpected error. Please try again.");//會跑到
            }

        }
    }
}
