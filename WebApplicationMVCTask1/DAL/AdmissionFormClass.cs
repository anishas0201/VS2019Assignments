using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVCTask1.Interface;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.DAL
{
    public class AdmissionFormClass:AdmissionFormInterface
    {
        private readonly string connection = Startup.StaticConfiguration["customData:Connectionstring"];
        ResponseModel res = new ResponseModel();
        public ResponseModel SaveForm(AdmissionFormData form)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SaveForm", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CollegeName", form.CollegeName);
                        cmd.Parameters.AddWithValue("@StudentName", form.StudentName);
                        cmd.Parameters.AddWithValue("@BranchName", form.BranchName);
                        cmd.Parameters.AddWithValue("@RoleDesignation", form.RoleDesignation);                     
                        cmd.Parameters.AddWithValue("@AdmissionDate", form.AdmissionDate);
                        cmd.Parameters.AddWithValue("@CollegeFees", form.CollegeFees);
                        cmd.Parameters.AddWithValue("@IsPaymentDone", form.IsPaymentDone);
                        cmd.Parameters.AddWithValue("@IsActive", form.IsActive);
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


        public List<AdmissionFormData> AdmissionList()
        {

            ResponseModel res = new ResponseModel();
            List<AdmissionFormData> result = new List<AdmissionFormData>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetFormList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                AdmissionFormData user = new AdmissionFormData();
                                user.AdmissionId = (int)reader["AdmissionId"];
                                user.CollegeName = (string)reader["CollegeName"];
                                user.StudentName = (string)reader["FirstName"];
                                user.BranchName = (string)reader["BranchName"];
                                user.RoleDesignation = (string)reader["RoleDesignation"];                             
                                user.AdmissionDate = (DateTime)reader["AdmissionDate"];
                                user.CollegeFees = (int)reader["CollegeFees"];
                                user.IsPaymentDone = (Boolean)reader["IsPaymentDone"];
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


        public AdmissionFormData GetCollegebyId(int AdmissionId)
        {
            ResponseModel res = new ResponseModel();
            AdmissionFormData form = new AdmissionFormData();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_get_CollegeDetailsbyId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                form.AdmissionId = string.IsNullOrEmpty(reader["AdmissionId"].ToString()) ? 0 : Convert.ToInt32(reader["AdmissionId"]);
                                form.CollegeName = string.IsNullOrWhiteSpace(reader["CollegeName"].ToString()) ? "" : reader["CollegeName"].ToString();
                                form.StudentName = string.IsNullOrWhiteSpace(reader["StudentName"].ToString()) ? "" : reader["StudentName"].ToString();
                                form.BranchName = string.IsNullOrWhiteSpace(reader["BranchName"].ToString()) ? "" : reader["BranchName"].ToString();
                                form.RoleDesignation = string.IsNullOrWhiteSpace(reader["RoleDesignation"].ToString()) ? "" : reader["RoleDesignation"].ToString();                                
                                form.AdmissionDate = string.IsNullOrWhiteSpace(reader["AdmissionDate"].ToString()) ? Convert.ToDateTime(DateTime.Now.ToString("MM-DD-yyyy")) : Convert.ToDateTime(reader["AdmissionDate"]);
                                form.CollegeFees = string.IsNullOrEmpty(reader["CollegeFees"].ToString()) ? 0 : Convert.ToInt32(reader["CollegeFees"]);
                                form.IsPaymentDone = string.IsNullOrWhiteSpace(reader["IsPaymentDone"].ToString()) ? false : Convert.ToBoolean(reader["IsPaymentDone"].ToString());
                                form.IsActive = string.IsNullOrWhiteSpace(reader["IsActive"].ToString()) ? false : Convert.ToBoolean(reader["IsActive"].ToString());



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
            return form;

        }


        public ResponseModel UpdateCollegeDetail(AdmissionFormData form)
        {

            ResponseModel res = new ResponseModel();

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Update_CollegeDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdmissionId", form.AdmissionId);
                        cmd.Parameters.AddWithValue("@CollegeName", form.CollegeName);
                        cmd.Parameters.AddWithValue("@StudentName", form.StudentName);
                        cmd.Parameters.AddWithValue("@BranchName", form.BranchName);
                        cmd.Parameters.AddWithValue("@RoleDesignation", form.RoleDesignation);
                        cmd.Parameters.AddWithValue("@AdmissionDate", form.AdmissionDate);
                        cmd.Parameters.AddWithValue("@CollegeFees", form.CollegeFees);
                        cmd.Parameters.AddWithValue("@IsPaymentDone", form.IsPaymentDone);
                        cmd.Parameters.AddWithValue("@IsActive", form.IsActive);


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


        public ResponseModel DeleteCollegeDetail(int AdmissionId)
        {
            ResponseModel res = new ResponseModel();
            using (SqlConnection con = new SqlConnection(connection))
            {

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_delete_CollegeDetailById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);
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



        public List<AdmissionFormData> SearchByDate(string fromDate, string toDate)
        {
            List<AdmissionFormData> result = new List<AdmissionFormData>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SearchByDate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(fromDate));
                        cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(toDate));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AdmissionFormData user = new AdmissionFormData
                                {
                                    AdmissionId = Convert.ToInt32(reader["AdmissionId"]),
                                    CollegeName = reader["CollegeName"].ToString(),
                                    StudentName = reader["FirstName"].ToString(),
                                    BranchName = reader["BranchName"].ToString(),
                                    RoleDesignation = reader["RoleDesignation"].ToString(),
                                    AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]),
                                    CollegeFees = Convert.ToInt32(reader["CollegeFees"]),
                                    IsPaymentDone = Convert.ToBoolean(reader["IsPaymentDone"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };

                                result.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Error occurred during date search.";
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



    }
}
