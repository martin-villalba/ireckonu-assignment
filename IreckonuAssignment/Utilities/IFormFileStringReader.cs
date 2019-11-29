namespace IreckonuAssignment.Utilities
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public interface IFormFileStringReader
    {
        IEnumerable<string> ReadLines(IFormFile file);
    }
}
