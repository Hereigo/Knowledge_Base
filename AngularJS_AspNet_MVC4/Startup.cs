using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJS_AspNet_MVC4.Startup))]
namespace AngularJS_AspNet_MVC4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
