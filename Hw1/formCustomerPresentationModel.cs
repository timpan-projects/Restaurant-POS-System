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
    public class FormCustomerPresentationModel
    {
        private const int SMALL_TOTAL_INDEX = 5;
        private const string TOTAL_CHINESE = "總計：";
        private const string DOLLARS_CHINESE = "元";
        private const int BUTTONS_PER_PAGE = 9;
        private const string PAGE_TEXT_PART1 = "第";
        private const string PAGE_TEXT_PART2 = "頁(共";
        private const string PAGE_TEXT_PART3 = "頁)";
        private const int BUTTONS_PER_ROW = 3;
        private const int INITIAL_POSITION_HORIZONTAL = 25;//第一個按鈕之x座標
        private const int INITIAL_POSITION_PARALLEL = 60;//第一個按鈕之y座標
        private const int MEAL_BUTTON_WIDTH = 100;//按鈕寬度
        private const int MEAL_BUTTON_HEIGHT = 100;//按鈕高度
        private Model _model;
        public FormCustomerPresentationModel(Model model)
        {
            _model = model;
        }
        public void UpdateTotal(DataGridView dataGridViewOrders, Label labelTotal)//計算並更新小計跟總計
        {
            int total = 0;
            for (int rowCounter = 0; rowCounter < dataGridViewOrders.Rows.Count; rowCounter++)
            {
                DataGridViewRow row = dataGridViewOrders.Rows[rowCounter];
                if (row.Cells[1].Value != null)
                    total += (int)row.Cells[SMALL_TOTAL_INDEX].Value;
            }
            labelTotal.Text = TOTAL_CHINESE + total + DOLLARS_CHINESE;
        }

        public void LoadTabControl(TabControl tabControlMealButtons)//從CategoryList讀取名字並一頁一頁新增TabPage
        {
            tabControlMealButtons.TabPages.Clear();
            for (int i = 0; i < _model._categoryList.Count; i++)
            {
                TabPage newTabPage = new TabPage(_model._categoryList[i]._categoryName);
                tabControlMealButtons.TabPages.Add(newTabPage);
            }
        }

        public void UpdatePageTextAndPageButtons(TabControl tabControlMealButtons, int currentPage, Label labelPage, Button buttonPreviousPage, Button buttonNextPage)//顯示『當前頁數』與『總頁數』的文字變化
        {
            int categoryMealAmount = 0;
            for (int i = 0; i < _model._mealList.Count; i++)
            {
                if (tabControlMealButtons.SelectedTab != null && _model._mealList[i]._mealCategory == tabControlMealButtons.SelectedTab.Text)
                    categoryMealAmount++;
            }
            int maxPage = ((categoryMealAmount - 1) / BUTTONS_PER_PAGE) + 1;
            labelPage.Text = PAGE_TEXT_PART1 + currentPage + PAGE_TEXT_PART2 + maxPage + PAGE_TEXT_PART3;
            if (currentPage == 1)
                buttonPreviousPage.Enabled = false;
            else
                buttonPreviousPage.Enabled = true;
            if (currentPage == maxPage)
                buttonNextPage.Enabled = false;
            else
                buttonNextPage.Enabled = true;
        }

        public void DecideMealButtonsPosition(int buttonInitialPositionX, int buttonInitialPositionY, TabControl tabControlMealButtons)//設定各個餐點的位置
        {
            int buttonPositionDetector = 0;
            for (int i = 0; i < _model._mealList.Count; i++)
            {
                if (tabControlMealButtons.SelectedTab != null)
                {
                    if (_model._mealList[i]._mealCategory == tabControlMealButtons.SelectedTab.Text)//if meal.Category == 現在切到的標籤
                    {
                        if (buttonPositionDetector <= BUTTONS_PER_PAGE)
                        {
                            _model._mealList[i]._button.Location = new Point(buttonInitialPositionX, buttonInitialPositionY);
                            buttonPositionDetector++;
                            buttonInitialPositionX += MEAL_BUTTON_WIDTH;
                            //按鈕換行
                            if (buttonPositionDetector % BUTTONS_PER_ROW == 0)
                            {
                                buttonInitialPositionX = INITIAL_POSITION_HORIZONTAL; //初始位置
                                buttonInitialPositionY += MEAL_BUTTON_HEIGHT;
                            }
                            //按鈕換頁
                            if (buttonPositionDetector % BUTTONS_PER_PAGE == 0)
                            {
                                buttonInitialPositionY = INITIAL_POSITION_PARALLEL;
                                buttonPositionDetector = 0;
                            }
                        }
                    }
                }
            }
        }

        public void DecideMealButtonsVisible(int currentPage, TabControl tabControlMealButtons)//設定各個餐點按鈕的可見與否
        {
            int buttonPlaced = 0;
            if (tabControlMealButtons.SelectedTab != null)
            {
                for (int i = 0; i < _model._mealList.Count; i++)
                {
                    if (tabControlMealButtons.SelectedTab.Text == _model._mealList[i]._mealCategory)
                    {
                        if (buttonPlaced >= BUTTONS_PER_PAGE * (currentPage - 1) && buttonPlaced < BUTTONS_PER_PAGE * currentPage)
                        {
                            _model._mealList[i]._button.Visible = true;
                        } 
                        else
                        {
                            _model._mealList[i]._button.Visible = false;
                        }
                        buttonPlaced++;
                    }
                    else
                    {
                        _model._mealList[i]._button.Visible = false;
                    }
                }
            }
        }
    }
}
