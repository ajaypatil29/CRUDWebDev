using System.Data.SqlClient;

namespace CRUDapp.Models
{
    public class EmployeeCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeCRUD(IConfiguration configuration)
        {
            this.configuration=configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Employee>GetAllEmployee( )
        {
            List<Employee> Emplist = new List<Employee>();
            string qry = "Select*from tblEmployee where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Employee emp=new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["EName"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                    Emplist.Add(emp);

                }
            }
            con.Close();
            return Emplist;
        }
        public Employee GetEmployeById(int Id)
        {
            Employee emp = new Employee();
            string qry = "Select*from tblEmployee where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id",Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["EName"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.IsActive = Convert.ToInt32(dr["IsActive"]);
                    

                }
            }
            con.Close();
            return emp;
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "Insert into tblEmployee values(@Name,@Mobile,@Email,@City,@Gender,@Salary,@Isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "update tblEmployee set EName=@EName,Mobile=@Mobile,Email=@Email,City=@City,Gender=@Gender,Salary=@Salary,IsActive=@IsActive where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@EName", emp.Name);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@isActive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int DeleteEmployee(int Id)
        {
            int result = 0;
            string qry = "delete from tblEmployee where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id",Id );
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
    }
   
}
