using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
using HotChocolate.Execution;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace BlogPostsManagementSystem
{
    public class Startup
    {
        public class CustomInterceptor : DefaultHttpRequestInterceptor
        {
            public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, 
                IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken )
            {
                requestBuilder.AddProperty("foo", context.Request.Headers["Authorization"]);
                return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
            }
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            
            services.AddDbContextFactory<ApplicationDbContext>(
                options => options.UseInMemoryDatabase("BlogsManagement"));
            services.AddInMemorySubscriptions();
            services.AddScoped<IAuthorRepository, 
                AuthorRepository>();
            services.AddScoped<IBlogPostRepository, 
                BlogPostRepository>();
            services
                .AddGraphQLServer("blogPost")
                .AddQueryType<BlogPostQuery>()
                .AddType<BlogPostType>()
                //.AddSubscriptionType<Subscription>()
                .AddHttpRequestInterceptor<CustomInterceptor>()
                .AddAuthorization();
            
            services
                .AddGraphQLServer("author")
                .AddQueryType<AuthorQuery>()
                .AddType<AuthorType>()
                .AddMutationType<AuthorMutation>()
                .AddHttpRequestInterceptor<CustomInterceptor>()
                .AddAuthorization();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                       ValidIssuer = config["JWT:Issuer"],
                    };
                });
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
            
            app.UseAuthentication();
            app.UseWebSockets();
            app.UseRouting().UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL("/blogPost", "blogPost");
                    endpoints.MapGraphQL("/author", schemaName: "author");
                });
        }
    }
}
