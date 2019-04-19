namespace DataModel
{
    public class ProductImageViewModel
    {
        public int ProductId { get; set; }
        public int ProductImageId { get; set; }
        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }
    }
}