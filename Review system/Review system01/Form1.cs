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
        private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\44734\\Downloads\\restaurants.mdf;Integrated Security=True;Connect Timeout=30";
        //private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\\\esher.ac.uk\\home\\students\\2023\\232472\\Restaurants.mdf;Integrated Security=True;Connect Timeout=30";
        public string uName;
        public string restaurantUserID;
        public string commandText;
        private SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(CONNECT);
            GetTags();
            GetRestaurantNames();
            //ReviewDisplayList.MaximumSize = new Size(1600, 0);
           // ReviewDisplayList.AutoSize = true;

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
            if(ReviewText.Text == "Enter review")
            {
                ReviewText.Text = null;
            }
            string restaurantUserName, userName, date, reviewText;
            int rating;
            float avgRating;
            int totalRating = 0;
            int totalRatingCount = 0;

            restaurantUserName = RestaurantList.Text;
            restaurantUserID = null;
            userName = uName;
            DateTime dateTime = DateTime.UtcNow.Date;
            date = dateTime.ToString("yyyyMMdd");

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
            if (restaurantUserID != null)
            {
                command.ExecuteNonQuery();
                ReviewText.Text = "Enter review";
                starAddReview.Value = 1;
            }
            else
            {
                MessageBox.Show("Select a restaurant to add a review", "No restaurant selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //Average star rating thing
            //HEREIAM
            SqlCommand findStars = new SqlCommand($"select ReviewStarRating from Reviews where RestaurantID = (select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
            using(SqlDataReader readerStar = findStars.ExecuteReader())
            {
                while (readerStar.Read())
                {
                    totalRating += Convert.ToInt32(readerStar["ReviewStarRating"]);
                    totalRatingCount++;
                }
            }
            avgRating = totalRating / totalRatingCount;
            SqlCommand insertAvgRatubg = new SqlCommand($"update Restaurants set RestaurantRating = {avgRating} where RestaurantID = (select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
            insertAvgRatubg.ExecuteNonQuery();
            //No idea if this works
            sqlConnection.Close();
            UpdateDisplay();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
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
            UpdateDisplay();
        }

        private void ReviewDisplay_Click(object sender, EventArgs e)
        {

        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            PasswordText.UseSystemPasswordChar = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            uName = UsernameText.Text;
            string pWord = PasswordText.Text;
            string tstUName, tstPwd;

           
            sqlConnection.Open();
            SqlCommand command = new SqlCommand($"SELECT UserName, UserPassword from Users where UserName = '{uName}' and UserPassword = '{pWord}'", sqlConnection);
            int result = command.ExecuteNonQuery();

            if (loggedIn)
            {
                invisSwitch();
                UsernameText.Text = "Enter Username";
                PasswordText.Text = "Enter Password";
                PasswordText.UseSystemPasswordChar = false;
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

                    if (reader.Read())
                    {
                                loggedIn = true;
                                UsernameText.Visible = false;
                                PasswordText.Visible = false;
                                invisSwitch();
                                loginButton.Text = "Logout";
                    }
                    else
                    {
                        MessageBox.Show("User Not Found", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
            }

            sqlConnection.Close();
        }
        private List<string> FindUserNames()
        {
            List<string> reviewUserNames = new List<string>();
            sqlConnection.Open();
            SqlCommand findReviewUserNames = new SqlCommand($"select UserName from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
            using(SqlDataReader reader0 = findReviewUserNames.ExecuteReader())
            {
                while(reader0.Read())
                {
                    reviewUserNames.Add(Convert.ToString(reader0["UserName"]));
                }
            }
            sqlConnection.Close();
            return reviewUserNames;

        }
        private List<string> FindUserText()
        {
            List<string> reviewUserText = new List<string>();
            sqlConnection.Open();
            SqlCommand findReviewUserText = new SqlCommand($"select ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
            using (SqlDataReader reader0 = findReviewUserText.ExecuteReader())
            {
                while (reader0.Read())
                {
                    reviewUserText.Add(Convert.ToString(reader0["ReviewText"]));
                }
            }
            sqlConnection.Close();
            return reviewUserText;

        }
        private List<int> FindUserRatings()
        {
            List<int> reviewUserRatings = new List<int>();
            sqlConnection.Open();
            SqlCommand findReviewUserRatings = new SqlCommand($"select ReviewStarRating from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
            using (SqlDataReader reader0 = findReviewUserRatings.ExecuteReader())
            {
                while (reader0.Read())
                {
                    reviewUserRatings.Add(Convert.ToInt32(reader0["ReviewStarRating"]));
                }
            }
            sqlConnection.Close();
            return reviewUserRatings;

        }


        private void EditReview(bool delete)
        {
            string editOrDelete;
            if (delete)
            {
                editOrDelete = "delete";
            }
            else
            {
                editOrDelete = "edit";
            }
            List<string> userNames = FindUserNames();
            List<string> userTexts = FindUserText();
            List<int> userRatings = FindUserRatings();
            if (ReviewDisplayList.SelectedIndex > 0)
            {
                //if uname = Review Username
                if(uName == userNames[ReviewDisplayList.SelectedIndex-1])
                {

                    DialogResult doReview = MessageBox.Show($"Do you want to {editOrDelete} this review, this cannot be undone", "Edit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (doReview == DialogResult.Yes)
                    {
                        if (!delete)
                        {
                            ReviewText.Text = userTexts[ReviewDisplayList.SelectedIndex - 1];
                            starAddReview.Value = userRatings[ReviewDisplayList.SelectedIndex - 1];
                        }
                        sqlConnection.Open();
                        SqlCommand editReview = new SqlCommand($"delete from Reviews where UserName = '{userNames[ReviewDisplayList.SelectedIndex - 1]}' and ReviewText = '{userTexts[ReviewDisplayList.SelectedIndex - 1]}' and ReviewStarRating = '{userRatings[ReviewDisplayList.SelectedIndex - 1]}' and RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{RestaurantList.Text}')", sqlConnection);
                        editReview.ExecuteNonQuery();
                        sqlConnection.Close();
                        UpdateDisplay();
                    }
                }


            }
        }
        private void UpdateDisplay()
        {
            ReviewDisplayList.Items.Clear();
            sqlConnection.Open();
            string restaurantChosen = RestaurantList.Text;

            SqlCommand command = new SqlCommand($"SELECT RestaurantName, RestaurantPostcode, RestaurantRating from Restaurants where RestaurantName = '{restaurantChosen}'", sqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ReviewDisplayList.Items.Add($"{reader["RestaurantName"]}, at {reader["RestaurantPostcode"]} with {reader["RestaurantRating"]} Stars\n");
                }
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    commandText = $"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}') order by ReviewStarRating desc";
                    break;

                case 1:
                    commandText = $"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}') order by ReviewDate desc";
                    break;

                case 2:
                    commandText = $"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where NOT ReviewText = '' and RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')";

                    break;

                case 3:
                    commandText = $"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')";
                    dateTimePicker1.Visible = true;
                    
                    break;

                default:
                    commandText = $"select ReviewStarRating, UserName, ReviewDate, ReviewText from Reviews where RestaurantID =(select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')";
                    break;
            }

            SqlCommand command0 = new SqlCommand(commandText, sqlConnection);
            using (SqlDataReader reader = command0.ExecuteReader())
            {
                while (reader.Read())
                {

                    ReviewDisplayList.Items.Add($"{reader["ReviewStarRating"]} stars, from {reader["UserName"]} at {reader["ReviewDate"]}, description: {reader["ReviewText"]}\n");

                }
            }

            SqlCommand command1 = new SqlCommand($"select Tag from RestaurantTags where RestaurantTags.RestaurantID = (select RestaurantID from Restaurants where RestaurantName = '{restaurantChosen}')", sqlConnection);
            //for (int r = 0; r < tagsList.Items.Count * 10; r++)
            //{

            for(int i = 0; i< tagsList.Items.Count; i++)
            {
                tagsList.SetItemCheckState(i, CheckState.Unchecked);
            }
            using (SqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        int count = 0;
                        for(int i = 0; i< tagsList.Items.Count; i++)
                        {
                            if (Convert.ToString(reader["Tag"]) == Convert.ToString(tagsList.Items[i]))
                            {
                                
                                tagsList.SetItemCheckState(i, CheckState.Checked);
                            }

                            count++;
                        }

                    }
               // }
            }

            
            sqlConnection.Close();
        }
        private void RestaurantList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
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
                ReviewDisplayList.Visible = false;
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
                ReviewDisplayList.Visible = true;
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
            UpdateDisplay();
        }
        private void restaurantNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void tagsList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ReviewDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uName == FindUserNames()[ReviewDisplayList.SelectedIndex - 1])
            {
                EditReviewButton.Visible = true;
                DeleteReviewButton.Visible = true;

            }
            else
            {
                EditReviewButton.Visible = false;
                DeleteReviewButton.Visible = false;
            }
        }

        private void EditReviewButton_Click(object sender, EventArgs e)
        {
            EditReview(false);
            EditReviewButton.Visible = false;
            DeleteReviewButton.Visible = false;
        }

        private void DeleteReviewButton_Click(object sender, EventArgs e)
        {
            EditReview(true);
            EditReviewButton.Visible = false;
            DeleteReviewButton.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {

        }
    }
}
