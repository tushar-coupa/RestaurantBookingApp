//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Microsoft.Owin.Security.Cookies;
//using Owin;
//using RestaurantBookingApp.Data;
//using RestaurantBookingApp.Models;

//[assembly: OwinStartup(typeof(RestaurantBookingApp.Startup))]

//namespace RestaurantBookingApp
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            app.CreatePerOwinContext(ApplicationDBContext.Create);
//            app.CreatePerOwinContext<UserManager<User>>(UserManager<User>.Create);
//            app.CreatePerOwinContext<SignInManager<User, string>>(SignInManager<User, string>.Create);

//            app.UseCookieAuthentication(new CookieAuthenticationOptions
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                LoginPath = new PathString("/Account/Login"),
//                LogoutPath = new PathString("/Account/Logout"),
//                ExpireTimeSpan = System.TimeSpan.FromMinutes(30),
//                SlidingExpiration = true
//            });
//        }
//    }
//}
