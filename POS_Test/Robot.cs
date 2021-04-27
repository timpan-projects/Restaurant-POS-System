﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace POSGUITest
{
    public class Robot
    {
        private static Dictionary<string, UITestControl> _cache;
        private static ApplicationUnderTest _aut;
        private static UITestControl _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string MSAA_TECHNOLOGY = "MSAA";

        public enum NumericDirect
        {
            UP,
            DOWN
        }

        public static void SetDelayBetweenActions(int millisecond)
        {
            Playback.PlaybackSettings.DelayBetweenActions = millisecond;
        }

        public static UITestControl Initialize(string path, string title)
        {
            Playback.PlaybackSettings.DelayBetweenActions = 0;
            Playback.PlaybackSettings.ThinkTimeMultiplier = 0.0d;
            Playback.PlaybackSettings.SkipSetPropertyVerification = true;
            Playback.PlaybackSettings.ShouldSearchFailFast = true;
            _aut = ApplicationUnderTest.Launch(path);

            _cache = new Dictionary<string, UITestControl>();
            WinWindow window = new WinWindow();
            window.SearchProperties.Add(WinWindow.PropertyNames.Name, title);
            CacheComponentFound(window, title);
            _root = window;
            return _root;
        }

        public static void GetCurrentForm(string title)
        {
            _cache = new Dictionary<string, UITestControl>();
            WinWindow window = new WinWindow();
            window.SearchProperties.Add(WinWindow.PropertyNames.Name, title);
            CacheComponentFound(window, title);
            _root = window;
        }
        public static void CleanUp()
        {
            _cache.Clear();
            _root = null;
            _aut.Close();
        }

        private static WinControl FindWinControl(Type type, string name, UITestControl parent)
        {
            if (_cache.ContainsKey(name))
            {
                return (WinControl)_cache[name];
            }
            else
            {
                WinControl control = (WinControl)Activator.CreateInstance(type, new Object[] { parent });
                control.SearchProperties.Add(WinControl.PropertyNames.Name, name);
                CacheComponentFound(control, name);
                return control;
            }
        }

        private static void CacheComponentFound(UITestControl control, string name)
        {
            control.Find();
            if (!control.Exists)
            {
                throw new Exception(CONTROL_NOT_FOUND_EXCEPTION);
            }
            _cache.Add(name, control);
        }

        public static void ClickMenuItem(string[] path)
        {
            foreach (string item in path)
            {
                Mouse.Click((WinMenuItem)Robot.FindWinControl(typeof(WinMenuItem), item, _root));
            }
        }

        public static void ClickDateTimePicker(string[] data)
        {
            WinDateTimePicker dateTimePicker = (WinDateTimePicker)Robot.FindWinControl(typeof(WinDateTimePicker), data[0], _root);
            dateTimePicker.SetProperty("DateTime", data[1] + "/" + data[2] + "/" + data[3]);
        }

        public static void ClickButton(string name)
        {
            WinButton button = (WinButton)Robot.FindWinControl(typeof(WinButton), name, _root);
            Mouse.Click(button);
        }

        public static void ClickLabel(string name)
        {
            WinText label = (WinText)Robot.FindWinControl(typeof(WinText), name, _root);
            Mouse.Click(label);
        }

        public static void ClickTabControl(string name)
        {
            Mouse.Click((WinTabPage)Robot.FindWinControl(typeof(WinTabPage), name, _root));
        }

        public static void KeyIntoTextBox(string someText, string name)
        {
            Mouse.Click((WinText)Robot.FindWinControl(typeof(WinText), name, _root));
            Keyboard.SendKeys(someText);
        }

        public static void SetEdit(string name, string keys)
        {
            WinEdit edit = (WinEdit)Robot.FindWinControl(typeof(WinEdit), name, _root);
            if (edit.Text != keys)
                edit.Text = keys;
        }


        public static void AssertOtherFormEdit(string formName, string editName, string assertValue)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = formName;
            window.WindowTitles.Add(formName);
            WinEdit edit = new WinEdit(window);
            edit.SearchProperties[WinWindow.PropertyNames.Name] = editName;
            Assert.AreEqual(edit.Text, assertValue);
        }

        public static void SetOtherFormEdit(string formName, string editName, string keys)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = formName;
            window.WindowTitles.Add(formName);
            WinEdit edit = new WinEdit(window);
            edit.SearchProperties[WinWindow.PropertyNames.Name] = editName;
            if (edit.Text != keys)
                edit.Text = keys;
        }

        public static void ClickOtherFormButton(string formName, string buttonName)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = formName;
            window.WindowTitles.Add(formName);
            WinButton button = new WinButton(window);
            button.SearchProperties[WinWindow.PropertyNames.Name] = buttonName;
            Mouse.Click(button);
        }

        public static void CloseWindow(string name)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = name;
            window.WindowTitles.Add(name);
            WinTitleBar bar = new WinTitleBar(window);
            WinButton button = new WinButton(bar);
            button.SearchProperties[WinButton.PropertyNames.Name] = "關閉";
            Mouse.Click(button);
        }

        public static void AssertOtherFormButtonEnable(string formName, string buttonName, bool assertValue)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = formName;
            window.WindowTitles.Add(formName);
            WinButton button = new WinButton(window);
            button.SearchProperties[WinWindow.PropertyNames.Name] = buttonName;
            Assert.AreEqual(button.Enabled, assertValue);
        }

        public static void DeleteDataGridViewByIndex(string[] data)
        {
            WinTable table = (WinTable)Robot.FindWinControl(typeof(WinTable), data[0], _root);
            WinRow row = new WinRow(table);
            if (data[3] == string.Empty)
            {
                Mouse.Click(table, System.Windows.Forms.MouseButtons.Right);
            }
            else
            {
                row.SearchProperties.Add(WinRow.PropertyNames.RowIndex, data[3]);
                row.Find();
                UITestControlCollection collection = row.GetChildren();
                Mouse.Click(collection[0]);
                Mouse.Click(collection[0], System.Windows.Forms.MouseButtons.Right);
            }
            WinWindow window = new WinWindow();
            WinMenu menu = new WinMenu(window);
            menu.SearchProperties[WinMenu.PropertyNames.Name] = data[1];
            WinMenuItem item = new WinMenuItem(menu);
            item.SearchProperties[WinMenuItem.PropertyNames.Name] = data[2];
            Mouse.Click(item);
        }

        public static void ClickListViewByValue(string name, string data)
        {
            /*WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = name;
            WinList list = new WinList(window);
            list.WindowTitles.Add("Task Type");*/
            WinList list = (WinList)Robot.FindWinControl(typeof(WinList), name, _root);
            if (data == string.Empty)
            {
                Mouse.Click(list);
            }
            else
            {
                list.SelectedItemsAsString = data;
            }
        }

        public static void ClickListViewToEmpty(string name, string data)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = name;
            window.WindowTitles.Add("Task Type");
            WinList list = new WinList(window);
            list.SelectedItemsAsString = null;
        }

        public static void SetNumericUpDown(string name, string keys)
        {
            WinComboBox spinner = (WinComboBox)Robot.FindWinControl(typeof(WinComboBox), name, _root);
            if (spinner.SelectedItem != keys)
                spinner.SelectedItem = keys;
        }

        public static void SetComboBox(string name, string targetName)
        {
            WinComboBox comboBox = (WinComboBox)Robot.FindWinControl(typeof(WinComboBox), name, _root);
            if (comboBox.SelectedItem != targetName)
                comboBox.SelectedItem = targetName;
        }

        public static void SetCheckBox(string name, bool isChecked)
        {
            WinCheckBox checkBox = (WinCheckBox)Robot.FindWinControl(typeof(WinCheckBox), name, _root);
            if (checkBox.Checked != isChecked)
                checkBox.Checked = isChecked;
        }

        public static void AssertEdit(string name, string assertValue)
        {
            WinEdit edit = (WinEdit)Robot.FindWinControl(typeof(WinEdit), name, _root);
            Assert.AreEqual(edit.Text, assertValue);
        }

        public static void AssertText(string name, string assertValue)
        {
            WinText edit = (WinText)Robot.FindWinControl(typeof(WinText), name, _root);
            Assert.AreEqual(edit.DisplayText, assertValue);
        }

        public static void AssertCheckBox(string name, bool isChecked)
        {
            WinCheckBox checkBox = (WinCheckBox)Robot.FindWinControl(typeof(WinCheckBox), name, _root);
            Assert.AreEqual(checkBox.Checked, isChecked);
        }
        public static void AssertNumericUpDown(string name, string keys)
        {
            WinComboBox spinner = (WinComboBox)Robot.FindWinControl(typeof(WinComboBox), name, _root);
            Assert.AreEqual(spinner.SelectedItem, keys);
        }
        public static void AssertDateTimePicker(string[] data)
        {
            WinDateTimePicker dateTimePicker = (WinDateTimePicker)Robot.FindWinControl(typeof(WinDateTimePicker), data[0], _root);
            Assert.AreEqual(dateTimePicker.DateTime.Year, int.Parse(data[1]));
            Assert.AreEqual(dateTimePicker.DateTime.Month, int.Parse(data[2]));
            Assert.AreEqual(dateTimePicker.DateTime.Day, int.Parse(data[3]));
        }
        public static void AssertComboBox(string name, string assertValue)
        {
            WinComboBox comboBox = (WinComboBox)Robot.FindWinControl(typeof(WinComboBox), name, _root);
            Assert.AreEqual(comboBox.SelectedItem, assertValue);
        }

        public static void AssertListViewByValue(string name, string[] data)
        {
            WinWindow window = new WinWindow();
            window.SearchProperties[WinWindow.PropertyNames.Name] = name;
            WinList list = new WinList(window);
            list.WindowTitles.Add("Task Type");
            UITestControlCollection collection = list.Items;
            for (int i = 0; i < collection.Count; i++)
            {
                Assert.AreEqual(data[i], collection[i].Name);
            }
        }

        public static void AssertDataGridViewByIndex(string name, string index, string[] data)
        {
            WinTable table = (WinTable)Robot.FindWinControl(typeof(WinTable), name, _root);
            WinRow _Winrow = new WinRow(table);
            _Winrow.SearchProperties.Add(WinRow.PropertyNames.RowIndex, index);
            _Winrow.Find();
            UITestControlCollection collection = _Winrow.GetChildren();
            for (int i = 0; i < collection.Count; i++)
            {
                WinCell cell = collection[i] as WinCell;
                Assert.AreEqual(data[i], cell.Value);
            }
        }

        public static void AssertDataItemsInDataGridView(string name, int items)
        {
            WinTable table = (WinTable)Robot.FindWinControl(typeof(WinTable), name, _root);
            Assert.AreEqual(table.Rows.Count, items);
        }

        public static void AssertButtonEnable(string name, bool state)
        {
            WinButton button = (WinButton)Robot.FindWinControl(typeof(WinButton), name, _root);
            Assert.AreEqual(button.Enabled, state);
        }

        public static void AssertWindow(string name)
        {
            const string KEY_TEXT = "\n";
            WinWindow window = (WinWindow)Robot.FindWinControl(typeof(WinWindow), name, null);
            Keyboard.SendKeys(window, KEY_TEXT);
        }

        /// <summary>
        /// 判斷視窗是否存在
        /// </summary>
        /// <param name="name">Form的AccessibleName</param>
        /// <param name="isExist">存在與否</param>
        public static void AssertWindowExist(string name, bool isExist)
        {
            WinWindow form = (WinWindow)Robot.FindWinControl(typeof(WinWindow), name, null);
            int count = form.FindMatchingControls().Count;
            if (isExist)
            {
                Assert.IsTrue(count > 0);
            }
            else
            {
                Assert.AreEqual(0, count);
            }
        }

        /// <summary>
        /// 在ColorDialog顯示的情況下選取指定的顏色
        /// </summary>
        /// <param name="x">X軸的座標，以0開始</param>
        /// <param name="y">Y軸的座標，以0開始</param>
        public static void ClickColorDialogColor(int x, int y)
        {
            ResetColorDialogPosition();
            for (int i = 0; i++ < y; )
                Keyboard.SendKeys("{Down}");
            for (int i = 0; i++ < x; )
                Keyboard.SendKeys("{Right}");
            Keyboard.SendKeys("{Space}");
        }

        /// <summary>
        /// 在ColorDialog顯示的情況下回到回到左上角的顏色，作為定位的用途
        /// </summary>
        private static void ResetColorDialogPosition()
        {
            for (int i = 0; i++ < 5; )
                Keyboard.SendKeys("{Up}");
            for (int i = 0; i++ < 7; )
                Keyboard.SendKeys("{Left}");
        }

        /// <summary>
        /// 在ColorDialog顯示的情況下點擊確定
        /// </summary>
        public static void ClickColorDialogOk()
        {
            WinWindow colorDialog = (WinWindow)Robot.FindWinControl(typeof(WinWindow), "色彩", null);
            colorDialog.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            WinWindow okWindow = new WinWindow(colorDialog);
            okWindow.SearchProperties[WinWindow.PropertyNames.ControlId] = "1";
            WinButton okButton = (WinButton)Robot.FindWinControl(typeof(WinButton), "確定", okWindow);
            Mouse.Click(okButton);
        }

        /// <summary>
        /// 測試表單左上角的顏色
        /// </summary>
        /// <param name="name">表單的AccessibleName</param>
        /// <param name="color">待測試的顏色</param>
        public static void AssertFormBackColor(string name, Color color)
        {
            WinWindow winForm = new WinWindow();
            winForm.SearchProperties[WinWindow.PropertyNames.Name] = name;
            WinClient winClient = new WinClient(winForm);
            winClient.SearchProperties[WinControl.PropertyNames.Name] = name;
            Image image = winClient.CaptureImage();
            Bitmap bitmap = new Bitmap(image);
            Assert.AreEqual(color.ToArgb(), bitmap.GetPixel(0, 0).ToArgb());
        }

        /// <summary>
        /// Assert DataGridView所選Cell顯示的顏色(請勿讓Cell反白，否則可能會錯誤)
        /// </summary>
        /// <param name="dataGridViewName">DataGridView的AccessibleName</param>
        /// <param name="rowIndex">Row的Index，以0開始</param>
        /// <param name="columnIndex">Column的Index，以0開始</param>
        /// <param name="color">待測顏色</param>
        public static void AssertCellColor(string dataGridViewName, int rowIndex, int columnIndex, Color color)
        {
            WinTable table = (WinTable)Robot.FindWinControl(typeof(WinTable), dataGridViewName, _root);
            WinRow row = (WinRow)table.Rows[rowIndex];
            WinCell cell = (WinCell)row.Cells[columnIndex];
            Image image = cell.CaptureImage();
            Bitmap bitmap = new Bitmap(image);
            Color pixelColor = bitmap.GetPixel(image.Width / 2, image.Height / 2);
            Assert.AreEqual(pixelColor.ToArgb(), color.ToArgb());
        }

        /// <summary>
        /// 檢測Label的顏色是否正確
        /// </summary>
        /// <param name="labelName">標籤的AccessibleName</param>
        /// <param name="color">待測顏色</param>
        public static void AssertLabelColor(string labelName, Color color)
        {
            WinText label = (WinText)Robot.FindWinControl(typeof(WinText), labelName, _root);
            Bitmap bitmap = new Bitmap(label.CaptureImage());
            Assert.AreEqual(color.ToArgb(), bitmap.GetPixel(0, 0).ToArgb());
        }

        /// <summary>
        /// 尋找DataGridView 裡的NumericUpDown Cell控制項
        /// </summary>
        /// <param name="dataGridViewName">DatGridView的AccessibleName</param>
        /// <param name="rowIndex">Row的Index，從0開始</param>
        /// <param name="columnIndex">Column的Index，從0開始</param>
        /// <param name="direct">欲按的NumericUpDown的增加或減少鍵(增加=NumericDirect.UP,減少=NumericDirect.DOWN)(</param>
        public static void ClickNumericUpDownButtonInDataGridView(string dataGridViewName, int rowIndex, int columnIndex, NumericDirect direct, int times)
        {
            const int HALF_BUTTON_WIDTH = 8;
            const int SPINBUTTON_HEIGHT_FINE_TUNE = 3;

            //Win window
            WinWindow sec = Robot.FindWinControl(typeof(WinWindow),"customerForm",null) as WinWindow;
            //

            WinTable table = Robot.FindWinControl(typeof(WinTable), dataGridViewName, sec) as WinTable;
            WinRow row = table.Rows[rowIndex] as WinRow;
            WinCell cell = row.Cells[columnIndex] as WinCell;
            Rectangle boundingRectangle = cell.BoundingRectangle;
            int halfHeightOfCell = cell.BoundingRectangle.Height / 2;
            int upperPartYOffset = halfHeightOfCell - SPINBUTTON_HEIGHT_FINE_TUNE;
            int lowerPartYOffset = halfHeightOfCell + SPINBUTTON_HEIGHT_FINE_TUNE;

            switch (direct)
            {
                case NumericDirect.UP:
                    Mouse.Click(new Point(boundingRectangle.X + boundingRectangle.Width - HALF_BUTTON_WIDTH, boundingRectangle.Y + upperPartYOffset));
                    break;
                case NumericDirect.DOWN:
                    Mouse.Click(new Point(boundingRectangle.X + boundingRectangle.Width - HALF_BUTTON_WIDTH, boundingRectangle.Y + lowerPartYOffset));
                    break;
            }

            for (int i = 0; i < times + 1; i++)
                Mouse.Click();
            Keyboard.SendKeys("{Enter}");
        }

        /// <summary>
        /// 測試一DataGridView裡的NumericUpDown Cell的值
        /// </summary>
        /// <param name="dataGridViewName">DataGridView 的 AccesibleName</param>
        /// <param name="rowIndex">NumericUpDown cell所在的row index </param>
        /// <param name="columnIndex">NumericUpDown cell 所在的 column index</param>
        /// <param name="value">欲測值</param>
        public static void AssertDataGridViewNumericUpDownCellValue(string dataGridViewName, int rowIndex, int columnIndex, int value)
        {
            WinTable table = Robot.FindWinControl(typeof(WinTable), dataGridViewName, _root) as WinTable;
            WinRow row = table.Rows[rowIndex] as WinRow;
            WinCell cell = row.Cells[columnIndex] as WinCell;
            Assert.AreEqual(cell.Value, value.ToString());
        }
    }
}
