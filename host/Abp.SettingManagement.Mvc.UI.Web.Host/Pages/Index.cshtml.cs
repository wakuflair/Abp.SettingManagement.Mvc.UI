using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Abp.SettingManagement.Mvc.UI.Pages
{
    public class IndexModel : AbpSettingManagementMvcUIPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}