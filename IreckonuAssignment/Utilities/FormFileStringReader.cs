namespace IreckonuAssignment.Utilities
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.AspNetCore.Http;

    public class FormFileStringReader : IFormFileStringReader
    {
        public virtual IEnumerable<string> ReadLines(IFormFile file)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            return lines;
        }
    }
}
