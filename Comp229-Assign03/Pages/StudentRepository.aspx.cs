using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03.Pages
{
    public partial class StudentRepository : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Students();
        }
        protected void Load_Students()
        {
            var studentID = Convert.ToInt32(Request.QueryString["id"]);

            // Named database as Comp229Assign03, replace with Assign03 before handing in
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
            SqlCommand loadStudents = new SqlCommand("Select * from Students", connection);

            //loadStudents.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            //loadStudents.Parameters["@studentID"].Value = studentID;
    
           
            try
            {
                connection.Open();
                SqlDataReader reader = loadStudents.ExecuteReader();
                studentGridView.DataSource = reader;
                studentGridView.DataBind();

            }
            finally
            {
                connection.Close();
            }
        }

        protected void Add_Student(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
            SqlCommand addStudent = new SqlCommand("INSERT INTO Students VALUES (@StudentID, @FirstMidName, @LastName, @EnrollmentDate", connection);

            addStudent.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            addStudent.Parameters["@studentID"].Value = studentID;
            addStudent.Parameters.Add("@FirstMidName", System.Data.SqlDbType.NVarChar);
            addStudent.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar);
            addStudent.Parameters.Add("@EnrollmentDate", System.Data.SqlDbType.Date);


            try
            {
                connection.Open();
                addStudent.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }
            Response.Redirect("~/Pages/StudentRepository.aspx");
        }

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    var studentId = Convert.ToInt32(Request.QueryString["id"]);

        //    // Named database as Comp229Assign03, replace with Assign03 before handing in
        //    SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Assign03;Integrated Security=True");
        //    SqlCommand deleteFromEnroll = new SqlCommand("DELETE FROM Enrollments WHERE StudentID=@StudentID", connection);
        //    SqlCommand deleteFromStudents = new SqlCommand("DELETE FROM Students WHERE StudentID=@StudentID", connection);

        //    deleteFromEnroll.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
        //    deleteFromEnroll.Parameters["@StudentID"].Value = studentId;

        //    deleteFromStudents.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
        //    deleteFromStudents.Parameters["@StudentID"].Value = studentId;

        //    try
        //    {
        //        connection.Open();
        //        deleteFromEnroll.ExecuteNonQuery();
        //        deleteFromStudents.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    Response.Redirect("~/Pages/StudentRepository.aspx");
        //}

        protected void addStudentButton_Click(object sender, EventArgs e)
        {

        }
    }
}