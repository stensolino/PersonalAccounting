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
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly IUsersServices _usersService;
        private readonly IBudgetsService _budgetsService;

        public ConfirmAccountModel(
            UserManager<CognitoUser> userManager,
            SignInManager<CognitoUser> signInManager,
            IUsersServices usersServices,
            IBudgetsService budgetsService)
        {
            _userManager = userManager as CognitoUserManager<CognitoUser>;
            _signInManager = signInManager as SignInManager<CognitoUser>;
            _usersService = usersServices;
            _budgetsService = budgetsService;
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
            returnUrl = returnUrl ?? Url.Content("~/Identity/Account/Login");
            if (ModelState.IsValid)
            {
                var userIdentityId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                var userIdentity = await _userManager.FindByIdAsync(userIdentityId);
                if (userIdentity == null)
                {
                    return NotFound($"Unable to load user with ID '{userIdentityId}'.");
                }

                var result = await _userManager.ConfirmSignUpAsync(userIdentity, Input.Code, true);
                await _signInManager.SignOutAsync();

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Error confirming account for user with ID '{userIdentityId}':");
                }
                else
                {
                    // Register user in local db and add default budget for the user
                    var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                    var userId = await _usersService.CreateUserAsync(new UserDto
                    {
                        CognitoId = userIdentity.UserID,
                        Email = email
                    });

                    return returnUrl != null ? LocalRedirect(returnUrl) : Page() as IActionResult;
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
