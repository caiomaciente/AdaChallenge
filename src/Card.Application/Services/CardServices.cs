using Card.Application.Contracts;
using Card.Domain.Entity;
using Card.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Application.Services
{
    public class CardServices(ICardRepository cardRepository) : ICardServices
    {

        public async Task<bool> Create(CardEntity card)
        {
            if (string.IsNullOrEmpty(card.Titulo) ||
               string.IsNullOrEmpty(card.Conteudo) ||
               string.IsNullOrEmpty(card.Lista))
            {
                return false;
            }

            var result = await cardRepository.Create(card);
            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await cardRepository.Delete(id);
            return result;
        }

        public List<CardEntity> Get()
        {
            var result = cardRepository.Get();
            return result;
        }

        public async Task<bool> Update(Guid id, CardEntity updatedCard)
        {
            var result = await cardRepository.Update(id, updatedCard);
            return result;
        }

    }
}
