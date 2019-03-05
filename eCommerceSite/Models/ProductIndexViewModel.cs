using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models
{
    /// <summary>
    /// ViewModel for the Product Index page
    /// </summary>
    public class ProductIndexViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prods"></param>
        /// <param name="maxPage"></param>
        /// <param name="currPage"></param>
        public ProductIndexViewModel(List<Product> prods, int maxPage, int currPage)
        {
            Products = prods;
            MaxPage = maxPage;
            CurrentPage = currPage;
        }

        public List<Product> Products { get; private set; }

        public int MaxPage { get; private set; }

        public int CurrentPage { get; private set; }


    }
}
