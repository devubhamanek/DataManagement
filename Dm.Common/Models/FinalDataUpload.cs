using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dm.Common.Models
{
    public class FinalDataUpload 
    {
        public int? docId { get; set; }

        public int? parentCategoryId { get; set; }

        public int? categoryId1 { get; set; }

        public int? categoryId2 { get; set; }

        public int? categoryId3 { get; set; }
       
        public string name { get; set; }

        public string year { get; set; }

        public string month { get; set; }

        //FileGet
      
       
        public IFormFile fileName { get; set; }
        public string filePath { get; set; }
        //FilePost
      
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public string createdBy { get; set; }

        public DateTime? createdDate { get; set; }

        
    }
}
