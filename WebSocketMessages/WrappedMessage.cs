using System;

namespace SlackAPI.WebSocketMessages
{
    public class WrappedMessage
    {
        public WrappedMessage(NewMessage originalMessage, SlackSocketClient client)
        {
            UserId = originalMessage.user;
            User user;
            UserName = UserId != null && client.UserLookup.TryGetValue(UserId, out user) ? user?.name : string.Empty;
            ChannelId = originalMessage.channel;
            Channel channel;
            ChannelName =  ChannelId != null && client.ChannelLookup.TryGetValue(ChannelId, out channel) ? channel?.name : string.Empty;
            TeamId = client.MyTeam?.id;
            TeamName = client.MyTeam?.name;
            Timestamp = originalMessage.ts;
            Text = originalMessage.text;
        }

        public string UserId { get; private set; }

        public string UserName { get; private set; }

        public string ChannelId { get; private set; }

        public string ChannelName { get; private set; }

        public string TeamId { get; private set; }

        public string TeamName { get; private set; }

        public DateTime Timestamp { get; private set; }

        public string Text { get; private set; }

    }
}
