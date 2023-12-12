using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Review_system01
{
    public partial class Form1 : Form
    {
        public bool loggedIn = false;
        //private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\44734\\Downloads\\restaurants.mdf;Integrated Security=True;Connect Timeout=30";
        private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\\\esher.ac.uk\\home\\students\\2023\\232472\\Restaurants.mdf;Integrated Security=True;Connect Timeout=30";
        public string uName;
        public string restaurantUserID;
        private SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(CONNECT);
            GetTags();
            GetRestaurantNames();
            ReviewDisplay.MaximumSize = new Size(1600, 0);
            ReviewDisplay.AutoSize = true;

        }
        private void GetTags()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select Tag from Tags order by Tag", sqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tagsList.Items.Add(reader["Tag"], false);
                }
            }
            sqlConnection.Close();
        }

        private void GetRestaurantNames()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select RestaurantName from Restaurants order by RestaurantName", sqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    RestaurantList.Items.Add(reader["RestaurantName"]);
                }
            }
            sqlConnection.Close();
        }

        private void ReviewText_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddReviewButton_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string restaurantUserName, userName, date, reviewText, tempDate;
            int rating;

            restaurantUserName = RestaurantList.Text;
            restaurantUserID = null;
            userName = uName;
            DateTime dateTime = DateTime.UtcNow.Date;
            date = dateTime.ToString("yyyyMMdd");
            //tempDate = Convert.ToString(date[0] + date[1] + date[3] + date[4]+ "-"+ date[6] + date[7] + "-" + date[8] + date[9]);
           // date = tempDate;
            reviewText = ReviewText.Text;
            rating = Convert.ToInt32(starAddReview.Value);
            SqlCommand commandFindRestaurantName = new SqlCommand("select RestaurantID, RestaurantName from Restaurants", sqlConnection);

            using (SqlDataReader reader = commandFindRestaurantName.ExecuteReader())
            {
                while (reader.Read())
                {
                    if(Convert.ToString(reader["RestaurantName"]) == restaurantUserName)
                    {
                        restaurantUserID = Convert.ToString(reader["RestaurantID"]);
                    }

                }
            }


                SqlCommand command = new SqlCommand($"INSERT INTO Reviews VALUES ('{userName}','{restaurantUserID}','{date}', {rating}, '{reviewText}')", sqlConnection);
                command.ExecuteReader();
            
            sqlConnection.Close();
        }

        private void StarReview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReviewText_Click(object sender, EventArgs e)
        {
            if (ReviewText.Text == "Enter review")
            {
                ReviewText.Text = "";
            }
        }

        private void ShowReviewButton_Click(object sender, EventArgs e)
        {            
            
        }

        private void ReviewDisplay_Click(object sender, EventArgs e)
        {

        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            uName = UsernameText.Text;
            string pWord = PasswordText.Text;
            string tstUName, tstPwd;

           
            sqlConnection.Open();
            SqlCommand command = new SqlCommand($"SELECT UserName, UserPassword from Users", sqlConnection);
            int result = command.ExecuteNonQuery();

            if (loggedIn)
            {
                invisSwitch();
                UsernameText.Text = "Enter Username";
                PasswordText.Text = "Enter Password";
                UsernameText.Visible = true;
                PasswordText.Visible = true;
                loginButton.Text = "Login";
                loggedIn = false;
            }
            else
            {

                // result gives the -1 output.. but on insert its 1
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        tstUName = reader["UserName"].ToString();
                        tstPwd = reader["UserPassword"].ToString();
                        if (tstUName == uName)
                        {
                            if (tstPwd == pWord)
                            {
                                loggedIn = true;
                                UsernameText.Visible = false;
                                PasswordText.Visible = false;
                                invisSwitch();
                                loginButton.Text = "Logout";
                            }
                        }


                    }
                }
            }

            sqlConnection.Close();
        }
        private void RestaurantList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string orderBy;
            string restaurantChosen = RestaurantList.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0: orderBy = "RestaurantRating"; break;


                case 1: orderBy = "RestaurantName desc"; break;

                case 2: orderBy = "RestaurantName desc"; break;

                default: orderBy = "RestaurantName"; break;
            }
            SqlCommand command = new SqlCommand($"SELECT RestaurantName, RestaurantPostcode, RestaurantRating from Restaurants order by {orderBy}", sqlConnection);

            int result = command.ExecuteNonQuery();

            // result gives the -1 output.. but on insert its 1
            using (SqlDataReader reader = command.ExecuteReader())
            {
                ReviewDisplay.Text = "";
                while (reader.Read())
                {
                    if (Convert.ToString(reader["RestaurantName"]) == restaurantChosen)
                    {
                        ReviewDisplay.Text += ($"{reader["RestaurantName"]}, at {reader["RestaurantPostcode"]} with {reader["RestaurantRating"]} Stars\n");
                    }
                }
            }
            SqlCommand command0 = new SqlCommand($"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')", sqlConnection);
            using (SqlDataReader reader = command0.ExecuteReader())
            {
                while (reader.Read())
                {

                    ReviewDisplay.Text += ($"{reader["ReviewStarRating"]} stars, from {reader["UserName"]} at {reader["ReviewDate"]}, text {reader["ReviewText"]}\n");

                }



            }
            SqlCommand command1 = new SqlCommand($"select Tag from RestaurantTags where RestaurantTags.RestaurantID = (select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')", sqlConnection);

            for (int r = 0; r < tagsList.Items.Count + tagsList.Items.Count; r++) {
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < tagsList.Items.Count; i++)
                        {
                            if (Convert.ToString(reader["Tag"]) == Convert.ToString(tagsList.Items[i]))
                            {
                                tagsList.SetItemCheckState(i, CheckState.Checked);
                            }
                            else
                            {
                                tagsList.SetItemCheckState(i, CheckState.Unchecked);//not working

                            }
                        }
                    }



                }
            }
        
            
            sqlConnection.Close();
        }

        private void UsernameText_Click(object sender, EventArgs e)
        {
            if (UsernameText.Text == "Enter Username")
            {
                UsernameText.Text = "";
            }
        }

        private void PasswordText_Click(object sender, EventArgs e)
        {
            if (PasswordText.Text == "Enter Password")
            {
                PasswordText.Text = "";
            }
        }
        public void invisSwitch()
        {
            if (AddReviewButton.Visible)
            {
                AddReviewButton.Visible = false;
                ReviewText.Visible = false;
                ShowReviewButton.Visible = false;
                comboBox1.Visible = false;
                ReviewDisplay.Visible = false;
                tagsList.Visible = false;
                starAddReview.Visible = false;
                RestaurantList.Visible = false;
            }
            else
            {
                AddReviewButton.Visible = true;
                ReviewText.Visible = true;
                ShowReviewButton.Visible = true;
                comboBox1.Visible = true;
                ReviewDisplay.Visible = true;
                tagsList.Visible = true;
                starAddReview.Visible = true;
                RestaurantList.Visible = true;

            }

        }

        private void restaurantNameTextBox_Click(object sender, EventArgs e)
        {
        }

        private void SpringCleanButton_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("delete from reviews where UserName = 'a'", sqlConnection);
            command.ExecuteReader();
            sqlConnection.Close();
        }

        private void restaurantNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
