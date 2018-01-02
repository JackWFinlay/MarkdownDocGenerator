using System.IO;

namespace MarkdownDocGenerator
{
    public class MarkdownDocParserConfiguration
    {
        private const SearchOption DefaultSearchOption = SearchOption.AllDirectories;
        private const OperationMode DefaultOperationMode = OperationMode.InterOp;

        private SearchOption? _searchOption;
        private OperationMode? _operationMode;

        public SearchOption SearchOption
        {
            get => _searchOption ?? DefaultSearchOption;
            set => _searchOption = value;
        }

        public OperationMode OperationMode
        {
            get => _operationMode ?? DefaultOperationMode;
            set => _operationMode = value;
        }
    }
}