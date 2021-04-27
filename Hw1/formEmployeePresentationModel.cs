using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw1
{
    public class FormEmployeePresentationModel
    {
        private const string ADD_NEW_CATEGORY = "Add New Category";
        private const string ADD_NEW_MEAL = "Add New Meal";
        private const string EDIT_CATEGORY = "Edit Category";
        private const string EDIT_MEAL = "Edit Meal";
        private Model _model;
        public FormEmployeePresentationModel(Model model)
        {
            _model = model;
        }
        //通用
        public void LoadMealList(ListBox listBoxAllMeals)//載入MealList
        {
            listBoxAllMeals.Items.Clear();
            for (int i = 0; i < _model._mealList.Count; i++)
            {
                listBoxAllMeals.Items.Add(_model._mealList[i]._mealText);
            }
        }

        public void LoadCategoryList(ListBox listBoxAllCategories)//載入CategoryList
        {
            listBoxAllCategories.Items.Clear();
            for (int i = 0; i < _model._categoryList.Count; i++)
            {
                listBoxAllCategories.Items.Add(_model._categoryList[i]._categoryName);
            }
        }

        public void ChangeGroupBoxText(GroupBox groupBoxName, string desiredText)//改變GroupBox的文字以控制編輯模式
        {
            groupBoxName.Text = desiredText;
        }

        //refreshControls
        public bool EnableButtonAddNewMeal(GroupBox groupBoxMeal)//控制『新增餐點』按鈕是否enable
        {
            if (groupBoxMeal.Text == ADD_NEW_MEAL)
                return false;
            else
                return true;
        }

        public bool EnableButtonDeleteSelectedMeal(ListBox listBoxAllMeals)//控制『刪除餐點』按鈕是否enable
        {
            if (listBoxAllMeals.SelectedItem != null)
                return true;
            else
                return false;
        }

        public bool DecideButtonSaveMealVisible(GroupBox groupBoxMeal)//控制『儲存餐點』按鈕是否visible
        {
            if (groupBoxMeal.Text == EDIT_MEAL)
                return true;
            else
                return false;
        }

        public bool EnableButtonSaveMeal(Button buttonSaveMeal, TextBox textBoxMealName, TextBox textBoxMealPrice, ComboBox comboBoxCategory, TextBox textBoxPath, ListBox listBoxAllMeals)//控制『儲存餐點』按鈕是否enable
        {
            if (buttonSaveMeal.Visible == true && CheckMealEssentialDataInputtedForSaveMeal(textBoxMealName, textBoxMealPrice, comboBoxCategory, textBoxPath, listBoxAllMeals))
                return true;
            else
                return false;
        }

        public bool DecideButtonAddMealVisible(GroupBox groupBoxMeal)//控制『新增餐點』按鈕是否visible
        {
            if (groupBoxMeal.Text == ADD_NEW_MEAL)
                return true;
            else
                return false;
        }

        public bool EnableButtonAddMeal(Button buttonAddMeal, TextBox textBoxMealName, TextBox textBoxMealPrice, ComboBox comboBoxCategory, TextBox textBoxPath, ListBox listBoxAllMeals)//控制『新增餐點』按鈕是否enable
        {
            if (buttonAddMeal.Visible == true && CheckMealEssentialDataInputtedForAddMeal(listBoxAllMeals, textBoxMealName, textBoxMealPrice, comboBoxCategory, textBoxPath))
                return true;
            else
                return false;
        }

        public bool EnableButtonAddNewCategory(GroupBox groupBoxCategory)//控制『新增種類』按鈕是否enable
        {
            if (groupBoxCategory.Text == ADD_NEW_CATEGORY)
                return false;
            else
                return true;
        }

        public bool EnableButtonDeleteSelectedCategory(ListBox listBoxAllCategories, ListBox listBoxThisCategory)//控制『刪除種類』按鈕是否enable
        {
            if (listBoxAllCategories.SelectedItem != null)
                return true;
            else
                return false;
        }

        public bool DecideButtonSaveCategoryVisible(GroupBox groupBoxCategory)//控制『儲存種類』按鈕是否visible
        {
            if (groupBoxCategory.Text == EDIT_CATEGORY)
                return true;
            else
                return false;
        }

        public bool EnableButtonSaveCategory(Button buttonSaveCategory, TextBox textBoxCategoryName, ListBox listBoxAllCategories)//控制『儲存種類』按鈕是否enable
        {
            if (buttonSaveCategory.Visible == true && CheckCategoryEssentialDataInputtedForSaveCategory(listBoxAllCategories,textBoxCategoryName.Text))
                return true;
            else
                return false;
        }

        public bool DecideButtonAddCategoryVisible(GroupBox groupBoxCategory)//控制『新增種類』按鈕是否visible
        {
            if (groupBoxCategory.Text == ADD_NEW_CATEGORY)
                return true;
            else
                return false;
        }

        public bool EnableButtonAddCategory(Button buttonAddCategory, TextBox textBoxCategoryName, ListBox listBoxAllCategories)//控制『新增種類』按鈕是否enable
        {
            if (buttonAddCategory.Visible == true && CheckCategoryEssentialDataInputtedForAddCategory(listBoxAllCategories, textBoxCategoryName.Text))
                return true;
            else
                return false;
        }

        //Meal
        public int SearchSelectedMealID(string selectedItem)//未選擇時回傳-1
        {
            int mealID = -1;
            if (selectedItem != null)
            {
                for (int i = 0; i < _model._mealList.Count; i++)
                {
                    if (_model._mealList[i]._mealText == selectedItem)
                        mealID = _model._mealList.FindIndex(item => item._mealText == _model._mealList[i]._mealText) + 1;
                }
            }
            return (mealID);
        }

        public void ShowMealData(int mealID, TextBox mealName, TextBox mealPrice, ComboBox category, TextBox path, TextBox description)//顯示餐點資料
        {
            if (mealID >= 0)
            {
                mealName.Text = _model._mealList[mealID - 1]._mealText.ToString();
                mealPrice.Text = _model._mealList[mealID - 1]._mealPrice.ToString();
                category.Text = _model._mealList[mealID - 1]._mealCategory.ToString();
                if (_model._mealList[mealID - 1]._mealPicturePath != null)
                    path.Text = _model._mealList[mealID - 1]._mealPicturePath.ToString();
                else
                    path.Text = _model._mealList[mealID - 1]._mealWholePath.ToString();
                description.Text = _model._mealList[mealID - 1]._mealInfo.ToString();
            }
            else
                ClearAllMealTextBoxes(mealName, mealPrice, category, path, description);
        }

        public string ChangeSelectedItemToString(ListBox listBoxAllMeals)//如果selectedItem = null會出錯
        {
            if (listBoxAllMeals.SelectedItem != null)
                return (listBoxAllMeals.SelectedItem.ToString());
            else
                return (null);
        }

        public bool CheckMealEssentialDataInputtedForAddMeal(ListBox listBoxAllMeals, TextBox textBoxMealName, TextBox textBoxMealPrice, ComboBox comboBoxCategory, TextBox textBoxPath)//檢查輸入的餐點資料是否符合條件
        {
            int testNumber;
            if (listBoxAllMeals.Items.IndexOf(textBoxMealName.Text) == -1/*沒有重複名稱*/ && int.TryParse(textBoxMealPrice.Text, out testNumber))//textBoxMealPrice屬性是數字
                    return (textBoxMealName.Text != "" && textBoxMealPrice.Text != "" && comboBoxCategory.Text != "" && textBoxPath.Text != "");
            else
                return false;
        }

        public bool CheckMealEssentialDataInputtedForSaveMeal(TextBox textBoxMealName, TextBox textBoxMealPrice, ComboBox comboBoxCategory, TextBox textBoxPath, ListBox listBoxAllMeals)//編輯餐點模式下，檢查輸入的餐點資料是否符合條件
        {
            int testNumber;
            if (listBoxAllMeals.SelectedItem != null)
            {
                if (int.TryParse(textBoxMealPrice.Text, out testNumber) && ((listBoxAllMeals.Items.IndexOf(textBoxMealName.Text) == -1) || (textBoxMealName.Text == listBoxAllMeals.SelectedItem.ToString())))//textBoxMealPrice屬性是數字
                    return (textBoxMealName.Text != "" && textBoxMealPrice.Text != "" && comboBoxCategory.Text != "" && textBoxPath.Text != "");
                else
                    return false;
            }
            else
                return false;
        }

        public void DeleteSelectedMeal(ListBox listBoxAllMeals)//刪除選擇的餐點
        {
            //_model._mealList[SearchSelectedMealID(listBoxAllMeals.SelectedItem.ToString()) - 1]._button.Visible = false;
            _model._lastDeletedMealButton = _model._mealList[SearchSelectedMealID(listBoxAllMeals.SelectedItem.ToString()) - 1]._button;
            _model._mealList.RemoveAt(SearchSelectedMealID(listBoxAllMeals.SelectedItem.ToString()) - 1);
        }

        public void ReadTextBoxesAndSaveMeal(ListBox listBoxAllMeals, string textBoxMealNameText, string textBoxMealPriceText, string comboBoxCategoryText, string textBoxPathText, string textBoxDescriptionText)//讀取各個textbox數據並儲存餐點
        {
            int mealID = SearchSelectedMealID(listBoxAllMeals.SelectedItem.ToString()) - 1;
            _model._mealList[mealID]._mealText = textBoxMealNameText;
            _model._mealList[mealID]._mealPrice = Convert.ToInt32(textBoxMealPriceText);
            _model._mealList[mealID]._mealCategory = comboBoxCategoryText;
            if (_model._mealList[mealID]._mealPicturePath != textBoxPathText)
            {
                _model._mealList[mealID]._mealPicturePath = textBoxPathText.Remove(0, _model._projectPath.Length); 
            }
            _model._mealList[mealID]._mealInfo = textBoxDescriptionText;
        }

        public void ClearAllMealTextBoxes(TextBox textBoxMealName, TextBox textBoxMealPrice, ComboBox comboBoxCategory, TextBox textBoxPath, TextBox textBoxDescription)//清空餐點textbox
        {
            textBoxMealName.Text = "";
            textBoxMealPrice.Text = "";
            comboBoxCategory.Text = "";
            textBoxPath.Text = "";
            textBoxDescription.Text = "";
        }

        public void ReadTextBoxesAndAddMeal(ListBox listBoxAllMeals, string textBoxMealNameText, string textBoxMealPriceText, string comboBoxCategoryText, string textBoxPathText, string textBoxDescriptionText)//讀取各個textbox數據並新增餐點
        {   
            _model._mealList.Add(new Meal.Meals()
            {
                _mealText = textBoxMealNameText,
                _mealCategory = comboBoxCategoryText,
                _mealPrice = Convert.ToInt32(textBoxMealPriceText),
                _mealsOrdered = 0,
                _mealPicturePath = textBoxPathText.Remove(0, _model._projectPath.Length),
                _mealInfo = textBoxDescriptionText
            });
            listBoxAllMeals.Items.Add(textBoxMealNameText);
        }

        public void LoadComboBox(ComboBox comboBoxCategory)//依據CategoryList讀取ComboBox
        {
            comboBoxCategory.Items.Clear();
            for (int i = 0; i < _model._categoryList.Count; i++)
            {
                comboBoxCategory.Items.Add(_model._categoryList[i]._categoryName);
            }
        }

        //Category
        public bool CheckCategoryEmptied(ListBox listBoxThisCategory)//檢查此Category下是否還有任何參點
        {
            return (listBoxThisCategory.Items.Count == 0);
        }

        public bool CheckCategoryEssentialDataInputtedForSaveCategory(ListBox listBoxAllCategories, string textBoxCategoryNameText)//檢查輸入的種類資料是否符合條件
        {
            if (listBoxAllCategories.SelectedItem != null)
            {
                if ((listBoxAllCategories.Items.IndexOf(textBoxCategoryNameText) == -1) || (textBoxCategoryNameText == listBoxAllCategories.SelectedItem.ToString()))
                    return (textBoxCategoryNameText != "");
                else
                    return false;
            }
            else
                return false;
        }

        public bool CheckCategoryEssentialDataInputtedForAddCategory(ListBox listBoxAllCategories, string textBoxCategoryNameText)//編輯種類模式下，檢查輸入的種類資料是否符合條件
        {
            if (listBoxAllCategories.Items.IndexOf(textBoxCategoryNameText) == -1)
                return (textBoxCategoryNameText != "");
            else
                return false;
        }

        public void ClearAllCategoryTextBoxes(TextBox textBoxCategoryName, ListBox listBoxThisCategory)//清空種類textbox
        {
            textBoxCategoryName.Text = null;
            listBoxThisCategory.Items.Clear();
        }

        public void ShowCategoryData(ListBox listBoxAllCategories, TextBox textBoxCategoryName, ListBox listBoxThisCategory)//顯示種類相關資料
        {
            if (listBoxAllCategories.SelectedItem != null)
            {
                textBoxCategoryName.Text = listBoxAllCategories.SelectedItem.ToString();
                for (int i = 0; i < _model._mealList.Count; i++)
                {
                    if (_model._mealList[i]._mealCategory == listBoxAllCategories.SelectedItem.ToString())
                        listBoxThisCategory.Items.Add(_model._mealList[i]._mealText);
                }
            }
        }

        public void ReadTextBoxesAndSaveCategory(ListBox listBoxAllCategories, string textBoxCategoryNameText)//讀取各個textbox並儲存category
        {
            int categoryID = SearchSelectedCategoryID(listBoxAllCategories.SelectedItem.ToString()) - 1;
            _model._categoryList[categoryID]._categoryName = textBoxCategoryNameText;
            for (int i = 0; i < _model._mealList.Count; i++)
            {
                if (_model._mealList[i]._mealCategory == listBoxAllCategories.SelectedItem.ToString())
                {
                    _model._mealList[i]._mealCategory = textBoxCategoryNameText;
                }
            }
        }

        public void ReadTextBoxesAndAddCategory(TextBox textBoxCategoryName, ListBox listBoxAllCategories)//讀取各個textbox並新增category
        {
            listBoxAllCategories.Items.Add(textBoxCategoryName.Text);
            _model._categoryList.Add(new Category.Categories()
            {
                _categoryName = textBoxCategoryName.Text
            });
        }

        public void DeleteSelectedEmptyCategory(ListBox listBoxAllCategories, ListBox listBoxThisCategory, TextBox textBoxCategoryName, GroupBox groupBoxCategory)//刪除category
        {
            if (CheckCategoryEmptied(listBoxThisCategory))
            {
                _model._categoryList.RemoveAt(SearchSelectedCategoryID(listBoxAllCategories.SelectedItem.ToString()) - 1);
                listBoxAllCategories.ClearSelected();
                LoadCategoryList(listBoxAllCategories);
                ClearAllCategoryTextBoxes(textBoxCategoryName, listBoxThisCategory);
                ChangeGroupBoxText(groupBoxCategory, ADD_NEW_CATEGORY);
            }
            else
            {
                for (int i = 0; i < listBoxThisCategory.Items.Count; i++)
                {
                    _model._mealList[SearchSelectedMealID(listBoxThisCategory.Items[i].ToString()) - 1]._button.Visible = false;
                    _model._lastDeletedMealButton = _model._mealList[SearchSelectedMealID(listBoxThisCategory.Items[i].ToString()) - 1]._button;
                    _model._mealList.RemoveAt(SearchSelectedMealID(listBoxThisCategory.Items[i].ToString()) - 1);
                    
                }
                _model._categoryList.RemoveAt(SearchSelectedCategoryID(listBoxAllCategories.SelectedItem.ToString()) - 1);
                listBoxAllCategories.ClearSelected();
                LoadCategoryList(listBoxAllCategories);
                ClearAllCategoryTextBoxes(textBoxCategoryName, listBoxThisCategory);
                ChangeGroupBoxText(groupBoxCategory, ADD_NEW_CATEGORY);
            }
        }

        public int SearchSelectedCategoryID(string selectedItem)//搜尋選取的category在CategoryList內的ID
        {
            int categoryID = -1;
            if (selectedItem != null)
            {
                for (int i = 0; i < _model._categoryList.Count; i++)
                {
                    if (_model._categoryList[i]._categoryName == selectedItem)
                        categoryID = _model._categoryList.FindIndex(item => item._categoryName == _model._categoryList[i]._categoryName) + 1;
                }
            }
            return (categoryID);
        }
    }
}