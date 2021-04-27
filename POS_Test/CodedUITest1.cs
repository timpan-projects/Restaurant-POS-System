using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace POSGUITest
{
    /// <summary>
    /// CodedUITest1 的摘要描述
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private const string FILE_PATH = @"Hw1.exe";
        private const string FORM_TITLE = "開啟";
        public CodedUITest1()
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, FORM_TITLE);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }
        //測試formStartUp
        [TestMethod]
        public void TestOpenFront()
        {
            RunScriptOpenFront();
            Robot.AssertWindowExist("formCustomer", true);
            Robot.GetCurrentForm("開啟");
            Robot.AssertButtonEnable("_openBack", true);
            Robot.AssertButtonEnable("_openFront", false);
            Robot.CloseWindow("formCustomer");
            Robot.AssertButtonEnable("_openFront", true);
        }
        [TestMethod]
        public void TestOpenBack()
        {
            RunScriptOpenBack();
            Robot.AssertWindowExist("formEmployee", true);
            Robot.GetCurrentForm("開啟");
            Robot.AssertButtonEnable("_openBack", false);
            Robot.AssertButtonEnable("_openFront", true);
            Robot.CloseWindow("formEmployee");
            Robot.AssertButtonEnable("_openBack", true);
        }
        [TestMethod]
        public void TestClose()
        {
            Robot.ClickButton("離開");
            Robot.AssertWindowExist("開啟", false);
        }
        //測試formCustomer
        [TestMethod]
        public void TestFront()
        {
            RunScriptOpenFront();
            RunScriptFrontActions();
        }
        
        [TestMethod]
        public void TestBackMealPart()
        {
            RunScriptOpenBack();
            RunScriptOpenFront();
            RunScriptBackActionsMealPart();
        }

        [TestMethod]
        public void TestBackCategoryPart()
        {
            RunScriptOpenBack();
            RunScriptOpenFront();
            RunScriptBackActionsCategoryPart();
        }

        [TestMethod]
        public void TestUpdateDataGridView()
        {
            RunScriptOpenBack();
            RunScriptOpenFront();
            Robot.GetCurrentForm("formCustomer");
            Robot.ClickButton("大麥克" + "\n" + "39元");
            Robot.ClickButton("麥香魚" + "\n" + "75元");
            Robot.AssertText("_labelTotal", "總計：114元");
            Robot.GetCurrentForm("formEmployee");
            Robot.ClickListViewByValue("_listBoxAllMeals", "大麥克");
            Robot.ClickButton("_deleteMeal");
            Robot.ClickListViewByValue("_listBoxAllMeals", "麥香魚");
            Robot.SetEdit("_textBoxMealName", "Nigger");
            Keyboard.SendKeys("{Enter}");
            Robot.SetEdit("_textBoxMealPrice", "200");
            Robot.SetComboBox("_comboBoxMealCategory", "甜點");
            Robot.GetCurrentForm("formCustomer");
            Robot.AssertText("_labelTotal", "總計：200元");
        }








        private void RunScriptOpenFront()
        {
            Robot.ClickButton("_openFront");
        }

        private void RunScriptOpenBack()
        {
            Robot.ClickButton("_openBack");
        }

        private void RunScriptFrontActions()
        {
            Robot.GetCurrentForm("formCustomer");
            Robot.AssertText("_labelPage", "第1頁(共3頁)");
            Robot.ClickButton("大麥克" + "\n" + "39元");
            Robot.AssertText("_labelTotal", "總計：39元");
            Robot.ClickButton("大麥克" + "\n" + "39元");
            Robot.AssertText("_labelTotal", "總計：78元");
            Robot.ClickButton("麥香魚" + "\n" + "75元");
            Robot.AssertText("_labelTotal", "總計：153元");
            Robot.ClickButton("_nextPage");
            Robot.AssertText("_labelPage", "第2頁(共3頁)");
            Robot.ClickButton("_nextPage");
            Robot.AssertText("_labelPage", "第3頁(共3頁)");
            Robot.ClickButton("_previousPage");
            Robot.AssertText("_labelPage", "第2頁(共3頁)");
            Robot.ClickButton("測試換頁用12" + "\n" + "120元");
            Robot.AssertText("_labelTotal", "總計：273元");
            Robot.ClickTabControl("甜點");
            Robot.AssertText("_labelPage", "第1頁(共1頁)");
            Robot.ClickButton("冰炫風" + "\n" + "49元");
            Robot.AssertText("_labelTotal", "總計：322元");
            Robot.ClickNumericUpDownButtonInDataGridView("_dataGridViewOrders", 3, 0, Robot.NumericDirect.UP, 1);
            Robot.AssertText("_labelTotal", "總計：273元");
            Robot.ClickButton("冰炫風" + "\n" + "49元");
            Robot.AssertText("_labelTotal", "總計：322元");
            Robot.ClickNumericUpDownButtonInDataGridView("_dataGridViewOrders", 0, 4, Robot.NumericDirect.UP, 1);
            Robot.AssertText("_labelTotal", "總計：361元");
            Robot.ClickNumericUpDownButtonInDataGridView("_dataGridViewOrders", 0, 4, Robot.NumericDirect.DOWN, 2);
            Robot.AssertText("_labelTotal", "總計：283元");
        }

        private void RunScriptBackActionsMealPart()
        {
            Robot.GetCurrentForm("formEmployee");
            //view meals
            Robot.ClickListViewByValue("_listBoxAllMeals", "大麥克");
            Robot.AssertEdit("_textBoxMealName", "大麥克");
            //edit meals
            Robot.SetEdit("_textBoxMealName", "Let's Test!");
            Robot.ClickButton("_saveMeal");
            Robot.ClickListViewByValue("_listBoxAllMeals", "Let's Test!");
            Robot.AssertEdit("_textBoxMealName", "Let's Test!");
            //add meals
            Robot.ClickButton("_addNewMeals");
            Robot.SetEdit("_textBoxMealName", "Let's Add A New Meal!");
            Robot.SetEdit("_textBoxMealPrice", "100");
            Robot.SetComboBox("_comboBoxMealCategory", "漢堡");
            Robot.ClickButton("_browse");
            Keyboard.SendKeys("{.}{p}{.}{p}{n}{g}");
            Keyboard.SendKeys("{Enter}");
            //開圖片
            Robot.GetCurrentForm("formEmployee");
            Robot.SetEdit("_textBoxMealInfo", "Testing Testing Testing");
            Robot.ClickButton("_addMeal");
            //delete meals
            Robot.ClickListViewByValue("_listBoxAllMeals", "Let's Test!");
            Robot.ClickButton("_deleteMeal");
        }
        private void RunScriptBackActionsCategoryPart()
        {
            Robot.GetCurrentForm("formEmployee");
            Robot.ClickTabControl("Category Manager");
            //view categories
            Robot.ClickListViewByValue("_listBoxAllCategories", "漢堡");
            Robot.AssertEdit("_textBoxCategoryName", "漢堡");
            //edit categories
            Robot.SetEdit("_textBoxCategoryName", "Let's Test!");
            Robot.ClickButton("_saveCategory");
            Robot.ClickListViewByValue("_listBoxAllCategories", "Let's Test!");
            Robot.AssertEdit("_textBoxCategoryName", "Let's Test!");
            //add categories
            Robot.ClickButton("_addNewCategory");
            Robot.SetEdit("_textBoxCategoryName", "Testing Category...");
            Robot.ClickButton("_addCategory");
            //delete categories
            Robot.ClickListViewByValue("_listBoxAllCategories", "Let's Test!");
            Robot.ClickButton("_deleteCategory");
            //Robot.AssertListViewByValue("_listBoxAllCategories", "冰炫風")
        }





        #region 其他測試屬性

        // 您可以使用下列其他屬性撰寫測試: 

        ////在每項測試執行前先使用 TestInitialize 執行程式碼 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式碼 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        ////在每項測試執行後使用 TestCleanup 執行程式碼
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式碼 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        #endregion

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
