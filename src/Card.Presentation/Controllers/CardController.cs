using Card.Application.Contracts;
using Card.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Card.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController(ICardServices cardServices, ILogger<CardController> logger) : ControllerBase
{

    [Authorize]
    [HttpGet()]
    public IActionResult Get()
    {
        var result = cardServices.Get();
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCard([FromBody] CardEntity card)
    {
        var result = await cardServices.Create(card);
        return result ? CreatedAtAction(nameof(Get), new { id = card.Id }, card) : BadRequest("Todos os campos (titulo, conteudo, lista) devem ser preenchidos.");
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCard(Guid id, [FromBody] CardEntity updatedCard)
    {
        var result = await cardServices.Update(id, updatedCard);

        if (result){
            logger.LogInformation("{Time} - Card {Id} - {Titulo} - Alterado",
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), id, updatedCard.Titulo);
        }

        return result ? Ok(result) : BadRequest("Todos os campos (titulo, conteudo, lista) devem ser preenchidos."); ;
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(Guid id)
    {
        var existingCard = cardServices.Find(id);
        var result = await cardServices.Delete(id);

        if (result)
        {
            logger.LogInformation("{Time} - Card {Id} - {Titulo} - Removido",
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), id, existingCard.Titulo);
        }

        return result ? Ok(_context.Cards.ToList()); : BadRequest("Todos os campos (titulo, conteudo, lista) devem ser preenchidos."); ;
    }
}
