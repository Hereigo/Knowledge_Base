using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJS_ASPNet_MVC_4.Startup))]
namespace AngularJS_ASPNet_MVC_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
