using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class InputHandler
    {
        public static bool GetAndParseInput(out Operators.BinaryOperator[] operators, out double[] operands, out String errorMsg)
        {
            InputPrompter prompter = new InputPrompter("Please enter an expression using binary operators.\nExample expression: '75.3 + -20.7 - 35 * 6e-20'");
            String inputString = prompter.GetInput(true);

            Tokenizer tokenizer = new Tokenizer(' ');
            String[] tokens = tokenizer.Tokenize(inputString);

            Parser parser = new Parser(tokens);
            return parser.Parse(out operators, out operands, out errorMsg);
        }
    }
}
