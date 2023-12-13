using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplicationMVCTask1.Interface;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.DAL
{
    public class BodyCls : BodyInterface
    {
        private readonly string connection = Startup.StaticConfiguration["customData:Connectionstring"];
        ResponseModel res = new ResponseModel();


        public ResponseModel SaveRole(RoleUser roleuser)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SaveRoleUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleName", roleuser.RoleName);
                        cmd.Parameters.AddWithValue("@RoleDesignation", roleuser.RoleDesignation);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", roleuser.IsActive);
                        var Id = cmd.ExecuteNonQuery();
                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Saved Successfully!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;
        }

        public List<RoleUser> GetRoleList()
        {

            ResponseModel res = new ResponseModel();
            List<RoleUser> result = new List<RoleUser>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_RoleMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RoleUser user = new RoleUser();
                                user.RoleId = (int)reader["RoleId"];
                                user.RoleName = (string)reader["RoleName"];
                                user.RoleDesignation = (string)reader["RoleDesignation"];
                                user.CreatedDate = (DateTime)reader["CreatedDate"];
                                //  user.Date = Convert.ToDateTime(reader["Date"]).Date;                             
                                user.IsActive = (Boolean)reader["IsActive"];
                                result.Add(user);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return result;
        }

        public RoleUser GetRolebyId(int RoleId)
        {
            ResponseModel res = new ResponseModel();
            RoleUser user = new RoleUser();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_get_RolebyId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", RoleId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user.RoleId = string.IsNullOrEmpty(reader["RoleId"].ToString()) ? 0 : Convert.ToInt32(reader["RoleId"]);
                                user.RoleName = string.IsNullOrWhiteSpace(reader["RoleName"].ToString()) ? "" : reader["RoleName"].ToString();
                                user.RoleDesignation = string.IsNullOrWhiteSpace(reader["RoleDesignation"].ToString()) ? "" : reader["RoleDesignation"].ToString();
                                user.CreatedDate = string.IsNullOrWhiteSpace(reader["CreatedDate"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("DD-MM-yyyy")) : Convert.ToDateTime(reader["CreatedDate"]);
                                user.IsActive = string.IsNullOrWhiteSpace(reader["IsActive"].ToString()) ? false : Convert.ToBoolean(reader["IsActive"].ToString());



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


            }
            return user;

        }

        public ResponseModel DeleteRole(int RoleId)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_delete_RoleById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", RoleId);
                        var id = cmd.ExecuteNonQuery();
                        if (id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Deleted Successfully..!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "Please Check...Something Went wrong...!!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Exception Occure..!!";
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;

        }

        public ResponseModel UpdateRole(RoleUser roleuser)
        {

            ResponseModel res = new ResponseModel();

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Update_RoleMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", roleuser.RoleId);
                        cmd.Parameters.AddWithValue("@RoleName", roleuser.RoleName);
                        cmd.Parameters.AddWithValue("@RoleDesignation", roleuser.RoleDesignation);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", roleuser.IsActive);

                        var Id = cmd.ExecuteNonQuery();

                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Updated Successfully!!";

                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }

                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return res;
        }



        public ResponseModel SaveDepartment(DepartmentUser depuser)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SaveDepartmentUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchName", depuser.BranchName);
                        cmd.Parameters.AddWithValue("@HODName", depuser.HODName);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", depuser.IsActive);
                        var Id = cmd.ExecuteNonQuery();
                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Saved Successfully!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;
        }

        public List<DepartmentUser> GetDepartmentList()
        {

            ResponseModel res = new ResponseModel();
            List<DepartmentUser> result = new List<DepartmentUser>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_DepartmentMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DepartmentUser user = new DepartmentUser();
                                user.BranchId = (int)reader["BranchId"];
                                user.BranchName = (string)reader["BranchName"];
                                user.HODName = (string)reader["HODName"];
                                user.CreatedDate = (DateTime)reader["CreatedDate"];
                                //  user.Date = Convert.ToDateTime(reader["Date"]).Date;                             
                                user.IsActive = (Boolean)reader["IsActive"];
                                result.Add(user);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return result;
        }

        public DepartmentUser GetDepartmentbyId(int BranchId)
        {
            ResponseModel res = new ResponseModel();
            DepartmentUser user = new DepartmentUser();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_get_DepartmentbyId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchId", BranchId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user.BranchId = string.IsNullOrEmpty(reader["BranchId"].ToString()) ? 0 : Convert.ToInt32(reader["BranchId"]);
                                user.BranchName = string.IsNullOrWhiteSpace(reader["BranchName"].ToString()) ? "" : reader["BranchName"].ToString();
                                user.HODName = string.IsNullOrWhiteSpace(reader["HODName"].ToString()) ? "" : reader["HODName"].ToString();

                                user.CreatedDate = string.IsNullOrWhiteSpace(reader["CreatedDate"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("DD-MM-yyyy")) : Convert.ToDateTime(reader["CreatedDate"]);

                                user.IsActive = string.IsNullOrWhiteSpace(reader["IsActive"].ToString()) ? false : Convert.ToBoolean(reader["IsActive"].ToString());

                                //var z=user.PrDate.ToString("dd MM yyyy");



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


            }
            return user;

        }

        public ResponseModel DeleteDepartment(int BranchId)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_delete_DepartmentById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchId", BranchId);
                        var id = cmd.ExecuteNonQuery();
                        if (id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Deleted Successfully..!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "Please Check...Something Went wrong...!!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Exception Occure..!!";
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;

        }

        public ResponseModel UpdateDepartment(DepartmentUser depuser)
        {

            ResponseModel res = new ResponseModel();

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Update_DepartmentMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchId", depuser.BranchId);
                        cmd.Parameters.AddWithValue("@BranchName", depuser.BranchName);
                        cmd.Parameters.AddWithValue("@HODName", depuser.HODName);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", depuser.IsActive);

                        var Id = cmd.ExecuteNonQuery();

                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Updated Successfully!!";

                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }

                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return res;
        }



        public ResponseModel SaveStudent(StudentUser stuser)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SaveStudentUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", stuser.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", stuser.LastName);
                        cmd.Parameters.AddWithValue("@Session", stuser.Session);
                        cmd.Parameters.AddWithValue("@Email", stuser.Email);
                        cmd.Parameters.AddWithValue("@ContactNo", stuser.ContactNo);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", stuser.IsActive);
                        cmd.Parameters.AddWithValue("@IsDeleted", stuser.IsDeleted);
                        var Id = cmd.ExecuteNonQuery();
                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Saved Successfully!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;
        }

        public List<StudentUser> GetStudenttList()
        {

            ResponseModel res = new ResponseModel();
            List<StudentUser> result = new List<StudentUser>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_StudentMaster", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StudentUser user = new StudentUser();
                                user.StudentId = (int)reader["StudentId"];
                                user.FirstName = (string)reader["FirstName"];
                                user.LastName = (string)reader["LastName"];
                                user.Session = (string)reader["Session"];
                                user.Email = (string)reader["Email"];
                                user.ContactNo = (int)reader["ContactNo"];
                                user.CreatedDate = (DateTime)reader["CreatedDate"];
                                //  user.Date = Convert.ToDateTime(reader["Date"]).Date;                             
                                user.IsActive = (Boolean)reader["IsActive"];
                                user.IsDeleted = (Boolean)reader["IsDeleted"];
                                result.Add(user);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return result;
        }

        public StudentUser GetStudentbyId(int StudentId)
        {
            ResponseModel res = new ResponseModel();
            StudentUser user = new StudentUser();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_get_StudentbyId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", StudentId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user.StudentId = string.IsNullOrEmpty(reader["StudentId"].ToString()) ? 0 : Convert.ToInt32(reader["StudentId"]);
                                user.FirstName = string.IsNullOrWhiteSpace(reader["FirstName"].ToString()) ? "" : reader["FirstName"].ToString();
                                user.LastName = string.IsNullOrWhiteSpace(reader["LastName"].ToString()) ? "" : reader["LastName"].ToString();
                                user.Session = string.IsNullOrWhiteSpace(reader["Session"].ToString()) ? "" : reader["Session"].ToString();
                                user.Email = string.IsNullOrWhiteSpace(reader["Email"].ToString()) ? "" : reader["Email"].ToString();
                                user.ContactNo = string.IsNullOrEmpty(reader["ContactNo"].ToString()) ? 0 : Convert.ToInt32(reader["ContactNo"]);
                                user.CreatedDate = string.IsNullOrWhiteSpace(reader["CreatedDate"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("DD-MM-yyyy")) : Convert.ToDateTime(reader["CreatedDate"]);

                                user.IsActive = string.IsNullOrWhiteSpace(reader["IsActive"].ToString()) ? false : Convert.ToBoolean(reader["IsActive"].ToString());
                                user.IsDeleted = string.IsNullOrWhiteSpace(reader["IsDeleted"].ToString()) ? false : Convert.ToBoolean(reader["IsDeleted"].ToString());
                                //var z=user.PrDate.ToString("dd MM yyyy");



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


            }
            return user;

        }

        public ResponseModel DeleteStudent(int StudentId)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_delete_StudentById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", StudentId);
                        var id = cmd.ExecuteNonQuery();
                        if (id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Deleted Successfully..!!";
                        }
                        else
                        {
                            res.status = false;
                            res.Message = "Please Check...Something Went wrong...!!!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Exception Occure..!!";
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return res;

        }

        public ResponseModel UpdateStudent(StudentUser stuser)
        {

            ResponseModel res = new ResponseModel();

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Update_StudentMaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", stuser.StudentId);
                        cmd.Parameters.AddWithValue("@FirstName", stuser.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", stuser.LastName);
                        cmd.Parameters.AddWithValue("@Session", stuser.Session);
                        cmd.Parameters.AddWithValue("@Email", stuser.Email);
                        cmd.Parameters.AddWithValue("@ContactNo", stuser.ContactNo);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@IsActive", stuser.IsActive);
                        cmd.Parameters.AddWithValue("@IsDeleted", stuser.IsDeleted);


                        var Id = cmd.ExecuteNonQuery();

                        if (Id > 0)
                        {
                            res.status = true;
                            res.Message = "Data Updated Successfully!!";

                        }
                        else
                        {
                            res.status = false;
                            res.Message = "oops!! Error Occured!!";
                        }

                    }

                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Errorr!!!";
                    Helper.WriteLog("The error is:" + ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return res;
        }






    }
}
