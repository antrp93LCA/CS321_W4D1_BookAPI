using CS321_W4D1_BookAPI.Models;
using System.Collections.Generic;

namespace CS321_W4D1_BookAPI.Services
{
    public interface IPublisherService
    {
        Publisher Add(Publisher publisher);

        Publisher Get(int publisherId);

        Publisher Update(Publisher updatedPublisher);

        void Remove(Publisher publisher);

        IEnumerable<Publisher> GetAll();
    }
}