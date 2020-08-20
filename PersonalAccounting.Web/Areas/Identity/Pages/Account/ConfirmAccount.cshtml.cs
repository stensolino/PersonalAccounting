using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalAccounting.Domain.Dto;
using PersonalAccounting.Web.Services.Interfaces;

namespace PersonalAccounting.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmAccountModel : PageModel
    {
        private readonly CognitoUserManager<CognitoUser> _userManager;
        private readonly IUsersServices _usersService;

        public ConfirmAccountModel(UserManager<CognitoUser> userManager, IUsersServices usersServices)
        {
            _userManager = userManager as CognitoUserManager<CognitoUser>;
            _usersService = usersServices;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{userId}'.");
                }

                var result = await _userManager.ConfirmSignUpAsync(user, Input.Code, true);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Error confirming account for user with ID '{userId}':");
                }
                else
                {
                    // Register user in local db and add default budget for the user
                    var userBudgets = new List<BudgetDto>();
                    userBudgets.Add(new BudgetDto { });
                    var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                    await _usersService.CreateUserAsync(new UserDto
                    {
                        CognitoId = user.UserID,
                        Email = email,
                        Budgets = userBudgets
                    });

                    return returnUrl != null ? LocalRedirect(returnUrl) : Page() as IActionResult;
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
