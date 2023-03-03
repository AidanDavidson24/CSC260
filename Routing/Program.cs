namespace Routing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

		//app.MapControllerRoute(
		//	name: "HomePage",
		//	pattern: "/site.com",
		//	defaults: new { controller = "Home", action = "HomePage" });

		app.MapControllerRoute(
		name: "Cow",
				pattern: "/cow/{id}",
				defaults: new { controller = "Home", action = "Cow" });

			app.MapControllerRoute(
				name: "Chicken",
				pattern: "/EatMoreChicken",
				defaults: new { controller = "Home", action = "Chicken" });

			app.MapControllerRoute(
				name: "Cow2",
				pattern: "/{id}/{cow}",
				defaults: new { controller = "Home", action = "Cow2" });

			app.MapControllerRoute(
				name: "CowGallery",
				pattern: "/AllCows/Gallery/{id}",
				defaults: new { controller = "Home", action = "CowGallery" });

			app.MapControllerRoute(
				name: "CowGallery2",
				pattern: "/AllCows/Gallery/{id}/Page{num}",
				defaults: new { controller = "Home", action = "CowGallery2" });

			app.MapControllerRoute(
				name: "CowGallery3",
				pattern: "/AllCows/Gallery/{id}/{num}",
				defaults: new { controller = "Home", action = "CowGallery2" });

			app.MapControllerRoute(
				name: "CatchAll",
				pattern: "{*anything}",
				defaults: new { controller = "Home", action = "Index" });

			app.Run();
		}
	}
}