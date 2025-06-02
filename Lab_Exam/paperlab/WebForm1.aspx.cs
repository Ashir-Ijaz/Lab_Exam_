using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace paperlab
{
    public partial class WebForm1 : Page
    {
        private string connStr = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename=|DataDirectory|\Database1.mdf;";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

 

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Feedback (StudentName, CourseName, Comments, Phone) " +
                               "VALUES (@StudentName, @CourseName, @Comments, @Phone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentName", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Comments", txtComments.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            txtStudentName.Text = "";
            txtCourseName.Text = "";
            txtComments.Text = "";
            txtPhone.Text = "";

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Feedback submitted successfully!');", true);

            
        }
        protected void btnViewFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }
    }
}
