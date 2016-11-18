using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03.Pages
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var studentId = Convert.ToInt32(Request.QueryString["StudentID"]);
            var firstMidName = Convert.ToString(Request.QueryString["FirstMidName"]);
            var lastName = Convert.ToString(Request.QueryString["LastName"]);

            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
            SqlCommand showStudentID = new SqlCommand("Select StudentID FROM Students WHERE StudentID=@StudentID", connection);
            SqlCommand showStudentFName = new SqlCommand("Select FirstMidName FROM Students WHERE StudentID=@StudentID", connection);
            SqlCommand showStudentLName = new SqlCommand("Select LastName FROM Students WHERE StudentID=@StudentID", connection);

            showStudentID.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            showStudentID.Parameters["@studentID"].Value = studentId;
            showStudentFName.Parameters.Add("@FirstMidName", System.Data.SqlDbType.NVarChar);
            showStudentFName.Parameters["@FirstMidName"].Value = firstMidName;
            showStudentLName.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar);
            showStudentLName.Parameters["@LastName"].Value = lastName;


            try
            {
                connection.Open();
                SqlDataReader reader = showStudentID.ExecuteReader();
                StudentIDLbl.DataBind();
                reader = showStudentFName.ExecuteReader();
                FirstMidNameLbl.DataBind();
                reader = showStudentLName.ExecuteReader();
                LastNameLbl.DataBind();
            }
            finally
            {
                connection.Close();
            }
        }
            protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/UpdatePage.aspx");
        }

            protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var studentId = Convert.ToInt32(Request.QueryString["StudentID"]);

            // Named database as Comp229Assign03, replace with Assign03 before handing in
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
            SqlCommand deleteFromEnroll = new SqlCommand("DELETE FROM Enrollments WHERE StudentID=@StudentID", connection);
            SqlCommand deleteFromStudents = new SqlCommand("DELETE FROM Students WHERE StudentID=@StudentID", connection);

            deleteFromEnroll.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            deleteFromEnroll.Parameters["@StudentID"].Value = studentId;

            deleteFromStudents.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            deleteFromStudents.Parameters["@StudentID"].Value = studentId;

            try
            {
                connection.Open();
                deleteFromEnroll.ExecuteNonQuery();
                deleteFromStudents.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            Response.Redirect("~/Pages/StudentRepository.aspx");
        }

    }
    }