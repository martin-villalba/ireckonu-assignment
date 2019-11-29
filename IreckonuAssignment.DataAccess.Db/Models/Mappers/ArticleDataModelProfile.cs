namespace IreckonuAssignment.DataAccess.Db.Models.Mappers
{
    using AutoMapper;
    using IreckonuAssignment.Domain.Models;

    public class ArticleDataModelProfile : Profile
    {
        public ArticleDataModelProfile()
        {
            CreateMap<Article, ArticleDataModel>().ReverseMap();
            CreateMap<ArticleSize, ArticleSizeDataModel>().ReverseMap();
        }
    }
}
