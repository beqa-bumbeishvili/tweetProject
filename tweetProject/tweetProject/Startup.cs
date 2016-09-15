using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(tweetProject.Startup))]
namespace tweetProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}