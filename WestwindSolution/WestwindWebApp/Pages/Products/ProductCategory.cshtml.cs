using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Namespaces for BLL and Entities
using WestwindSystem.Entities;
using WestwindSystem.BLL;
using Microsoft.AspNetCore.Mvc.Rendering;
#endregion


namespace WestwindWebApp.Pages.Products
{
    public class ProductCategoryModel : PageModel
    {

        #region Internal Fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        #endregion

        #region Page Data Properties
        //Data source for category select element
        public SelectList CategorySelectList { get; private set; }
        //Bindable property for value selected from select element
        [BindProperty]
        public int? SelectedCategoryID { get; set; }
        //Query Result Property
        public List<Product>? QueryProductResultList { get; private set; }


        //Feedback Message Properties
        public string? InfoMessage { get; set; }
        public string? ErrorMessage { get; set; }

        #endregion

        #region Constructor With Dependencies
        public ProductCategoryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;

            //Fetch List Categories
            List<Category> categories = _categoryServices.List();
            CategorySelectList = new SelectList(categories, "Id", "CategoryName");
        }
        #endregion

        #region Page Handlers
        public void OnGet()
        {

        }

        public IActionResult OnPostFetchProducts()
        {
            IActionResult nextPage = Page();
            //Verify that a valid Category was selected
            if(SelectedCategoryID.HasValue && SelectedCategoryID.Value > 0)
            {
                int categoryId = SelectedCategoryID.Value;
                QueryProductResultList = _productServices.FindProductsByCategoryId(categoryId);
                InfoMessage = $"Query returned {QueryProductResultList.Count} reocrd(s)";
            }
            else
            {
                ErrorMessage = "A valid category must be selected";
            }
            return nextPage;
        }

        public IActionResult OnPostClear()
        {
            IActionResult nextPage = Page();
            SelectedCategoryID = null;
            QueryProductResultList = null;
            ModelState.Clear();
            return nextPage;
        }

        public IActionResult OnPostNewProduct()
        {
            IActionResult nextPage = RedirectToPage("/Products/ProductCrud");
            return nextPage;
        }
        #endregion
    }
}
