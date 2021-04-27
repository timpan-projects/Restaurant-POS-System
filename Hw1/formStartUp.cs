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
    
    public partial class FormStartUp : Form
    {
        private Model _model = new Model();
        public FormStartUp()
        {
            InitializeComponent();
        }
        private void ButtonCustomerClick(object sender, EventArgs e)//點擊『前端』按鈕
        {
            FormCustomer formCustomer = new FormCustomer(_model);
            formCustomer.Show();
            _buttonCustomer.Enabled = false;
            formCustomer.FormClosed += ButtonCustomerEnable;
        }

        private void ButtonCustomerEnable(object sender, FormClosedEventArgs e)//控制『開前端』按鈕Enable
        {
            _buttonCustomer.Enabled = true;
        }

        private void ButtonRestaurantClick(object sender, EventArgs e)//點擊『後端』按鈕
        {
            FormEmployee formEmployee = new FormEmployee(_model);
            formEmployee.Show();
            _buttonRestaurant.Enabled = false;
            formEmployee.FormClosed += ButtonRestaurantEnable;
        }

        private void ButtonRestaurantEnable(object sender, FormClosedEventArgs e)//控制『開後端』按鈕Enable
        {
            _buttonRestaurant.Enabled = true;
        }

        private void ButtonExitClick(object sender, EventArgs e)//關閉程式
        {
            this.Close();
        }

    }
}
