using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using OWASPTop10.Models;

namespace OWASPTop10.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=MvcBook;Integrated Security=True"))
            {
                string commandText = "[dbo].[CheckLogin]";

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@username", Login.Username));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", Login.Password));

                        sqlConnection.Open();
                        if (sqlCommand.ExecuteScalar() == null)
                        {
                            // Invalid Login
                            Login.Message = "Invalid Login.";
                            return Page();
                        }

                        // Valid Login
                        string Username = sqlCommand.ExecuteScalar().ToString();
                        sqlConnection.Close();
                        return RedirectToPage("./LoginSuccess", new { username = Username });
                    }
                }

                catch (Exception ex)
                {
                    Login.Message = ex.Message;
                    return Page();
                }
            }
        }
    }
}
