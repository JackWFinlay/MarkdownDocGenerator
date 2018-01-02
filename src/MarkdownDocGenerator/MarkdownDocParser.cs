using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownDocGenerator
{
    public class MarkdownDocParser : ISourceParser
    {
        private MarkdownDocParserConfiguration _configuration;
        
        /// <summary>
        /// Creates an instance of the MarkDownDocParser with the specified configuration.
        /// </summary>
        /// <param name="configuration">The confiuration with which to run the doc generator.</param>
        /// <markdown>
        /// # MarkdownDocParser Constructor
        /// Params:
        ///  - MarkdownDocParserConfiguration
        ///    - The configuration object for this instance of the parser
        /// </markdown>
        public MarkdownDocParser(MarkdownDocParserConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Parses the source files in the specified directory.
        /// </summary>
        /// <param name="directory">The root directory of the project.</param>
        /// <returns>Task, to run this method asynchronously.</returns>
        /// <exception cref="DirectoryNotFoundException">Throws exception when directory does not exist.</exception>
        /// <markdown>
        /// # ParseSourceAsync
        /// Params:
        ///  - directory
        ///    - The directory of source code to build documentation from. 
        /// Notes:
        ///  - Recurses down each sub-directory if -r flag is specified. 
        ///  - Output directory mirrors directory structure of source if -r flag is specified.
        /// </markdown>
        public async Task ParseSourceAsync(string directory)
        {
            IEnumerable<string> filesList;
            
            try
            {
                if (_configuration.SearchOption == SearchOption.AllDirectories)
                {
                   filesList = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);
                }
                else
                {
                    filesList = Directory.EnumerateFiles(directory, "*.cs", SearchOption.TopDirectoryOnly);
                }

                foreach (string fileLocation in filesList)
                {
                    await ParseFileAsync(fileLocation);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Task ParseFileAsync(string fileLocation)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (StreamReader streamReader = new StreamReader(fileLocation))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Detect Markdown and append to file being written.
                    switch (_configuration.OperationMode)
                    { 
                        case OperationMode.Exclusive:
                            if (line.TrimStart().StartsWith("///"))
                            {
                                stringBuilder.AppendLine(ScrapeMarkdownFromLine(line));
                            }
                            break;
                        case OperationMode.InterOp:
                            // TODO: Implement this.
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            // TODO: fix return type.
            return null;
        }

        private string ScrapeMarkdownFromLine(string line)
        {
            // TODO: Create implementation.
            return "";
        }
    }
}