using Integral.Constants;

namespace Integral.Functions
{
    public static class ControlsFunction
    {
        public static string Welcome(string application, string textControls, string keyboardControls) => $@"
- {application} -

Type /help to see the below controls prompt at any time:
{ Commands(textControls, keyboardControls) }";

        public static string Commands(string textControls, string keyboardControls) => $@"
Text Commands

  Keyword   Argument    Action
  -----------------------------------------------------------------
  {textControls}

Keyboard Commands

  Key       Modifier    Action
  -----------------------------------------------------------------
  {ControlsConstant.SystemControls}  
  {keyboardControls}

";
    }
}
