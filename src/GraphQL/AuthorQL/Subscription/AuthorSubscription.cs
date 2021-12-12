using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Subscription
{
    public class AuthorSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorCreated([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Author>("AuthorCreated", cancellationToken);
        }
        
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorsGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<Author>>("ReturnedAuthors", cancellationToken);
        }
        
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorGet([Service] ITopicEventReceiver eventReceiver, 
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Author>("ReturnedAuthor", cancellationToken);
        }
    }
}