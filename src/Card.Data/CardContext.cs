using Microsoft.EntityFrameworkCore;
using Card.Domain.Entity;

namespace Card.Data
{
   
        public class CardContext : DbContext
        {
            public CardContext(DbContextOptions<CardContext> options) : base(options) { }

            public DbSet<CardEntity> Cards { get; set; }
        }
    
}
