using System.Data.SqlClient;

namespace CRUDapp.Models
{
    public class BookCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private readonly IConfiguration configuration;
        public BookCRUD(IConfiguration configuration)
        {
                this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Book> GetAllBook()
        {
            List<Book>BookList=new List<Book> ();
            string qry = "Select * from tblBook ";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Book book =new Book ();
                    book.Id = Convert.ToInt32(dr["Id"]);
                    book.Name = dr["BName"].ToString();
                    book.Author = dr["Author"].ToString();
                    book.Price = Convert.ToDouble(dr["Price"]);
                    BookList.Add(book);
                    
                }
            }
            con.Close();
            return BookList;
        }
        public Book GetbookBYID(int id)
        {
            Book book  = new Book ();
            string qry = "Select * from tblBook where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    book.Id = Convert.ToInt32(dr["Id"]);
                    book.Name = dr["BName"].ToString();
                    book.Author = dr["Author"].ToString();
                    book.Price = Convert.ToDouble(dr["Price"]);

                }
            }
            con.Close();
            return book;
        }
        public int AddBook(Book book )
        {
            int result = 0;
            string qry = "Insert into tblBook values(@BName,@Author,@Price)";
            cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@BName", book.Name);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close() ;
            return result;
            
        }
        public int deleteBook(int id)
        {
            int result = 0;
            string qry = "Delete from tblBook where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int updatebook(Book book )
        {
            int result = 0;
            string qry = "update tblBook set BName=@BName,Author=@Author,Price=@Price where Id=@Id";
            cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@BName", book.Name);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
