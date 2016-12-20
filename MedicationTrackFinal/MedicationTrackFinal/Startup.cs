using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicationTrackFinal.Startup))]
namespace MedicationTrackFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
