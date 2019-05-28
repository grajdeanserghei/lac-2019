using Microsoft.EntityFrameworkCore;
using MusicMood.Core.Models;

namespace MusicMood.Infrastructure
{
    public class MusicMoodContext : DbContext
    {
        public MusicMoodContext(DbContextOptions<MusicMoodContext> options): base(options)
        {
        }

        public DbSet<ArtistModel> Artists { get; set; }
    }
}
