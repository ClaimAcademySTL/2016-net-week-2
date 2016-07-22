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

        /**
         * The parser specified here will be used by GetAndParseInput.
         */
        public InputHandler(IParser<T> parser)
        {
            _parser = parser;
        }

        /**
         * Get input from the user, and use the parser that was specified 
         * during construction to parse the input. Returns true on success,
         * false on error.
         */
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
