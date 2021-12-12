using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Repository
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;
        
        public AuthorResolver([Service] IAuthorRepository authorService)
        {
            _authorRepository = authorService;
        }
        
        public Author GetAuthor([Parent] BlogPost blog, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().FirstOrDefault(a => a.Id == blog.AuthorId);
        }
    }
}