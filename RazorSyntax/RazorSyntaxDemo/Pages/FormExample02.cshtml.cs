using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSyntaxDemo.Pages
{
    public class FormExample02Model : PageModel
    {
        public void OnGet()
        {
        }

        public string FeedbackMessage { get; private set; }
        public List<int> GeneratedNumbers { get; private set; } = new List<int>();

        public void OnPost()
        {
            // Generate 7 unique numbers between 1 and 50
            var rand = new Random();
            while (GeneratedNumbers.Count < 7)
            {
                var randomNumber = rand.Next(1, 51);
                if (!GeneratedNumbers.Contains(randomNumber))
                {
                    GeneratedNumbers.Add(randomNumber);
                }
            }
            GeneratedNumbers.Sort();
            // Sort the generated numbers in sequence
            //FeedbackMessage = "";
            //foreach(var num in GeneratedNumbers)
            //{
            //    FeedbackMessage += num + " ";
            //}

        }
    }
}
