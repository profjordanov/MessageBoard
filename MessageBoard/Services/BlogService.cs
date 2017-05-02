using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MessageBoard.Data;
using MessageBoard.Models;

namespace MessageBoard.Services
{
    public class BlogService : Service
    {
        public IEnumerable<BlogTopicVM> GetAllTopicVms()
        {
            IEnumerable<BlogTopic> topics = this.Context.BlogTopics.OrderByDescending(x => x.Date);
            IEnumerable<BlogTopicVM> vms = Mapper.Instance.Map<IEnumerable<BlogTopic>, IEnumerable<BlogTopicVM>>(topics);
            return vms;
        }

        public void AddTopic(BlogTopicBM bind)
        {
            BlogTopic model = Mapper.Map<BlogTopicBM, BlogTopic>(bind);
            model.Date = DateTime.Now;
            this.Context.BlogTopics.Add(model);
            this.Context.SaveChanges();
        }

        public BlogTopicVM GetTopic(int id)
        {
            BlogTopic topic = this.Context.BlogTopics.Find(id);
            BlogTopicVM vm = Mapper.Map<BlogTopic, BlogTopicVM>(topic);
            return vm;
        }
    }
}