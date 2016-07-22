﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class InputPrompter
    {
        private readonly String _prompt;

        /**
         * promptText will be printed out before getting the user's
         * input with GetInput.
         */
        public InputPrompter(String promptText)
        {
            _prompt = promptText;
        }

        /**
         * Prompt the user and return the user's input.
         * If addBasicPrompt is true, will add a newline and a chevron
         * to appear as a prompt. If false, will display the prompt text
         * as-is, with no newline (in this case, the prompt text should
         * end in text that looks like a prompt of some kind).
         */
        public String GetInput(bool addBasicPrompt)
        {
            String effectiveText = _prompt;
            if (addBasicPrompt)
            {
                effectiveText += "\n > ";
            }

            Console.Write(effectiveText);
            return Console.ReadLine();
        }
    }
}
