using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.DAL
{
    public class DropDownClass
    {
        private readonly string connection = Startup.StaticConfiguration["customData:Connectionstring"];
        public List<RoleList> GetDesignationList()
        {
            List<RoleList> designation = new List<RoleList>();
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select RoleId,RoleDesignation from tbl_RoleMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RoleList u = new RoleList();
                                u.RoleDesignation = string.IsNullOrWhiteSpace(reader["RoleDesignation"].ToString()) ? "" : reader["RoleDesignation"].ToString();
                                u.RoleId = string.IsNullOrEmpty(reader["RoleId"].ToString()) ? 0 : Convert.ToInt32(reader["RoleId"]);
                                designation.Add(u);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return designation;
            }

        }


        public List<DepartmentList> GetBranchList()
        {
            List<DepartmentList> branch = new List<DepartmentList>();
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select BranchId,BranchName from tbl_DepartmentMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DepartmentList u = new DepartmentList();
                                u.BranchName = string.IsNullOrWhiteSpace(reader["BranchName"].ToString()) ? "" : reader["BranchName"].ToString();
                                u.BranchId = string.IsNullOrEmpty(reader["BranchId"].ToString()) ? 0 : Convert.ToInt32(reader["BranchId"]);
                                branch.Add(u);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return branch;
            }

        }


        public List<StudentList> GetNameList()
        {
            List<StudentList> name = new List<StudentList>();
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select StudentId,FirstName from tbl_StudentMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StudentList u = new StudentList();
                                u.FirstName = string.IsNullOrWhiteSpace(reader["FirstName"].ToString()) ? "" : reader["FirstName"].ToString();
                                u.StudentId = string.IsNullOrEmpty(reader["StudentId"].ToString()) ? 0 : Convert.ToInt32(reader["StudentId"]);
                                name.Add(u);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return name;
            }

        }

    }
}
