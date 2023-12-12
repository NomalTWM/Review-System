namespace Review_system01
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ReviewText = new System.Windows.Forms.TextBox();
            this.AddReviewButton = new System.Windows.Forms.Button();
            this.ShowReviewButton = new System.Windows.Forms.Button();
            this.ReviewDisplay = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.tagsList = new System.Windows.Forms.CheckedListBox();
            this.starAddReview = new System.Windows.Forms.NumericUpDown();
            this.SpringCleanButton = new System.Windows.Forms.Button();
            this.RestaurantList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.starAddReview)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Stars",
            "NameReverse"});
            this.comboBox1.Location = new System.Drawing.Point(509, 12);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 86);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Sort by";
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ReviewText
            // 
            this.ReviewText.Location = new System.Drawing.Point(53, 88);
            this.ReviewText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReviewText.MaxLength = 5000;
            this.ReviewText.Multiline = true;
            this.ReviewText.Name = "ReviewText";
            this.ReviewText.Size = new System.Drawing.Size(248, 428);
            this.ReviewText.TabIndex = 1;
            this.ReviewText.Text = "Enter review";
            this.ReviewText.Visible = false;
            this.ReviewText.Click += new System.EventHandler(this.ReviewText_Click);
            this.ReviewText.TextChanged += new System.EventHandler(this.ReviewText_TextChanged);
            // 
            // AddReviewButton
            // 
            this.AddReviewButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddReviewButton.Location = new System.Drawing.Point(53, 31);
            this.AddReviewButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddReviewButton.Name = "AddReviewButton";
            this.AddReviewButton.Size = new System.Drawing.Size(103, 53);
            this.AddReviewButton.TabIndex = 2;
            this.AddReviewButton.Text = "Add Review";
            this.AddReviewButton.UseVisualStyleBackColor = true;
            this.AddReviewButton.Visible = false;
            this.AddReviewButton.Click += new System.EventHandler(this.AddReviewButton_Click);
            // 
            // ShowReviewButton
            // 
            this.ShowReviewButton.Location = new System.Drawing.Point(434, 22);
            this.ShowReviewButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShowReviewButton.Name = "ShowReviewButton";
            this.ShowReviewButton.Size = new System.Drawing.Size(62, 35);
            this.ShowReviewButton.TabIndex = 4;
            this.ShowReviewButton.Text = "Show Reviews";
            this.ShowReviewButton.UseVisualStyleBackColor = true;
            this.ShowReviewButton.Visible = false;
            this.ShowReviewButton.Click += new System.EventHandler(this.ShowReviewButton_Click);
            // 
            // ReviewDisplay
            // 
            this.ReviewDisplay.AutoEllipsis = true;
            this.ReviewDisplay.AutoSize = true;
            this.ReviewDisplay.Location = new System.Drawing.Point(333, 125);
            this.ReviewDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ReviewDisplay.Name = "ReviewDisplay";
            this.ReviewDisplay.Size = new System.Drawing.Size(35, 13);
            this.ReviewDisplay.TabIndex = 5;
            this.ReviewDisplay.Text = "label1";
            this.ReviewDisplay.Visible = false;
            this.ReviewDisplay.Click += new System.EventHandler(this.ReviewDisplay_Click);
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(1321, 14);
            this.UsernameText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(189, 20);
            this.UsernameText.TabIndex = 6;
            this.UsernameText.Text = "Enter Username";
            this.UsernameText.Click += new System.EventHandler(this.UsernameText_Click);
            this.UsernameText.TextChanged += new System.EventHandler(this.UsernameText_TextChanged);
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(1321, 57);
            this.PasswordText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(189, 20);
            this.PasswordText.TabIndex = 7;
            this.PasswordText.Text = "Enter Password";
            this.PasswordText.Click += new System.EventHandler(this.PasswordText_Click);
            this.PasswordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(1431, 108);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(50, 27);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // tagsList
            // 
            this.tagsList.CheckOnClick = true;
            this.tagsList.FormattingEnabled = true;
            this.tagsList.Location = new System.Drawing.Point(1511, 12);
            this.tagsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tagsList.Name = "tagsList";
            this.tagsList.Size = new System.Drawing.Size(81, 679);
            this.tagsList.TabIndex = 10;
            this.tagsList.Visible = false;
            this.tagsList.SelectedIndexChanged += new System.EventHandler(this.tagsList_SelectedIndexChanged);
            // 
            // starAddReview
            // 
            this.starAddReview.Location = new System.Drawing.Point(203, 40);
            this.starAddReview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.starAddReview.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.starAddReview.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.starAddReview.Name = "starAddReview";
            this.starAddReview.Size = new System.Drawing.Size(80, 20);
            this.starAddReview.TabIndex = 11;
            this.starAddReview.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.starAddReview.Visible = false;
            // 
            // SpringCleanButton
            // 
            this.SpringCleanButton.Location = new System.Drawing.Point(580, 620);
            this.SpringCleanButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SpringCleanButton.Name = "SpringCleanButton";
            this.SpringCleanButton.Size = new System.Drawing.Size(120, 43);
            this.SpringCleanButton.TabIndex = 12;
            this.SpringCleanButton.Text = "Spring cleaning";
            this.SpringCleanButton.UseVisualStyleBackColor = true;
            this.SpringCleanButton.Click += new System.EventHandler(this.SpringCleanButton_Click);
            // 
            // RestaurantList
            // 
            this.RestaurantList.FormattingEnabled = true;
            this.RestaurantList.Location = new System.Drawing.Point(1375, 148);
            this.RestaurantList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RestaurantList.Name = "RestaurantList";
            this.RestaurantList.Size = new System.Drawing.Size(81, 368);
            this.RestaurantList.TabIndex = 13;
            this.RestaurantList.Tag = "RestaurantList";
            this.RestaurantList.Visible = false;
            this.RestaurantList.SelectedIndexChanged += new System.EventHandler(this.RestaurantList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 697);
            this.Controls.Add(this.RestaurantList);
            this.Controls.Add(this.SpringCleanButton);
            this.Controls.Add(this.starAddReview);
            this.Controls.Add(this.tagsList);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.ReviewDisplay);
            this.Controls.Add(this.ShowReviewButton);
            this.Controls.Add(this.AddReviewButton);
            this.Controls.Add(this.ReviewText);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.starAddReview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox ReviewText;
        private System.Windows.Forms.Button AddReviewButton;
        private System.Windows.Forms.Button ShowReviewButton;
        private System.Windows.Forms.Label ReviewDisplay;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.CheckedListBox tagsList;
        private System.Windows.Forms.NumericUpDown starAddReview;
        private System.Windows.Forms.Button SpringCleanButton;
        public System.Windows.Forms.ListBox RestaurantList;
    }
}

