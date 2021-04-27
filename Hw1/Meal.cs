using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace Hw1
{
    public class Meal
    {
        public List<Meals> _mealList;
        public class Meals//meals的屬性
        {
            public string _mealText;//文字
            public int _mealPrice;//單價
            public Button _button;//按鈕
            public int _mealsOrdered;//點過
            public string _mealPicturePath;//圖片路徑
            public string _mealWholePath;
            public string _mealInfo;//介紹文字
            public string _mealCategory;//餐點種類
            
        }
    }
}
