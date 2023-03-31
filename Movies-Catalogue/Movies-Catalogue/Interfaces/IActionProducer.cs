using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionProducer
    {
        void NewProducer(Producer NewProducer);
        List<Producer> ShowProducers();
        void UpdateProducer(Producer Producer);
        void DeleteProducer(int Id);
    }
}
