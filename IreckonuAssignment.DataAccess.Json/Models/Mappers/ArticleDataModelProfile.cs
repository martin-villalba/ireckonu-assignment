namespace IreckonuAssignment.DataAccess.Json.Models.Mappers
{
    using AutoMapper;
    using IreckonuAssignment.Domain.Models;

    public class ArticleDataModelProfile : Profile
    {
        public ArticleDataModelProfile()
        {
            CreateMap<Article, ArticleDataModel>().ForSourceMember(src => src.Sizes, act => act.DoNotValidate());
            CreateMap<ArticleSize, ArticleSizeDataModel>().ForSourceMember(src => src.Article, act => act.DoNotValidate());
        }
    }
}
