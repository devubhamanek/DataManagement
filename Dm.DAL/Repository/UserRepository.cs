using Dm.Common.Models;
using Dm.Common.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dm.DAL.UserRepository
{

    public class UserRepository
    {
        /// <summary>
        /// For the login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserLogin AuthenticateUser(string Email, string Password)
        {

            UserLogin objUsers = new UserLogin();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@email", Email);
            // string x = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
            objParameter[1] = new SqlParameter("@password", Password);
            SqlHelper.Fill(dtUser, "[Login]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {

                    objUsers.UserID = Convert.ToInt32(row["UserID"]);
                    objUsers.roleId = Convert.ToInt32(row["roleId"]);
                    objUsers.UserName = Convert.ToString(row["UserName"]);
                    objUsers.Email = Convert.ToString(row["Email"]);
                }
            }
            return objUsers;
        }


        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>                
        public bool RegisterUser(Registration users)
        {
            Registration objUsers = new Registration();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@email", users.Email);
            objParameter[1] = new SqlParameter("@userName", users.UserName);
            objParameter[2] = new SqlParameter("@password", users.Password);
            objParameter[3] = new SqlParameter("@status", true);
            objParameter[4] = new SqlParameter("@roleId", "2");
            objParameter[5] = new SqlParameter("@createdBy", "1");
            //objParameter[6] = new SqlParameter("@createdDate", users.createdDate);
            int insertCount = SqlHelper.ExecuteNonQuery("[usp_AddUsers]", objParameter);

            if (insertCount > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Forgot Paasword
        /// </summary>
        /// <param name="forgot"></param>
        /// <returns></returns>
        public bool ForgotPassword(ForgotPassword forgot)
        {
            try
            {
                DataTable dtUser = new DataTable();
                SqlParameter[] objParameter = new SqlParameter[2];
                objParameter[0] = new SqlParameter("@email", forgot.Email);
                objParameter[1] = new SqlParameter("@password", forgot.Password);
                int updateCount = SqlHelper.ExecuteNonQuery("[ResetPassword]", objParameter);
                if (updateCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


        /// <summary>
        /// Register User List
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<Registration> Registration(string Action)
        {
            List<Registration> UserList = new List<Registration>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "SELECT");
            SqlHelper.Fill(dtCategory, "[AdminControl]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    Registration objUser = new Registration();
                    {
                        objUser.UserID = Convert.ToInt32(row["UserID"]);
                        objUser.roleId = Convert.ToInt32(row["roleId"]);
                        objUser.UserName = Convert.ToString(row["UserName"]);
                        objUser.Email = Convert.ToString(row["Email"]);
                        objUser.Password = Convert.ToString(row["Password"]);
                        objUser.Status = Convert.ToBoolean(row["Status"]);
                        objUser.createdBy = Convert.ToInt32(row["createdBy"]);
                        objUser.createdDate = Convert.ToDateTime(row["createdDate"]);

                    };

                    UserList.Add(objUser);
                }

            }
            return UserList;
        }


        /// <summary>
        /// Get Profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Registration profile(int id)
        {
            Registration objUser = new Registration();
            DataTable dtDetail = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserID", id);
            SqlHelper.Fill(dtDetail, "usp_getProfile", objParameter);
            if (dtDetail != null && dtDetail.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetail.Rows)
                {
                    objUser.UserID = Convert.ToInt32(row["UserID"]);
                    objUser.UserName = Convert.ToString(row["UserName"]);
                    objUser.Email = Convert.ToString(row["Email"]);
                    objUser.Status = Convert.ToBoolean(row["Status"]);

                }
            }
            return objUser;
        }


        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public bool EditProfile(Registration Profile)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@userId", Profile.UserID);
            objParameter[1] = new SqlParameter("@userName", Profile.UserName);
            objParameter[2] = new SqlParameter("@email", Profile.Email);
            objParameter[3] = new SqlParameter("@Status", Profile.Status);

            int count = SqlHelper.ExecuteNonQuery("[usp_updateProfile]", objParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        ///Category View In Dropdown 
        /// </summary>
        /// <returns></returns> 
        public List<Category> Category()
        {
            List<Category> CategoryList = new List<Category>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "select_Cat");
            SqlHelper.Fill(dtCategory, "[usp_categoryControl]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    Category objCategory = new Category
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        name = Convert.ToString(row["name"]),
                    };

                    CategoryList.Add(objCategory);
                }
            }
            return CategoryList;
        }

        /// <summary>
        ///Category1 View In Dropdown  
        /// </summary>
        /// <returns></returns>
        public List<Category1> Category1()
        {
            List<Category1> CategoryList = new List<Category1>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "select_Cat1");
            SqlHelper.Fill(dtCategory, "[usp_categoryControl]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    Category1 objCategory = new Category1
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        name = Convert.ToString(row["name"]),
                    };
                    CategoryList.Add(objCategory);
                }
            }
            return CategoryList;
        }

        /// <summary>
        ///Category2 View In Dropdown  
        /// </summary>
        /// <returns></returns> 
        public List<Category2> Category2()
        {
            List<Category2> CategoryList = new List<Category2>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "select_Cat2");
            SqlHelper.Fill(dtCategory, "[usp_categoryControl]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    Category2 objCategory = new Category2
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        name = Convert.ToString(row["name"]),
                    };
                    CategoryList.Add(objCategory);
                }
            }
            return CategoryList;
        }

        /// <summary>
        ///Category3 View In Dropdown  
        /// </summary>
        /// <returns></returns> 
        public List<Category3> Category3()
        {
            List<Category3> CategoryList = new List<Category3>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "select_Cat3");
            SqlHelper.Fill(dtCategory, "[usp_categoryControl]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    Category3 objCategory = new Category3
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        name = Convert.ToString(row["name"]),
                    };

                    CategoryList.Add(objCategory);
                }
            }
            return CategoryList;
        }

        /// <summary>
        /// Add New Category
        /// </summary>//Common Repo.For Add All Category 
        /// <param name="users"></param>
        /// <returns></returns>
        public bool CategoryAdd(MasterMenu item, LevelEnum levelEnum)
        {
            Category objUsers = new Category();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[3];
            if (!string.IsNullOrEmpty(item.parentCategoryId))
            { objParameter[0] = new SqlParameter("@parentCategoryId", item.parentCategoryId); }
            else { objParameter[0] = new SqlParameter("@parentCategoryId", DBNull.Value); }
            objParameter[1] = new SqlParameter("@level", (int)levelEnum);
            objParameter[2] = new SqlParameter("@name", item.name);
            int insertCount = SqlHelper.ExecuteNonQuery("[usp_AddCategory]", objParameter);

            if (insertCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inbound Get Submit Catgory3 Data Using ID 
        /// </summary> 
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCategoryById(int id)
        {
            DataTable dtDetail = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Id", id);
            SqlHelper.Fill(dtDetail, "usp_getCategoryById", objParameter);
            if (dtDetail != null && dtDetail.Rows.Count > 0)
            {
                return dtDetail.Rows[0][0].ToString();
            }
            return "";
        }


        /// <summary>
        ///FinalDataUpload 
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool FinalDataUpload(FinalDataUpload users)
        {
            FinalDataUpload objUsers = new FinalDataUpload();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[10];
            objParameter[0] = new SqlParameter("@parentCategoryId", users.parentCategoryId);
            objParameter[1] = new SqlParameter("@categoryId1", users.categoryId1);
            objParameter[2] = new SqlParameter("@categoryId2", users.categoryId2);
            objParameter[3] = new SqlParameter("@categoryId3", users.categoryId3);
            objParameter[4] = new SqlParameter("@name", users.name);
            objParameter[5] = new SqlParameter("@fileName", users.FileName);
            objParameter[6] = new SqlParameter("@filePath", users.FilePath);
            objParameter[7] = new SqlParameter("@createdBy", users.createdBy);
            objParameter[8] = new SqlParameter("@year", users.year);
            objParameter[9] = new SqlParameter("@month", users.month);

            int insertCount = SqlHelper.ExecuteNonQuery("[usp_finalDataUpload]", objParameter);

            if (insertCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// yearList
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<YearTree> yearList()
        {
            List<YearTree> yearList = new List<YearTree>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Action", "select_Year");
            SqlHelper.Fill(dtCategory, "[usp_getYearTree]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    YearTree objCategory = new YearTree
                    {
                        id = Convert.ToInt32(row["id"]),
                        year = Convert.ToString(row["yearName"]),
                    };

                    yearList.Add(objCategory);
                }
            }
            return yearList;
        }

        /// <summary>
        /// GET Month Name
        /// </summary>
        /// <returns></returns>
        public List<YearTree> MonthList(int id)
        {
            List<YearTree> MonthList = new List<YearTree>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@Action", "select_Month");
            objParameter[1] = new SqlParameter("@id", id);
            SqlHelper.Fill(dtCategory, "[usp_getYearTree]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    YearTree objCategory = new YearTree
                    {
                        //id = Convert.ToInt32(row["id"]),
                        month = Convert.ToString(row["yearname"]),

                    };

                    MonthList.Add(objCategory);
                }
            }
            return MonthList;
        }

        /// <summary>
        /// GetFinalDataList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<GetFinalDataList> GetFinalDataList(GetFinalDataList Data)
        {
            List<GetFinalDataList> FinalDataList = new List<GetFinalDataList>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@parentCategoryId", Data.parentCategoryId);
            objParameter[1] = new SqlParameter("@categoryId1", Data.categoryId1);
            objParameter[2] = new SqlParameter("@categoryId2", Data.categoryId2);
            objParameter[3] = new SqlParameter("@categoryId3", Data.categoryId3);
            objParameter[4] = new SqlParameter("@year", Data.year);
            objParameter[5] = new SqlParameter("@month", Data.month);
            objParameter[6] = new SqlParameter("@pageIndex", Data.pageIndex);
            objParameter[7] = new SqlParameter("@pageSize", Data.pageSize);
            SqlHelper.Fill(dtCategory, "[usp_getFinaldata]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    GetFinalDataList objCategory = new GetFinalDataList
                    {
                        docId = Convert.ToInt32(row["docId"]),
                        FileName = Convert.ToString(row["fileName"]),
                        FilePath = Convert.ToString(row["filePath"]),
                        createdDate = Convert.ToDateTime(row["createdDate"]),
                        createdBy = Convert.ToString(row["createdBy"]),
                        name = Convert.ToString(row["name"]),

                    };

                    FinalDataList.Add(objCategory);
                }
            }
            return FinalDataList;
        }


        /// <summary>
        /// EditInwardFile 
        /// </summary>
        /// <returns></returns>
        public List<GetFinalDataList> EditInwardFile(int id)
        {
            List<GetFinalDataList> EditInwardFile = new List<GetFinalDataList>();
            DataTable dtCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@Action", "Edit_File");
            objParameter[1] = new SqlParameter("@docId", id);
            SqlHelper.Fill(dtCategory, "[usp_editInwardFile]", objParameter);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    GetFinalDataList objCategory = new GetFinalDataList
                    {
                        docId = Convert.ToInt32(row["docId"]),
                        FileName = Convert.ToString(row["fileName"]),
                        FilePath = Convert.ToString(row["filePath"]),
                        createdDate = Convert.ToDateTime(row["createdDate"]),
                        createdBy = Convert.ToString(row["createdBy"]),
                        name = Convert.ToString(row["name"]),
                        year = Convert.ToString(row["year"]),
                        month = Convert.ToString(row["month"]),

                    };

                    EditInwardFile.Add(objCategory);
                }
            }
            return EditInwardFile;
        }

        /// <summary>
        ///  UpdateInwardFile
        /// </summary>
        /// <param name="UpdateInwardFile"></param>
        /// <returns></returns>
        public bool UpdateInwardFile(FinalDataUpload files)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@Action", "Update_File");
            objParameter[1] = new SqlParameter("@docId", files.docId);
            objParameter[2] = new SqlParameter("@fileName", files.FileName);
            objParameter[3] = new SqlParameter("@filePath", files.FilePath);
            objParameter[4] = new SqlParameter("@name", files.name);
            int count = SqlHelper.ExecuteNonQuery("[usp_editInwardFile]", objParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// DeleteInwardFile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteInwardFile(int id)
        {

            DataTable dtSubCategory = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@docId", id);
            objParameter[1] = new SqlParameter("@Action", "Delete_File");
            int count = SqlHelper.ExecuteNonQuery("[usp_editInwardFile]", objParameter);
            if (count > 0)

            {
                return true;
            }
            else
            {

                return false;
            }
        }


        /// <summary>
        /// Pagination
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        //public List<GetFinalDataList> Pagination(int pageSize, int pageIndex)
        //{
        //    List<GetFinalDataList> Pagination = new List<GetFinalDataList>();
        //    DataTable dtCategory = new DataTable();
        //    SqlParameter[] objParameter = new SqlParameter[2];
        //    objParameter[0] = new SqlParameter("@pageIndex", pageIndex);
        //    objParameter[1] = new SqlParameter("@pageSize", pageSize);
        //    SqlHelper.Fill(dtCategory, "[usp_Pagination]", objParameter);
        //    if (dtCategory != null && dtCategory.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dtCategory.Rows)
        //        {
        //            GetFinalDataList objCategory = new GetFinalDataList();
        //            {
        //                objCategory.docId = Convert.ToInt32(row["docId"]);
        //                objCategory.FileName = Convert.ToString(row["fileName"]);
        //                objCategory.createdDate = Convert.ToDateTime(row["createdDate"]);
        //                objCategory.createdBy = Convert.ToString(row["createdBy"]);
        //                objCategory.name = Convert.ToString(row["name"]);
                       

        //            };

        //            Pagination.Add(objCategory);
        //        }

        //    }
        //    return Pagination;
        //}
    }
}
