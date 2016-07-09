using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeekDaysEdu.Startup))]
namespace GeekDaysEdu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
