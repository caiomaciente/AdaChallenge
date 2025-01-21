using Card.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Application.Contracts
{
    public interface ICardServices
    {
        List<CardEntity> Get();
        Task<bool> Create(CardEntity card);

        Task<bool> Update(Guid id, CardEntity updatedCard);

        Task<bool> Delete(Guid id);
    }
}
