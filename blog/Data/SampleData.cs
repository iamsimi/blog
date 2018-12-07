using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Data
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Articles.Any())
                {
                    return; 
                }
                context.Authors.AddRange(
                    new Author
                    {
                        Fullname = "Jan Smith"
                    });
                context.SaveChanges();

                context.Articles.AddRange(
                    new Article
                    {
                        Title = "Ass time",
                        Content = "I tell a fictitious story but not so unreal. In it we have this guy," +
                        " whom we know and learn to love so much. He is family and he comes to visit bearing gifts. " +
                        "And as nature – or life - would have it, you have to spend a great deal of time with him." +
                        " In the course of your stay it seems you’ve lost that guy you remember and this guy is not that guy. " +
                        "You would have concluded that he was a farce but every once in a while the guy you remember from home resurfaces and you are wondering what happened. " +
                        "Now snap out of it.Welcome to the real world.The truth ? The guy from the story is the same guy that as ever been," +
                        "just that like every other human he just experiences is ass - time(a time we all become an ass – temporary assholes." +
                        "Ass-time. I believe recognizing an individual’s ass-time would make things a little bit better. Everyone is inherently good, it just our ass-time that flaws us. " +
                        "And this ass-time is experienced by everyone. We all become temporary assholes at some point or the other. What matters is how long we use in the ass-zone?" +
                        "Time -out of the ass - zone is the major solution.But most assholes(I included) in different ass - time finds it difficult to say time -out. " +
                        "But there are the great ones who span less in the ass - zone due to friend or inner power,and the good ones who span more." +
                        "And I tell you this ass - time can be as lengthy as lifetime (Steve Jobs a world -class asshole – not me!) to as short as few minutes(my baby bro) from you.",

                        datePublished = DateTime.Now.ToShortDateString(), 
                        Tags = "ass, temporary asshole",
                        AuthorId = 1
                    });
                context.SaveChanges();
            }
        }
    }
}
