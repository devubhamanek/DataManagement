using System;

namespace Dm.Common.Models
{
    public class GetFinalDataList
    {
        public int? docId { get; set; }

        public string name { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int? parentCategoryId { get; set; }

        public int? categoryId1 { get; set; }

        public int? categoryId2 { get; set; }

        public int? categoryId3 { get; set; }

        public string year { get; set; }

        public string month { get; set; }

        public string createdBy { get; set; }

        public int pageSize { get; set; }

        public int pageIndex { get; set; }
        
        public DateTime? createdDate { get; set; }

    }
}
