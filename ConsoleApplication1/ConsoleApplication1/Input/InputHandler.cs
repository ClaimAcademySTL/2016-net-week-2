using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class InputHandler
    {
        private readonly IParser _parser;
        private readonly InputPrompter _prompter;
        private readonly bool _addBasicPrompt;

        /**
         * The parser specified here will be used by GetAndParseInput.
         */
        public InputHandler(IParser parser, String inputPrompt, bool addBasicPrompt = true)
        {
            _parser = parser;
            _prompter = new InputPrompter(inputPrompt);
            _addBasicPrompt = addBasicPrompt;
        }

        /**
         * Get input from the user, and use the parser that was specified 
         * during construction to parse the input. Any exceptions generated
         * by the parser are passed on to the caller.
         */
        public IEvaluatable GetAndParseInput()
        {
            //InputPrompter prompter = new InputPrompter("Please enter an expression using binary operators.\nExample expression: '75.3 + -20.7 - 35 * 6e-20'");
            String inputString = _prompter.GetInput(_addBasicPrompt);

            Tokenizer tokenizer = new Tokenizer(' ');
            String[] tokens = tokenizer.Tokenize(inputString);

            // May generate exception. For ExpressionParser, could generate ArgumentException
            // or BadTokenException
            return _parser.Parse(tokens);
        }
    }
}
