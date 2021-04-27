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
using DataGridViewNumericUpDownElements;
namespace Hw1
{
    public partial class FormCustomer : Form
    {
        private Model _model;
        private FormCustomerPresentationModel _viewModel;
        private const int INITIAL_POSITION_HORIZONTAL = 25,//第一個按鈕之x座標
                INITIAL_POSITION_PARALLEL = 60,//第一個按鈕之y座標
                INITIAL_CURRENT_PAGE = 1,
                MEAL_BUTTON_WIDTH = 100,//按鈕寬度
                MEAL_BUTTON_HEIGHT = 100,//按鈕高度
                MEAL_BUTTON_AMOUNT = 15;//按鈕數量
        public int _currentPage = INITIAL_CURRENT_PAGE;
        private const int NAME_INDEX = 1;
        private const int CATEGORY_INDEX = 2;
        private const int SINGLE_PRICE_INDEX = 3;
        private const int MEAL_AMOUNT_INDEX = 4;
        private const int SMALL_TOTAL_INDEX = 5;
        public FormCustomer(Model model)
        {
            _model = model;
            _viewModel = new FormCustomerPresentationModel(_model);
            GenerateMealButtons();
            InitializeComponent();
            _viewModel.LoadTabControl(_tabControlMealButtons);
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons, _currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
            SubscribeEvents();
            RefreshMealButtons();
        }
        public void GenerateMealButtons()//產生按鈕
        {
            for (int buttonCounter = 1; buttonCounter <= _model._mealList.Count; buttonCounter++) //動態產生所有『餐點按鈕』
            {
                Button mealbut = new Button();
                Controls.Add(mealbut);
                mealbut.Location = new Point(INITIAL_POSITION_HORIZONTAL, INITIAL_POSITION_PARALLEL);//設定按鈕座標&大小
                mealbut.Width = MEAL_BUTTON_WIDTH;
                mealbut.Height = MEAL_BUTTON_HEIGHT;
                mealbut.Visible = false;
                string projectPath = System.IO.Directory.GetCurrentDirectory();
                mealbut.BackgroundImage = Image.FromFile(projectPath + _model._mealList[buttonCounter - 1]._mealPicturePath);
                mealbut.BackgroundImageLayout = ImageLayout.Stretch;
                _model._mealList[buttonCounter - 1]._button = mealbut;//將meal list的按鈕屬性加入新增按鈕(補齊mealList屬性
                mealbut.Text = _model._mealList[buttonCounter - 1]._mealText + "\n" + _model._mealList[buttonCounter - 1]._mealPrice.ToString() + "元";//設定按鈕上顯示之文字
                mealbut.TextAlign = ContentAlignment.BottomRight;//文字靠右下
                mealbut.Name = _model._mealList[buttonCounter - 1]._mealText;//命名(依照按鈕順序, 按數字命名, 方便呼叫)
                mealbut.Click += ClickEachMealButtons;//每個按鈕觸發不同事件執行的動作
                mealbut.MouseEnter += EnterEachMealButtons;
                mealbut.MouseLeave += LeaveEachMealButtons;
                mealbut.BringToFront();
            }
        }

        public void RefreshMealButtons()//更新餐點按鈕的位置&可見否
        {
            _viewModel.DecideMealButtonsPosition(INITIAL_POSITION_HORIZONTAL, INITIAL_POSITION_PARALLEL, _tabControlMealButtons);
            _viewModel.DecideMealButtonsVisible(_currentPage, _tabControlMealButtons);
        }

        public void RunToUpdateMealChanges()//偵測到meal資料改變時
        {
            DeleteAllMealButtons();
            GenerateMealButtons();
            RefreshMealButtons();
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons ,_currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            UpdateDataGridView();
            _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
        }

        public void RunToUpdateCategoryChanges()//偵測到category資料改變時
        {
            _viewModel.LoadTabControl(_tabControlMealButtons);
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons ,_currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            RefreshMealButtons();
            UpdateDataGridView();
            _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
        }

        public void DeleteAllMealButtons()//刪除所有餐點按鈕
        {
            if (_model._lastDeletedMealButton != null)
            this.Controls.Remove(_model._lastDeletedMealButton);
            for (int i = 0; i < _model._mealList.Count; i++)
            {
                this.Controls.Remove(_model._mealList[i]._button);
            }
        }

        public void ButtonNextPageClick(object sender, EventArgs e)//點擊『下一頁』按鈕觸發的事件
        {
            _currentPage++;
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons, _currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            _viewModel.DecideMealButtonsVisible(_currentPage, _tabControlMealButtons);
            RefreshMealButtons();
        }

        public void ButtonPreviousPageClick(object sender, EventArgs e)//點擊『上一頁』按鈕觸發的事件
        {
            _currentPage--;
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons, _currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            _viewModel.DecideMealButtonsVisible(_currentPage, _tabControlMealButtons);
            RefreshMealButtons();
        }

        private void ClickEachMealButtons(object sender, EventArgs e)//點擊『每個餐點按鈕』觸發的事件
        {
            DataGridViewRowCollection rows = _dataGridViewOrders.Rows;
            Button buttonClicked = sender as Button;
            int counter = 1;
            for (int mealsearcher = 0; mealsearcher < _model._mealList.Count; mealsearcher++)
            {
                if (buttonClicked.Name == _model._mealList[mealsearcher]._mealText)
                    counter = mealsearcher;
            }
            if (_model._mealList[counter]._mealsOrdered == 0)
            {
                _model._mealList[counter]._mealsOrdered = 1;
                    rows.Add(new Object[] { "not important", _model._mealList[counter]._mealText, _model._mealList[counter]._mealCategory, _model._mealList[counter]._mealPrice, _model._mealList[counter]._mealsOrdered, _model._mealList[counter]._mealPrice * _model._mealList[counter]._mealsOrdered });
            }
            else
            {
                _model._mealList[counter]._mealsOrdered ++;
                foreach (DataGridViewRow existingRow in _dataGridViewOrders.Rows)
                {
                    if (existingRow.Cells[1].Value != null)
                    {
                        if (existingRow.Cells[1].Value.ToString() == _model._mealList[counter]._mealText)
                        {
                            existingRow.Cells[MEAL_AMOUNT_INDEX].Value = Convert.ToInt32(existingRow.Cells[MEAL_AMOUNT_INDEX].Value) + 1;
                            existingRow.Cells[SMALL_TOTAL_INDEX].Value = Convert.ToInt32(existingRow.Cells[MEAL_AMOUNT_INDEX].Value) * _model._mealList[counter]._mealPrice;
                        }
                    }
                }
            }
            _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
        }

        private void FormOrderFrontFormClosed(object sender, FormClosedEventArgs e)//關閉視窗時讓start up視窗的按鈕彈起
        {
            FormStartUp newForm = new FormStartUp();
            newForm._buttonCustomer.Enabled = true;
            ClearMealsOrdered();
            _currentPage = 1;
        }

        private void EnterEachMealButtons(object sender, EventArgs e)//滑鼠進入各個餐點按鈕顯示介紹
        {
            Button buttonEntered = sender as Button;
            for (int mealSearcher = 0; mealSearcher < _model._mealList.Count; mealSearcher++)
            {
                if (buttonEntered.Name == _model._mealList[mealSearcher]._mealText)
                    _richTextBoxMeal.Text = _model._mealList[mealSearcher]._mealInfo;
            }
        }

        private void LeaveEachMealButtons(object sender, EventArgs e)//滑鼠離開各個餐點按鈕顯示null
        {
            _richTextBoxMeal.Text = null;
        }

        private void ClickDataGridViewOrdersCellContent(object sender, DataGridViewCellEventArgs e)//"刪除"按鈕
        {
            var existingRow = (DataGridView)sender;
            if (existingRow.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                for (int mealSearcher = 0; mealSearcher < _model._mealList.Count; mealSearcher++)
                {
                    if (existingRow.Rows[e.RowIndex].Cells[1].Value != null && _model._mealList[mealSearcher]._mealText == existingRow.Rows[e.RowIndex].Cells[1].Value.ToString())
                    {
                        _model._mealList[mealSearcher]._mealsOrdered = 0;
                    }
                }
                if (_dataGridViewOrders.Rows[e.RowIndex].Cells[1].Value != null)
                _dataGridViewOrders.Rows.RemoveAt(e.RowIndex);
                _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
            }
        }

        private void ChangeDataGridViewOrdersCellValue(object sender, DataGridViewCellEventArgs e)//上下調整餐點數量
        {
            var existingRow = (DataGridView)sender;
            if (existingRow.Columns[e.ColumnIndex] is DataGridViewNumericUpDownColumn && e.RowIndex >= 0)
            {
                for (int mealSearcher = 0; mealSearcher < _model._mealList.Count; mealSearcher++)
                {
                    if (_dataGridViewOrders.Rows[e.RowIndex].Cells[1].Value != null && _dataGridViewOrders.Rows[e.RowIndex].Cells[1].Value.ToString() == _model._mealList[mealSearcher]._mealText)
                    {
                        _dataGridViewOrders.Rows[e.RowIndex].Cells[SMALL_TOTAL_INDEX].Value = _model._mealList[mealSearcher]._mealPrice * Convert.ToInt32(_dataGridViewOrders.Rows[e.RowIndex].Cells[MEAL_AMOUNT_INDEX].Value);
                        _viewModel.UpdateTotal(_dataGridViewOrders, _labelTotal);
                    }
                }
            }
        }

        private void DetectTabControlMealButtonsSelectedIndexChanged(object sender, EventArgs e)//餐點種類換頁時
        {
            _currentPage = 1;
            _viewModel.UpdatePageTextAndPageButtons(_tabControlMealButtons, _currentPage, _labelPage, _buttonPreviousPage, _buttonNextPage);
            RefreshMealButtons();
        }

        public void ClearMealsOrdered()//餐點mealList裡把點過設為false(0)
        {
            for (int i = 0; i < _model._mealList.Count; i++)
                _model._mealList[i]._mealsOrdered = 0;
        }

        public void SubscribeEvents()//訂閱事件
        {   
            _model._categoryModelChanged += RunToUpdateCategoryChanges;
            _model._mealModelChanged += RunToUpdateMealChanges;
        }

        public void UpdateDataGridView()//更新DGV(尚無法更新名字
        {
            for (int i = 0; i < _dataGridViewOrders.RowCount; i ++)
            {
                bool noMatch = true;
                if (_dataGridViewOrders.Rows[i].Cells[NAME_INDEX].Value != null)
                {   
                    for (int k = 0; k < _model._mealList.Count; k++)
                    {
                        if (_dataGridViewOrders.Rows[i].Cells[NAME_INDEX].Value.ToString() == _model._mealList[k]._mealText)
                        {
                            _dataGridViewOrders.Rows[i].Cells[CATEGORY_INDEX].Value/*種類*/ = _model._mealList[k]._mealCategory;
                            _dataGridViewOrders.Rows[i].Cells[SINGLE_PRICE_INDEX].Value/*單價*/ = _model._mealList[k]._mealPrice;
                            _dataGridViewOrders.Rows[i].Cells[SMALL_TOTAL_INDEX].Value/*小計*/ = Convert.ToInt32(_dataGridViewOrders.Rows[i].Cells[MEAL_AMOUNT_INDEX].Value/*數量*/) * _model._mealList[k]._mealPrice;
                            noMatch = false;
                        }
                    }
                    if (noMatch)
                    {
                        _dataGridViewOrders.Rows.Remove(_dataGridViewOrders.Rows[i]);
                        i--;
                    }
                }
            }
        }
    }
}
