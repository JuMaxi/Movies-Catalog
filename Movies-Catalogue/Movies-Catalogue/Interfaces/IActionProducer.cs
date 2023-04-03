using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionProducer
    {
        void NewProducer(ProducerRequest NewProducer);
        List<ProducerRequest> ShowProducers();
        void UpdateProducer(ProducerRequest Producer);
        void DeleteProducer(int Id);
    }
}
