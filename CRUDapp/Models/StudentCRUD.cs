using System.Data.SqlClient;

namespace CRUDapp.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private readonly IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Student> GetAllStudent()
        {
            List<Student> Stdlist = new List<Student>();
            string qry = "Select*from tblStudent where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                { Student std= new Student();
                    std.RollNo = Convert.ToInt32(dr["RollNo"]);
                    std.Name = dr["Name"].ToString();
                    std.Class = dr["Class"].ToString();
                    std.Marks = Convert.ToDouble(dr["Marks"]);
                    Stdlist.Add(std);

                }
            }
            con.Close();
            return Stdlist;
        }
        public Student GetStudentById(int RollNo)
        {
            Student std = new Student();
            string qry = "Select*from tblStudent where RollNo=@RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", RollNo);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    std.RollNo = Convert.ToInt32(dr["RollNo"]);
                    std.Name = dr["Name"].ToString();
                    std.Class = dr["Class"].ToString();
                    std.Marks = Convert.ToDouble(dr["Marks"]);
                    std.IsActive = Convert.ToInt32(dr["IsActive"]);
                    

                }
            }
            con.Close();
            return std;
        }
        public int AddStudent(Student std)
        {
            int result = 0;
            std.IsActive = 1;
            string qry = "insert into tblStudent values(@Name,@Class,@Marks,@IsActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Class", std.Class);
            cmd.Parameters.AddWithValue("@Marks", std.Marks);
                cmd.Parameters.AddWithValue("@IsActive", std.IsActive);

            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
            
        }
        public int UpdateStudent(Student std)
        {
            int result = 0;
            std.IsActive = 1;
            string qry = "update tblStudent set Name=@Name,Class=@Class,Marks=@Marks, IsActive=@IsActive where RollNo=@RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", std.RollNo);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Class", std.Class);
            cmd.Parameters.AddWithValue("@Marks", std.Marks);
            cmd.Parameters.AddWithValue("@IsActive", std.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent( int RollNo)
        {
            int result = 0;
            string qry = "Delete from tblStudent where RollNo=@RollNo ";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo",RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
    
}

