using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.GraphQL;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Mutation;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Query;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Query;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogPostsManagementSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ApplicationDbContext>(
                options => options.UseInMemoryDatabase("BlogsManagement"));
            services.AddInMemorySubscriptions();
            services.AddScoped<IAuthorRepository, 
                AuthorRepository>();
            services.AddScoped<IBlogPostRepository, 
                BlogPostRepository>();
            services
                .AddGraphQLServer( "blogPost" )
                .AddQueryType<BlogPostQuery>()
                .AddType<BlogPostType>()
                .AddSubscriptionType<Subscription>();

            services
                .AddGraphQLServer("author")
                .AddQueryType<AuthorQuery>()
                .AddType<AuthorType>()
                .AddMutationType<AuthorMutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graphql",
                    Path = "/playground"
                });
            }
            app.UseWebSockets();
            app.UseRouting().UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL("/blogPost", "blogPost");
                    endpoints.MapGraphQL("/author", schemaName: "author");
                });
        }
    }
}
