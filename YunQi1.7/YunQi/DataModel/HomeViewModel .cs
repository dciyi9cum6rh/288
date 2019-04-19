using System.Collections.Generic;

namespace DataModel
{
    public class HomeViewModel
    {
        public List<HomeImageViewModel> HomeImage { get; set; }
        public YoutubeVideoViewModel YoutubeVideo { get; set; }
        public List<ProductListViewModel> NewProduct { get; set; }
    }
}