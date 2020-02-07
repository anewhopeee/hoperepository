namespace HGDiscordBot
{
    public class CheckIfAllowedToWithdraw
    {
        public static string ReturnNationIDIfUserIsValidAndDailyLimitsMatchRequest(string User, string Resource, int Amount)
        {
            if () //User Found
            {
                if () // Resource is existing
                {
                    if () // Limit
                    {
                        return NationID;
                    }
                    else
                    {
                        return "LimitBlock";
                    }
                }
                else
                {
                    return "ResourceError";
                }
            }
            else
            {
                return "No Nation";
            }
        }

    }
}
