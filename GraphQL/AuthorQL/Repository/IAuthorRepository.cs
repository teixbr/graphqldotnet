using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public Task<Author> CreateAuthor(Author author);
    }
}