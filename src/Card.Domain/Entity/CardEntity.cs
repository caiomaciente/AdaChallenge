namespace Card.Domain.Entity;

public class CardEntity
{
    public Guid Id { get; private set; } 
    public string? Titulo { get; set; }
    public string? Conteudo { get; set; }
    public string? Lista { get; set; }

    public CardEntity()
    {
        Id = Guid.NewGuid(); 
    }
}
