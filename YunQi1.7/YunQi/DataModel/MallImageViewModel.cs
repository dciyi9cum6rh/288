namespace DataModel
{
    public class MallImageViewModel
    {
        public int MallImageId { get; set; }
        public string MallImageDescription { get; set; }
        public string FileName { get; set; }
        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }
    }
}