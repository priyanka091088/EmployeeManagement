using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace EmployeeManagement.Models
{
    public class MockEmployee
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public IList<Employee> GetEmployeeList()
        {
            IList<Employee> getEmpList = new List<Employee>();
            _ds = new DataSet();

            using(SqlConnection con=new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeCrud",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if(_ds.Tables.Count>0)
                {
                    for(int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Employee obj = new Employee();
                        obj.Eid = Convert.ToInt32(_ds.Tables[0].Rows[i]["Eid"]);
                        obj.Name = Convert.ToString(_ds.Tables[0].Rows[i]["Name"]);
                        obj.Surname = Convert.ToString(_ds.Tables[0].Rows[i]["Surname"]);
                        obj.Address = Convert.ToString(_ds.Tables[0].Rows[i]["Address"]);
                        obj.Qualification = Convert.ToString(_ds.Tables[0].Rows[i]["Qualification"]);
                        obj.ContactNo = Convert.ToString(_ds.Tables[0].Rows[i]["ContactNo"]);

                        getEmpList.Add(obj);
                    }
                }

            }

            return getEmpList;   
        }


        public void InsertEmployee(Employee model)
        {
            using(SqlConnection con=new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeCrud",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@EmpName", model.Name);
                cmd.Parameters.AddWithValue("@EmpSurname", model.Surname);
                cmd.Parameters.AddWithValue("@EmpAddress", model.Address);
                cmd.Parameters.AddWithValue("@EmpQualification", model.Qualification);
                cmd.Parameters.AddWithValue("@EmpContactNo", model.ContactNo);
                cmd.ExecuteNonQuery();

            }
        }        


        public Employee GetEmployeeById(int id)
        {
            var obj = new Employee();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpById");
                cmd.Parameters.AddWithValue("@EmpId", id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count>0)
                {
                    
                        obj.Eid = Convert.ToInt32(_ds.Tables[0].Rows[0]["Eid"]);
                        obj.Name = Convert.ToString(_ds.Tables[0].Rows[0]["Name"]);
                        obj.Surname = Convert.ToString(_ds.Tables[0].Rows[0]["Surname"]);
                        obj.Address = Convert.ToString(_ds.Tables[0].Rows[0]["Address"]);
                        obj.Qualification = Convert.ToString(_ds.Tables[0].Rows[0]["Qualification"]);
                        obj.ContactNo = Convert.ToString(_ds.Tables[0].Rows[0]["ContactNo"]);

                 }

            }


            return obj;
        }


        public void UpdateEmp(Employee model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmployee");
                cmd.Parameters.AddWithValue("@EmpId", model.Eid);
                cmd.Parameters.AddWithValue("@EmpName", model.Name);
                cmd.Parameters.AddWithValue("@EmpSurname", model.Surname);
                cmd.Parameters.AddWithValue("@EmpAddress", model.Address);
                cmd.Parameters.AddWithValue("@EmpQualification", model.Qualification);
                cmd.Parameters.AddWithValue("@EmpContactNo", model.ContactNo);
                
                cmd.ExecuteNonQuery();

            }

        }


        public void DeleteEmp(int id)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeCrud",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteEmployee");
                cmd.Parameters.AddWithValue("@EmpId", id);
               
                cmd.ExecuteNonQuery();

            }

        }
    }
}