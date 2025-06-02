using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paperlab
{
    public partial class ViewFeedback : Page
    {
        private string connStr = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename=|DataDirectory|\Database1.mdf;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeedback();
            }
        }

        private void LoadFeedback()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT FeedbackId, StudentName, CourseName, Comments, Phone FROM Feedback";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // Helper to get selected FeedbackId from GridView
        private int? GetSelectedFeedbackId()
        {
            if (GridView1.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a feedback row first.');", true);
                return null;
            }

            int feedbackId;
            if (int.TryParse(GridView1.SelectedDataKey.Value.ToString(), out feedbackId))
                return feedbackId;

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid feedback selection.');", true);
            return null;
        }

        protected void btnViewEdit_Click(object sender, EventArgs e)
        {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DBCC CHECKIDENT ('Feedback', RESEED, 0)", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

      
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Step 1: Get the maximum FeedbackId
                string getMaxIdQuery = "SELECT MAX(FeedbackId) FROM Feedback";
                SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);
                object result = getMaxIdCmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No feedback available to delete.');", true);
                    return;
                }

                int maxFeedbackId = Convert.ToInt32(result);

                // Step 2: Delete the feedback with max ID
                string deleteQuery = "DELETE FROM Feedback WHERE FeedbackId = @FeedbackId";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@FeedbackId", maxFeedbackId);

                int rows = deleteCmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
    
                    LoadFeedback(); // Refresh the GridView
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Could not delete feedback.');", true);
                }
            }
        }

    }
}
