using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AntiPlagiarism_App.Startup))]
namespace AntiPlagiarism_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
