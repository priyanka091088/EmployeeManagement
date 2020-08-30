using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class MockDepartment
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;
        IList<Depart> departList = new List<Depart>();


        public IList<Depart> GetAllDepartment()
        {
           
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DepartCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetDepartList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Depart obj = new Depart();
                        obj.DepartId = Convert.ToInt32(_ds.Tables[0].Rows[i]["DepartId"]);
                        obj.DepartName = Convert.ToString(_ds.Tables[0].Rows[i]["DepartName"]);
                     

                        departList.Add(obj);
                    }
                }

            }


            return departList;
        }

        public void InsertDepartment(Depart model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DepartCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddDepart");
               // model.DepartId = departList.Max(x => x.DepartId) + 1;
                //cmd.Parameters.AddWithValue("@DepId", model.DepartId);
                cmd.Parameters.AddWithValue("@DepName", model.DepartName);
                cmd.ExecuteNonQuery();

            }
        }

        public Depart GetDepartById(int id)
        {
            var obj = new Depart();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DepartCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetDepById");
                cmd.Parameters.AddWithValue("@DepId", id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {

                    obj.DepartId = Convert.ToInt32(_ds.Tables[0].Rows[0]["DepartId"]);
                    obj.DepartName = Convert.ToString(_ds.Tables[0].Rows[0]["DepartName"]);
                   
                }

            }
             return obj;
        }

        public void UpdateDepartment(Depart model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DepartCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateDepart");
                cmd.Parameters.AddWithValue("@DepId", model.DepartId);
                cmd.Parameters.AddWithValue("@DepName", model.DepartName);

                cmd.ExecuteNonQuery();

            }

        }

        public void DeleteDepartment(int id)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DepartCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteDepart");
                cmd.Parameters.AddWithValue("@DepId", id);

                cmd.ExecuteNonQuery();

            }

        }
    }
}
