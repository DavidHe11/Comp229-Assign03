using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03.Pages
{
    public partial class UpdatePage : System.Web.UI.Page
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
                FirstMidNameTextBox.DataBind();
                reader = showStudentLName.ExecuteReader();
                LastNameTextBox.DataBind();
            }
            finally
            {
                connection.Close();
            }


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var studentId = Convert.ToInt32(Request.QueryString["StudentID"]);
            var firstMidName = Convert.ToString(Request.QueryString["FirstMidName"]);
            var lastName = Convert.ToString(Request.QueryString["LastName"]);

            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
            SqlCommand updateStudent = new SqlCommand("UPDATE Students SET FirstMidName = '@firstMidName', LastName = '@lastName' WHERE StudentID=@StudentID", connection);

            updateStudent.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            updateStudent.Parameters["@studentID"].Value = studentId;
            updateStudent.Parameters.Add("@FirstMidName", System.Data.SqlDbType.NVarChar);
            updateStudent.Parameters["@FirstMidName"].Value = firstMidName;
            updateStudent.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar);
            updateStudent.Parameters["@LastName"].Value = lastName;

            try
            {
                connection.Open();
                updateStudent.BeginExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            Response.Redirect("~/Pages/StudentRepository.aspx");
        }
    }
}