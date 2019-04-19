namespace DataModel
{
    public class OneProductCategoryViewModel
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductCategoryDescription { get; set; }
        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }
    }
}