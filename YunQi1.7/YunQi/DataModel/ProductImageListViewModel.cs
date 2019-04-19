namespace DataModel
{
    public class ProductImageListViewModel
    {
        public int ProductId { get; set; }
        public int ProductImageId { get; set; }
        public bool IsMajor { get; set; }
        public string FileName { get; set; }
        public int DisplayOrder { get; set; }
    }
}