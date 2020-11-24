using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;
using Volo.Abp.DependencyInjection;

namespace MyAbp.Pages.Account
{
    public class LoginModel : Volo.Abp.Account.Web.Pages.Account.LoginModel
    {
        public LoginModel(
    Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider schemeProvider,
    Microsoft.Extensions.Options.IOptions<Volo.Abp.Account.Web.AbpAccountOptions> accountOptions)
        : base(schemeProvider, accountOptions)
        {
        }
        //public void OnGet()
        //{
        //}
    }
    //[Dependency(ReplaceServices = true)]
    //[ExposeServices(typeof(MyLoginModel))]
    public class MyLoginModel : LoginModel
    {
        public MyLoginModel(
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions
            ) : base(
            schemeProvider,
            accountOptions)
        {

        }

        public override Task<IActionResult> OnPostAsync(string action)
        {
            //TODO: Add logic
            return base.OnPostAsync(action);
        }

        //TODO: Add new methods and properties...
    }
}
