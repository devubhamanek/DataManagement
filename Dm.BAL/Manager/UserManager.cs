using Dm.Common.Models;
using Dm.Common.Models.Enum;
using Dm.DAL.UserRepository;
using System.Collections.Generic;

namespace Dm.BAL.UserManager
{
    public class UserManager
    {
        public readonly UserRepository repo = new UserRepository();

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserLogin AuthenticateUser(string Email, string Password)
        {
            return repo.AuthenticateUser(Email, Password);
        }

        //Registration
        public bool RegisterUser(Registration users)
        {
            return repo.RegisterUser(users);
        }

        //for forgot password
        public bool ForgotPassword(ForgotPassword forgot)
        {
            return repo.ForgotPassword(forgot);
        }

        // For Diaplay UserLIst
        public List<Registration> CategoryDetail(string Action)
        {
            List<Registration> returnvalue = repo.Registration(Action);
            return returnvalue;
        }

        //get user data
        public Registration profile(int id)
        {

            return repo.profile(id);
        }
        //post user data
        public bool editProfile(Registration editProfile)
        {
            return repo.EditProfile(editProfile);
        }

        //for Dropdown Category
        public List<Category> Category()
        {

            return repo.Category();
        }

        //for Dropdown Category1
        public List<Category1> Category1()
        {

            return repo.Category1();
        }

        //for Dropdown Category2
        public List<Category2> Category2()
        {

            return repo.Category2();
        }

        /// <summary>
        ///  for Dropdown Category3
        /// </summary>
        /// <returns></returns>
        public List<Category3> Category3()
        {

            return repo.Category3();
        }

        /// <summary>
        /// Common Repo.For Add All Category
        /// </summary>
        /// <param name="item"></param>
        /// <param name="levelEnum"></param>
        /// <returns></returns>
        public bool CategoryAdd(MasterMenu item, LevelEnum levelEnum)
        {
            return repo.CategoryAdd(item, levelEnum);
        }

        /// <summary>
        ///  Category3 Submit
        /// </summary>
        /// <param name="users"></param>
        /// <param name="levelEnum"></param>
        /// <returns></returns>
        public string GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);
        }

        /// <summary>
        /// Final Data Upload
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public bool FinalDataUpload(FinalDataUpload files)
        {
            return repo.FinalDataUpload(files);
        }


        /// <summary>
        /// yearList
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<YearTree> yearList()
        {
            return repo.yearList();
        }

        /// <summary>
        /// MonthList
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<YearTree> MonthList(int id)
        {
            return repo.MonthList(id);
        }

        /// <summary>
        /// GetFinalDataList
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<GetFinalDataList> GetFinalDataList(GetFinalDataList Data)
        {
            return repo.GetFinalDataList(Data);
        }

        /// <summary>
        /// MonthList
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<GetFinalDataList> EditInwardFile(int id)
        {
            return repo.EditInwardFile(id);
        }

        //UpdateInwardFile
        public bool UpdateInwardFile(FinalDataUpload files)
        {
            return repo.UpdateInwardFile(files);
        }

        //SubCategorydelete
        public bool DeleteInwardFile(int Id)
        {
            return repo.DeleteInwardFile(Id);
        }

        //for Pagination
        //public List<GetFinalDataList> Pagination(int pageIndex, int pageSize)
        //{
        //    return repo.Pagination(pageIndex, pageSize);
            
        //}
    }

}
