using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    /// <summary>
    /// Result will have the validity or the error for the instructions typed in the console
    /// </summary>
    public class Result
    {
        public Result() => ErrorList = new List<string>();

        /// <summary>
        /// errorList has the list of different errors that may occurr during validation of the instructions
        /// </summary>
        public IList<string> ErrorList { get; set; }
        public bool IsValid { get { return ErrorList.Count == 0; } }
        public Instruction Instruction { get; set; }

        public string PrintErrors()
        {
            var sb = new StringBuilder();
            foreach (var item in ErrorList)
                sb.AppendLine(item);
            return sb.ToString();
        }
    }
}
