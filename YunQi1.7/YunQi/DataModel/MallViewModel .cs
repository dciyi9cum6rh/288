using System.Collections.Generic;

namespace DataModel
{
    public class MallViewModel
    {
        public List<MallImageViewModel> MallImage { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
        public int MemberLevelId { get; set; }
    }
}