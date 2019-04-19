namespace DataModel
{
    public class HomeImageViewModel
    {
        public int HomeImageId { get; set; }
        public string HomeImageDescription { get; set; }
        public string FileName { get; set; }
        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }
    }
}