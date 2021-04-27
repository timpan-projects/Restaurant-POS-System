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
    public class Model
    {   
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _mealModelChanged;
        public event ModelChangedEventHandler _categoryModelChanged;
        public List<Meal.Meals> _mealList = new List<Meal.Meals>();
        public List<Category.Categories> _categoryList = new List<Category.Categories>();
        public Button _lastDeletedMealButton;
        public string _projectPath = System.IO.Directory.GetCurrentDirectory();
        private const string HAMBURGER = "漢堡";
        private const string SIDE_DISH = "副餐";
        private const string DESSERT = "甜點";
        private const string BREAKFAST = "早餐";
        private const string PATH1 = "/Resources/1.png";
        private const string PATH2 = "/Resources/2.png";
        private const string PATH3 = "/Resources/3.png";
        private const string PATH4 = "/Resources/4.png";
        private const string PATH5 = "/Resources/5.png";
        private const string PATH6 = "/Resources/6.png";
        private const string PATH7 = "/Resources/7.png";
        private const string PATH8 = "/Resources/8.png";
        private const string PATH9 = "/Resources/9.png";
        private const string PATH10 = "/Resources/10.png";
        private const string PATH11 = "/Resources/11.png";
        private const string PATH12 = "/Resources/12.png";
        private const string PATH13 = "/Resources/13.png";
        private const string PATH14 = "/Resources/14.png";
        private const string PATH15 = "/Resources/15.png";
        private const string PATH16 = "/Resources/16.png";
        private const string PATH17 = "/Resources/17.png";
        private const string PATH18 = "/Resources/18.png";
        private const string PATH19 = "/Resources/19.png";
        private const string PATH20 = "/Resources/20.png";
        private const string PATH21 = "/Resources/21.png";
        private const string PATH22 = "/Resources/22.png";
        private const string PATH23 = "/Resources/23.png";
        private const string PATH24 = "/Resources/24.png";
        private const string PATH25 = "/Resources/25.png";
        private const string PATH_DUMMY = "/Resources/dummy.png";
        private const string MEAL1 = "大麥克";
        private const string INFO1 = "A double layer of sear-sizzled 100% pure beef mingled with special sauce on a sesame seed bun and topped with melty American cheese, crisp lettuce, minced onions and tangy pickles.";
        private const string MEAL2 = "4盎司牛肉堡";
        private const string INFO2 = "A quarter pound* of 100% pure beef, seared to be thicker and juicier, plus a pinch of salt and pepper. Layered with two slices of melty cheese, slivered onions and tangy pickles on a sesame seed bun.";
        private const string MEAL3 = "4盎司牛肉堡(雙)";
        private const string INFO3 = "Two quarter pound* 100% beef patties, seared to be thicker and juicier plus a pinch of salt and pepper. Layered with two slices of melty cheese, slivered onions and tangy pickles all on sesame seed bun. ";
        private const string MEAL4 = "培根牛肉堡";
        private const string INFO4 = "Thick-cut Applewood smoked bacon, caramelized grilled onions, white cheddar*, crisp leaf lettuce and fresh tomato, all lovingly layered on a quarter pound** of 100% pure beef, then topped with Big Mac special sauce. Served on our artisan roll.";
        private const string MEAL5 = "6塊雞塊";
        private const string INFO5 = "Our tender, juicy, Chicken McNuggets(6 pcs) are made with USDA-inspected white meat. They're tempura battered and cooked to golden perfection. Step up the fun with your choice of our delectable dipping sauces.";
        private const string MEAL6 = "9塊雞塊";
        private const string INFO6 = "Our tender, juicy, Chicken McNuggets(9 pcs) are made with USDA-inspected white meat. They're tempura battered and cooked to golden perfection. Step up the fun with your choice of our delectable dipping sauces.";
        private const string MEAL7 = "麥香魚";
        private const string INFO7 = "Dive right in and enjoy our wild-caught fish from our sustainable fishery, topped with melty American cheese, creamy tartar sauce and served on a soft, steamed bun.";
        private const string MEAL8 = "鬆餅";
        private const string INFO8 = "Three golden brown, melt-in-your-mouth hotcakes, with margarine and the sweet flavor of maple. Enjoy.";
        private const string MEAL9 = "豬肉鬆餅";
        private const string INFO9 = "Three golden brown, melt-in-your-mouth hotcakes and savory hot sausage with margarine and the sweet flavor of maple. Pretty sweet, huh?";
        private const string MEAL10 = "經典大早餐";
        private const string INFO10 = "Give your taste buds a wakeup call with a fresh-baked buttermilk biscuit, fluffy scrambled eggs, savory hot sausage and crispy golden hash browns. You can also enjoy it with 100%, freshly grilled egg whites instead.";
        private const string MEAL11 = "冰炫風";
        private const string INFO11 = "Can our soft serve reduced fat ice cream get any better? Yes, when we mix in OREO® Cookies.";
        private const string MEAL12 = "鳳梨派";
        private const string INFO12 = "It's the tradition you love to uphold, with delicious apples lightly spiced with cinnamon, baked in flaky pastry.";
        private const string MEAL13 = "蘋果派";
        private const string INFO13 = "It's the tradition you love to uphold, with delicious pineapples lightly spiced with cinnamon, baked in flaky pastry.";
        private const string MEAL14 = "薯條(小)";
        private const string INFO14 = "Golden on the outside, soft and fluffy on the inside. Made with quality potatoes and cooked in our Canola oil blend for zero grams of trans fat per serving(small). Now that's an epic bite.";
        private const string MEAL15 = "薯條(大)";
        private const string INFO15 = "Golden on the outside, soft and fluffy on the inside. Made with quality potatoes and cooked in our Canola oil blend for zero grams of trans fat per serving(large). Now that's an epic bite.";
        private const string MEAL16 = "麥香雞";
        private const string INFO16 = "Dummy description";
        private const string MEAL17 = "蕈菇安格斯黑牛";
        private const string MEAL18 = "BLT安格斯黑牛";
        private const string MEAL19 = "BLT辣脆雞腿堡";
        private const string MEAL20 = "BLT嫩煎雞腿堡";
        private const string MEAL21 = "薑燒豬肉長堡";
        private const string MEAL22 = "煙燻鷄肉長堡";
        private const string MEAL23 = "沙拉";
        private const string MEAL24 = "酥嫩鷄翅(6塊)";
        private const string MEAL25 = "玉米濃湯";
        private const string MEAL26 = "測試用1";
        private const string MEAL27 = "測試用2";
        private const string MEAL28 = "測試用3";
        private const string MEAL29 = "測試用4";
        private const string MEAL30 = "測試用5";
        private const string MEAL31 = "測試用6";
        private const string MEAL32 = "測試用7";
        private const string MEAL33 = "測試用8";
        private const string MEAL34 = "測試用9";
        private const string MEAL35 = "測試用10";
        private const string MEAL36 = "測試用11";
        private const string MEAL37 = "測試用12";
        private const int PRICE1 = 39;
        private const int PRICE2 = 85;
        private const int PRICE3 = 115;
        private const int PRICE4 = 99;
        private const int PRICE5 = 69;
        private const int PRICE6 = 95;
        private const int PRICE7 = 75;
        private const int PRICE8 = 52;
        private const int PRICE9 = 57;
        private const int PRICE10 = 95;
        private const int PRICE11 = 49;
        private const int PRICE12 = 28;
        private const int PRICE13 = 28;
        private const int PRICE14 = 25;
        private const int PRICE15 = 49;
        private const int PRICE16 = 75;
        private const int PRICE17 = 115;
        private const int PRICE18 = 125;
        private const int PRICE19 = 105;
        private const int PRICE20 = 105;
        private const int PRICE21 = 79;
        private const int PRICE22 = 79;
        private const int PRICE23 = 30;
        private const int PRICE24 = 49;
        private const int PRICE25 = 30;
        private const int PRICE26 = 10;
        private const int PRICE27 = 20;
        private const int PRICE28 = 30;
        private const int PRICE29 = 40;
        private const int PRICE30 = 50;
        private const int PRICE31 = 60;
        private const int PRICE32 = 70;
        private const int PRICE33 = 80;
        private const int PRICE34 = 90;
        private const int PRICE35 = 100;
        private const int PRICE36 = 110;
        private const int PRICE37 = 120;
        public Model()
        {
            LoadDefaultMealList();
            LoadDefaultCategoryList();
        }
        public void NotifyMealObserver()//告知Meal有變化
        {
            if (_mealModelChanged != null)
                _mealModelChanged();
        }

        public void NotifyCategoryObserver()//告知Category有變化
        {
            if (_categoryModelChanged != null)
                _categoryModelChanged();
        }

        private void LoadDefaultMealList()//把預設餐點存進MealList
        {
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL1,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE1,
                _mealsOrdered = 0,
                _mealPicturePath = PATH1,
                _mealInfo = INFO1
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL2,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE2,
                _mealsOrdered = 0,
                _mealPicturePath = PATH2,
                _mealInfo = INFO2
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL3,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE3,
                _mealsOrdered = 0,
                _mealPicturePath = PATH3,
                _mealInfo = INFO3
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL4,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE4,
                _mealsOrdered = 0,
                _mealPicturePath = PATH4,
                _mealInfo = INFO4
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL5,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE5,
                _mealsOrdered = 0,
                _mealPicturePath = PATH5,
                _mealInfo = INFO5
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL6,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE6,
                _mealsOrdered = 0,
                _mealPicturePath = PATH6,
                _mealInfo = INFO6
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL7,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE7,
                _mealsOrdered = 0,
                _mealPicturePath = PATH7,
                _mealInfo = INFO7
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL8,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE8,
                _mealsOrdered = 0,
                _mealPicturePath = PATH8,
                _mealInfo = INFO8
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL9,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE9,
                _mealsOrdered = 0,
                _mealPicturePath = PATH9,
                _mealInfo = INFO9
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL10,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE10,
                _mealsOrdered = 0,
                _mealPicturePath = PATH10,
                _mealInfo = INFO10
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL11,
                _mealCategory = DESSERT,
                _mealPrice = PRICE11,
                _mealsOrdered = 0,
                _mealPicturePath = PATH11,
                _mealInfo = INFO11
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL12,
                _mealCategory = DESSERT,
                _mealPrice = PRICE12,
                _mealsOrdered = 0,
                _mealPicturePath = PATH12,
                _mealInfo = INFO12
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL13,
                _mealCategory = DESSERT,
                _mealPrice = PRICE13,
                _mealsOrdered = 0,
                _mealPicturePath = PATH13,
                _mealInfo = INFO13
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL14,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE14,
                _mealsOrdered = 0,
                _mealPicturePath = PATH14,
                _mealInfo = INFO14
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL15,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE15,
                _mealsOrdered = 0,
                _mealPicturePath = PATH15,
                _mealInfo = INFO15
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL16,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE16,
                _mealsOrdered = 0,
                _mealPicturePath = PATH16,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL17,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE17,
                _mealsOrdered = 0,
                _mealPicturePath = PATH17,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL18,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE18,
                _mealsOrdered = 0,
                _mealPicturePath = PATH18,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL19,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE19,
                _mealsOrdered = 0,
                _mealPicturePath = PATH19,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL20,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE20,
                _mealsOrdered = 0,
                _mealPicturePath = PATH20,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL21,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE21,
                _mealsOrdered = 0,
                _mealPicturePath = PATH21,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL22,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE22,
                _mealsOrdered = 0,
                _mealPicturePath = PATH22,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL23,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE23,
                _mealsOrdered = 0,
                _mealPicturePath = PATH23,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL24,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE24,
                _mealsOrdered = 0,
                _mealPicturePath = PATH24,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL25,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE25,
                _mealsOrdered = 0,
                _mealPicturePath = PATH25,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL26,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE26,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL27,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE27,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL28,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE28,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL29,
                _mealCategory = HAMBURGER,
                _mealPrice = PRICE29,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL30,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE30,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL31,
                _mealCategory = SIDE_DISH,
                _mealPrice = PRICE31,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL32,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE32,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL33,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE33,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL34,
                _mealCategory = BREAKFAST,
                _mealPrice = PRICE34,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL35,
                _mealCategory = DESSERT,
                _mealPrice = PRICE35,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL36,
                _mealCategory = DESSERT,
                _mealPrice = PRICE36,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
            _mealList.Add(new Meal.Meals()
            {
                _mealText = MEAL37,
                _mealCategory = DESSERT,
                _mealPrice = PRICE37,
                _mealsOrdered = 0,
                _mealPicturePath = PATH_DUMMY,
                _mealInfo = INFO16
            });
        }

        private void LoadDefaultCategoryList()//把預設種類存進CategoryList
        {
            _categoryList.Add(new Category.Categories()
            {
                _categoryName = HAMBURGER
            });
            _categoryList.Add(new Category.Categories()
            {
                _categoryName = SIDE_DISH
            });
            _categoryList.Add(new Category.Categories()
            {
                _categoryName = BREAKFAST
            });
            _categoryList.Add(new Category.Categories()
            {
                _categoryName = DESSERT
            });
        }
    }
}
