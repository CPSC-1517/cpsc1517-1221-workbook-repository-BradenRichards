using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCrudModel : PageModel
    {
        #region Internal Fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        #endregion

        #region Page Data Properties
        [BindProperty(SupportsGet =true)]
        public int? EditProductId { get; set; }
        #endregion

        #region Constructor With Dependencies

        #endregion

        #region Page Handlers
        public void OnGet()
        {

        }
        #endregion
    }
}
