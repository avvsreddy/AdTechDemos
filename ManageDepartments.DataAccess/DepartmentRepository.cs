using System.Data.SqlClient;

namespace ManageDepartments.DataAccess
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public void DeleteDepartment(int id)
        {
            // step 1: open db connection/login
            // need to install nuget package (www.nuget.org)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySampleDB;Integrated Security=true";

            // step 2: send sql delete statement
            // SQL Injection


            string sqlDelete = $"delete from dept where deptno = @deptno";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@deptno";
            p1.Value = id;
            cmd.Parameters.Add(p1);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            // step 3: close db connection
            //catch (SqlException ex)
            //{
            //    //Log the exp. inform the db admin
            //    throw ex;
            //}
            finally { conn.Close(); }
        }



        public List<Department> GetDepartments()
        {
            // step 1: open db connection/login
            // need to install nuget package (www.nuget.org)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySampleDB;Integrated Security=true";

            // step 2: send sql select statement
            // SQL Injection
            //string sqlInsert = $"insert into dept values({department.DepartmentNo},'{department.DepartmentName}','{department.Location}')";

            string sqlSelect = $"select * from dept";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);

            SqlDataReader reader = null;
            List<Department> departments = new List<Department>();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                // Step: 2A process the returned data
                while (reader.Read())
                {
                    Department department = new Department();
                    department.DepartmentNo = (int)reader[0];
                    department.DepartmentName = reader.GetString(1);   //reader[1].ToString();
                    department.Location = reader["loc"].ToString();
                    departments.Add(department);
                }

            }
            // step 3: close db connection

            finally { conn.Close(); }
            return departments;
        }

        public List<Department> GetDepartmentsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Department department)
        {
            // step 1: open db connection/login
            // need to install nuget package (www.nuget.org)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySampleDB;Integrated Security=true";

            // step 2: send sql insert statement
            // SQL Injection
            //string sqlInsert = $"insert into dept values({department.DepartmentNo},'{department.DepartmentName}','{department.Location}')";

            string sqlInsert = $"insert into dept values(@deptno,@dname,@loc)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@deptno";
            p1.Value = department.DepartmentNo;
            cmd.Parameters.Add(p1);

            cmd.Parameters.AddWithValue("@dname", department.DepartmentName);
            cmd.Parameters.AddWithValue("@loc", department.Location);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            // step 3: close db connection
            catch (SqlException ex)
            {
                //Log the exp. inform the db admin
                throw ex;
            }
            finally { conn.Close(); }


        }

        public void UpdateDepartment(Department department)
        {
            // step 1: open db connection/login
            // need to install nuget package (www.nuget.org)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySampleDB;Integrated Security=true";

            // step 2: send sql update statement
            // SQL Injection


            string sqlUpdate = $"update dept set dname = @dname, loc = @loc where deptno = @deptno";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@deptno";
            p1.Value = department.DepartmentNo;
            cmd.Parameters.Add(p1);

            cmd.Parameters.AddWithValue("@dname", department.DepartmentName);
            cmd.Parameters.AddWithValue("@loc", department.Location);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            // step 3: close db connection
            //catch (SqlException ex)
            //{
            //    //Log the exp. inform the db admin
            //    throw ex;
            //}
            finally { conn.Close(); }
        }
    }
}
