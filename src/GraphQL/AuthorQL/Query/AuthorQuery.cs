using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using HotChocolate;
using HotChocolate.Subscriptions;
using log4net;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Query
{
    public class AuthorQuery
    {
        private static ILog _logger = LogManager.GetLogger(typeof(AuthorQuery));
        
        public async Task<List<Author>> GetAllAuthors([Service] IAuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender)
        {
            try
            {
                List<Author> authors = authorRepository.GetAuthors();
                await eventSender.SendAsync("ReturnedAuthors", authors);
                return authors;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
        
        public async Task<Author> GetAuthorById([Service] IAuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);
            return author;
        }
    }
}