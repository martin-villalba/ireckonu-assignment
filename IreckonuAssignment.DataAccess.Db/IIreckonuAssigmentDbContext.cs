namespace IreckonuAssignment.DataAccess.Db
{
    using System.Threading;
    using System.Threading.Tasks;
    using IreckonuAssignment.DataAccess.Db.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IIreckonuAssigmentDbContext
    {
        DbSet<ArticleDataModel> Articles { get; set; }

        DbSet<ArticleSizeDataModel> ArticleSizes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}