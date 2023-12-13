using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using WebApplicationMVCTask1.Interface;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.DAL
{
    public class RegisterCls : RegisterInterface
    {
        private readonly string connection = Startup.StaticConfiguration["customData:Connectionstring"];
        public ResponseModel SignUpAction(RegisterUser objmodel)
        {

            ResponseModel res = new ResponseModel();
            RegisterUser User = new RegisterUser();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand checkUsernameCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_SignUp WHERE UserId = @UserId", con))
                    {
                        checkUsernameCmd.Parameters.AddWithValue("@Userid", objmodel.UserId);
                        int existingUserCount = (int)checkUsernameCmd.ExecuteScalar();

                        if (existingUserCount > 0)
                        {
                            res.status = false;
                            res.Message = "Userid already exists. Please choose a different userid.";
                        }
                        else
                        {

                            using (SqlCommand cmd = new SqlCommand("sp_SignUp", con))

                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Name", objmodel.Name);
                                cmd.Parameters.AddWithValue("@UserId", objmodel.UserId);
                                string encryptedPassword = EncryptPassword(objmodel.decryptedPassword);
                                cmd.Parameters.AddWithValue("@encryptedPassword", encryptedPassword);
                                cmd.Parameters.AddWithValue("@decryptedPassword", objmodel.decryptedPassword);
                                var id = cmd.ExecuteNonQuery();
                                if (id > 0)
                                {
                                    res.status = true;
                                    res.Message = "Data Saved Successfully";
                                }
                                else
                                {
                                    res.status = false;
                                    res.Message = "Please Check...Something Went wrong...!!!";

                                }
                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    res.status = false;
                    res.Message = "Error!!";
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

        private string EncryptPassword(string password)
        {
            string encryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        
        public ResponseModel CheckLogin(RegisterUser objmodel)
        {
            ResponseModel res = new ResponseModel();
           

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();                 
                    using (SqlCommand cmd = new SqlCommand("sp_validate_LoginDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                     
                        cmd.Parameters.AddWithValue("@UserId", objmodel.UserId);
                        cmd.Parameters.AddWithValue("@Name", objmodel.Name);
                        cmd.Parameters.AddWithValue("@decryptedPassword", objmodel.decryptedPassword);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                RegisterUser user = new RegisterUser
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    UserId = Convert.ToInt32(reader["UserId"])
                                };
                                
                                res.status = true;
                                res.Message = "Login successful";                               
                            }
                            else
                            {                              
                                res.status = false;
                                res.Message = "Login failed. Check your credentials.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.Message = "Error occurred during login.";
                Helper.WriteLog("The error is:" + ex);
            }

            return res;
        }

    }
}



