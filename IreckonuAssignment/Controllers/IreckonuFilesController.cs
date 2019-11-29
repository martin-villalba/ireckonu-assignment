namespace IreckonuAssignment.Controllers
{
    using System.Threading.Tasks;
    using IreckonuAssignment.BusinessLogic;
    using IreckonuAssignment.Utilities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class IreckonuFilesController : ControllerBase
    {
        private IFormFileStringReader fileFormStringReader;
        private IFormFileStringArticleParser formFileStringItemParser;
        private IArticlesHandler itemsHandler;

        public IreckonuFilesController(
            IFormFileStringReader fileFormStringReader,
            IFormFileStringArticleParser formFileStringItemParser,
            IArticlesHandler itemsHandler)
        {
            this.fileFormStringReader = fileFormStringReader;
            this.formFileStringItemParser = formFileStringItemParser;
            this.itemsHandler = itemsHandler;
        }

        /// <summary>
        /// API endpoint to allows importing CSV files with Articles data
        /// </summary>
        /// <param name="file">File containing the articles data to be imported</param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("processCsvFile")]
        public virtual async Task<ActionResult> ProcessCsvFileAsync(IFormFile file)
        {
            var fileLines = this.fileFormStringReader.ReadLines(file);
            var ireckonuItems = this.formFileStringItemParser.ParseArticles(fileLines);

            await this.itemsHandler.ProcessItems(ireckonuItems);

            return this.Ok();
        }
    }
}