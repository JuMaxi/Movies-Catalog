using Movies_Catalogue.Models;

namespace Movies_Catalogue.Interfaces
{
    public interface IValidateProducer
    {
        void Validate(ProducerRequest Producer);
    }
}
