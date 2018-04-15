using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaerskLine.Startup))]
namespace MaerskLine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
