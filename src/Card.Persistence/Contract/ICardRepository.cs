using Card.Domain.Entity;

namespace Card.Application.Contracts;
public interface ICardRepository
{
    List<CardEntity> Get();
    Task<bool> Create(CardEntity card);

    Task<bool> Update(Guid id, CardEntity updatedCard);
    Task<bool> Delete(Guid id);
}
