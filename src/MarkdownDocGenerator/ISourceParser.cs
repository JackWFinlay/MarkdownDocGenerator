using System.Threading.Tasks;

namespace MarkdownDocGenerator
{
    public interface ISourceParser
    {
        Task ParseSourceAsync(string directory);
    }
}