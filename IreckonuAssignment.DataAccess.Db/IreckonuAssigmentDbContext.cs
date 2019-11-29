namespace IreckonuAssignment.DataAccess.Db
{
    using IreckonuAssignment.DataAccess.Db.Models;
    using Microsoft.EntityFrameworkCore;

    public class IreckonuAssigmentDbContext : DbContext, IIreckonuAssigmentDbContext
    {
        private string connectionString;

        public IreckonuAssigmentDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<ArticleDataModel> Articles { get; set; }

        public virtual DbSet<ArticleSizeDataModel> ArticleSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                this.connectionString);
        }
    }
}
