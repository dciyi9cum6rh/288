namespace DataModel
{
    public class UploadFile
    {
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }
        public int DisplayOrder { get; set; }
    }
}