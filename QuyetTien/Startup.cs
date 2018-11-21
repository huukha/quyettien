using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuyetTien.Startup))]
namespace QuyetTien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
