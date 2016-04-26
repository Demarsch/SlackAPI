using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAPI.WebSocketMessages
{
    public class WrappedMessage
    {
        public WrappedMessage(NewMessage originalMessage, SlackSocketClient client)
        {
            UserId = originalMessage.user;
            User user;
            UserName = client.UserLookup.TryGetValue(UserId, out user) ? user.name : string.Empty;
            ChannelId = originalMessage.channel;
            Channel channel;
            ChannelName = client.ChannelLookup.TryGetValue(ChannelId, out channel) ? channel.name : string.Empty;
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
