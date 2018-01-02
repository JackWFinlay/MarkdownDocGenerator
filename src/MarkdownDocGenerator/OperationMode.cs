namespace MarkdownDocGenerator
{
    public enum OperationMode
    {
        /// <summary>
        /// The codebase is exclusively using Markdown for documetation.
        /// </summary>
        Exclusive = 0,
        
        /// <summary>
        /// The codebase is using a mix of XML and Markdown documentation.
        /// Markdown must be specified by the <markdown></markdown> tags.
        /// </summary>
        InterOp = 1
    }
}