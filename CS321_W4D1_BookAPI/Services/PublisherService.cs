using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D1_BookAPI.Data;
using CS321_W4D1_BookAPI.Models;


namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        private int _nextID = 2;
        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher publisher)
        {
            publisher.Id = _nextID++;

            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();
            return publisher;
        }

        public Publisher Get(int publisherId)
        {
            return _bookContext.Publishers.Find(publisherId);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers.ToList();
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            var currentPublisher = _bookContext.Publishers.Find(updatedPublisher.Id);
            if (currentPublisher == null) return null;

            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatedPublisher);

            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }

        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }

    }
}
