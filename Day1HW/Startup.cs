using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day1HW.Startup))]
namespace Day1HW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
