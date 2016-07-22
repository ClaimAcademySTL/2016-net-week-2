using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class InputHandler<T>
    {
        private readonly IParser<T> _parser;

        public InputHandler(IParser<T> parser)
        {
            _parser = parser;
        }

        public bool GetAndParseInput(out T result, out String errorMsg)
        {
            InputPrompter prompter = new InputPrompter("Please enter an expression using binary operators.\nExample expression: '75.3 + -20.7 - 35 * 6e-20'");
            String inputString = prompter.GetInput(true);

            Tokenizer tokenizer = new Tokenizer(' ');
            String[] tokens = tokenizer.Tokenize(inputString);

            return _parser.Parse(tokens, out result, out errorMsg);
        }
    }
}
