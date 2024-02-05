using System.Data.SqlClient;

namespace ManageDepartments.DataAccess
{
    public class DepartmentRepository : IDepartmentResository
    {
        public void DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Insert(Department department)
        {
            // step 1: open db connection/login
            // need to install nuget package (www.nuget.org)
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySampleDB;Integrated Security=true";
            conn.Open();
            // step 2: send sql insert statement
            string sqlInsert = $"insert into dept values({department.DepartmentNo},'{department.DepartmentName}','{department.Location}')";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.ExecuteNonQuery();

            // step 3: close db connection
            conn.Close();

        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
