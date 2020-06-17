namespace Integral.Constants
{
    public static class ControlsConstant
    {
        public const string SocialControls =
@"chat                  Toggles chat messages.
  who       [Filter]    Display a list of users.
  friend    Name        Toggles friendship of a user.
  block     Name        Toggles chat block of a user.
  invite    Name        Invites a user to your group.
  leave                 Leaves your current group.
  group                 Display your group status report.";

        internal const string SystemControls =
@"/                     Initiates a text command.
  Escape                Closes the application.
  Delete                Clears the screen.";
    }
}