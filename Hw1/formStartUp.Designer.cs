namespace Hw1
{
    partial class FormStartUp
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
            this._buttonCustomer = new System.Windows.Forms.Button();
            this._buttonRestaurant = new System.Windows.Forms.Button();
            this._buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonCustomer
            // 
            this._buttonCustomer.AccessibleName = "_openFront";
            this._buttonCustomer.Location = new System.Drawing.Point(12, 12);
            this._buttonCustomer.Name = "_buttonCustomer";
            this._buttonCustomer.Size = new System.Drawing.Size(222, 72);
            this._buttonCustomer.TabIndex = 0;
            this._buttonCustomer.Text = "顧客(前端)";
            this._buttonCustomer.UseVisualStyleBackColor = true;
            this._buttonCustomer.Click += new System.EventHandler(this.ButtonCustomerClick);
            // 
            // _buttonRestaurant
            // 
            this._buttonRestaurant.AccessibleName = "_openBack";
            this._buttonRestaurant.Location = new System.Drawing.Point(240, 12);
            this._buttonRestaurant.Name = "_buttonRestaurant";
            this._buttonRestaurant.Size = new System.Drawing.Size(222, 72);
            this._buttonRestaurant.TabIndex = 1;
            this._buttonRestaurant.Text = "業者(後端)";
            this._buttonRestaurant.UseVisualStyleBackColor = true;
            this._buttonRestaurant.Click += new System.EventHandler(this.ButtonRestaurantClick);
            // 
            // _buttonExit
            // 
            this._buttonExit.Location = new System.Drawing.Point(347, 102);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(114, 54);
            this._buttonExit.TabIndex = 2;
            this._buttonExit.Text = "離開";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // FormStartUp
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 168);
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this._buttonRestaurant);
            this.Controls.Add(this._buttonCustomer);
            this.Name = "FormStartUp";
            this.Text = "開啟";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonRestaurant;
        private System.Windows.Forms.Button _buttonExit;
        public System.Windows.Forms.Button _buttonCustomer;
    }
}