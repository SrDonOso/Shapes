using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Result
    {
        public Result() => errorList = new List<string>();
        public IList<string> errorList { get; set; }
        public bool IsValid { get { return errorList.Count == 0; } }
        public Instruction Instruction { get; set; }

        public string PrintErrors()
        {
            var sb = new StringBuilder();
            foreach (var item in errorList)
                sb.AppendLine(item);
            return sb.ToString();
        }
    }
}
