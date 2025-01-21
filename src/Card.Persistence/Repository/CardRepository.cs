using Card.Application.Contracts;
using Card.Data;
using Card.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Card.Persistence.Repository;
public class CardRepository(CardContext db) : ICardRepository
{
    public List<CardEntity> Get() => db.Cards.ToList();

    public async Task<bool> Create(CardEntity card)
    {
        try
        {
            await db.Cards.AddAsync(card);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Guid id, CardEntity updatedCard)
    {
        var existingCard = db.Cards.Find(id);
        if (existingCard == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(updatedCard.Titulo) ||
            string.IsNullOrEmpty(updatedCard.Conteudo) ||
            string.IsNullOrEmpty(updatedCard.Lista))
        {
            return false;
        }
        try
        {
            existingCard.Titulo = updatedCard.Titulo;
            existingCard.Conteudo = updatedCard.Conteudo;
            existingCard.Lista = updatedCard.Lista;

            await db.SaveChangesAsync();
        
            

            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Delete(Guid id)
    {
        var existingCard = db.Cards.Find(id);
        if (existingCard == null)
        {
            return false;
        }
        db.Cards.Remove(existingCard);

        await db.SaveChangesAsync();
        return true;
    }
}
