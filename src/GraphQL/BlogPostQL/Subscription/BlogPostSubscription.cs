using System.Threading;
using System.Threading.Tasks;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Subscription
{
    public class BlogPostSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogPost>> OnBlogPostsGet([Service] ITopicEventReceiver eventReceiver, 
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogPost>("ReturnedBlogPosts", cancellationToken);
        }
        
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogPost>> OnBlogPostGet([Service] ITopicEventReceiver eventReceiver, 
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BlogPost>("ReturnedBlogPost", cancellationToken);
        }
    }
}