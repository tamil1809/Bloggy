﻿using Bloggy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloggy.Services
{
    public class BlogService
    {
        private readonly BloggingDbContext _db;
        private static BlogService _instance;

        private BlogService(BloggingDbContext db)
        {
            _db = db;

            if (_db.Posts.Count() == 0)
            {
                AddSeedData();
            }
        }

        public static BlogService CreateInstance(BloggingDbContext db)
        {
            return _instance ?? new BlogService(db);
        }

        public Post GetPost(string slug)
        {
            return _db.Posts.Include(p => p.Comments).SingleOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _db.Posts;
        }

        public void AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }

        private void AddSeedData()
        {
            _db.Posts.AddRange(
                new Post
                {
                    Id = 1,
                    Title = "What is Lorem Ipsum?",
                    Slug = "what-is-lorem-ipsum-1",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing **Lorem Ipsum** passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.",
                    IsPublished = true,
                    PublishedAt = new DateTime(2016, 12, 2),
                    Tags = "Lorem Ipsum,lorem,ipsum"
                },
                new Post
                {
                    Id = 2,
                    Title = "Where does it come from?",
                    Slug = "where-does-it-come-from-2",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing **Lorem Ipsum** passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.",
                    IsPublished = true,
                    PublishedAt = new DateTime(2016, 12, 4),
                    Tags = "Lorem Ipsum,lorem,ipsum"
                },
                new Post
                {
                    Id = 3,
                    Title = "Why do we use it?",
                    Slug = "why-do-we-use-it-3",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing **Lorem Ipsum** passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.",
                    IsPublished = true,
                    PublishedAt = new DateTime(2016, 12, 6),
                    Tags = "Lorem Ipsum,lorem,ipsum"
                },
                new Post
                {
                    Id = 4,
                    Title = "What is Lorem Ipsum?",
                    Slug = "what-is-lorem-ipsum-4",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing **Lorem Ipsum** passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.",
                    IsPublished = true,
                    PublishedAt = new DateTime(2016, 12, 8),
                    Tags = "Lorem Ipsum,lorem,ipsum"
                },
                new Post
                {
                    Id = 5,
                    Title = "Where does it come from?",
                    Slug = "where-does-it-come-from-5",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.

Contrary to popular belief, **Lorem Ipsum** is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of ""de Finibus Bonorum et Malorum"" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, ""Lorem ipsum dolor sit amet.."", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from ""de Finibus Bonorum et Malorum"" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                    IsPublished = true,
                    PublishedAt = new DateTime(2016, 12, 10),
                    Tags = "Lorem Ipsum,lorem,ipsum",
                    Comments = new List<Comment>
                    {
                        new Comment()
                        {
                            Name = "Lorem Ipsum",
                            Email = "lorem@ipsum.com",
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Website = "http://www.lipsum.com",
                            PublishedAt = new DateTime(2016,12,14),
                            PostId = 5
                        },
                        new Comment()
                        {
                            Name = "Lorem Ipsum",
                            Email = "lorem@ipsum.com",
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                            Website = "http://www.lipsum.com",
                            PublishedAt = new DateTime(2016,12,14),
                            PostId = 5
                        }
                    }
                },
                new Post
                {
                    Id = 6,
                    Title = "Why do we use it?",
                    Slug = "why-do-we-use-it-6",
                    Excerpt = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = @"**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. **Lorem Ipsum** has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing **Lorem Ipsum** passages, and more recently with desktop publishing software like Aldus PageMaker including versions of **Lorem Ipsum**.",
                    LastModified = new DateTime(2016, 12, 10),
                    IsPublished = false,
                    Tags = "Lorem Ipsum,lorem,ipsum"
                }
            );

            _db.SaveChanges();
        }
    }
}