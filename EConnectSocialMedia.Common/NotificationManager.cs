namespace GangstersAPP.Common
{
    public static class NotificationManager
    {
        public static FirebaseNotificationModel Notification { get; set; }

        public static async Task<string> SendToTopic(Message message)
        {
            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            return response;
            // [END send_to_token]
        }

        public static async Task<int> SendMulticast(MulticastMessage message)
        {
            BatchResponse response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
            // See the BatchResponse reference documentation
            // for the contents of response.
            return response.SuccessCount;
            // [END send_multicast]
        }

        public static async Task<int> SubscribeToTopic(List<string> registrationTokens, string topic)
        {
            // Subscribe the devices corresponding to the registration tokens to the
            // topic
            TopicManagementResponse response = await FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync(
                registrationTokens, topic);
            // See the TopicManagementResponse reference documentation
            // for the contents of response.
            return response.SuccessCount;
            // [END subscribe_to_topic]
        }

        public static Message CreateMessage(FirebaseNotificationModel Model)
        {
            Dictionary<string, object> Extra = new()
            {
                { "OpenType", Model.OpenType.ToString() },
                { "OpenValue", Model.OpenType.ToString() },
            };

            Dictionary<string, string> data = new()
            {
                { "Extra", JsonConvert.SerializeObject(Extra) },
                { "Title", Model.MessageHeading },
                { "Body", Model.MessageContent },
                { "ImgUrl", Model.ImgUrl },
            };

            // [START apns_message]
            Message message = new()
            {
                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Alert = new ApsAlert()
                        {
                            Title = Model.MessageHeading,
                            Body = Model.MessageContent,
                        }
                    },
                },
                Data = data,
                Topic = Model.Topic
            };
            // [END apns_message]
            return message;
        }

        public static MulticastMessage CreateMulticastMessage(FirebaseNotificationModel Model)
        {
            Dictionary<string, object> Extra = new()
            {
                { "OpenType", Model.OpenType.ToString() },
                { "OpenValue", Model.OpenType.ToString() },
            };

            Dictionary<string, string> data = new()
            {
                { "Extra", JsonConvert.SerializeObject(Extra) },
                { "Title", Model.MessageHeading },
                { "Body", Model.MessageContent },
                { "ImgUrl", Model.ImgUrl },
            };

            // [START apns_message]
            MulticastMessage message = new()
            {
                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Alert = new ApsAlert()
                        {
                            Title = Model.MessageHeading,
                            Body = Model.MessageContent,
                        }
                    },
                },
                Data = data,
                Tokens = Model.RegistrationTokens
            };
            // [END apns_message]
            return message;
        }
    }

    public class FirebaseNotificationModel
    {
        public FirebaseNotificationModel()
        {
            RegistrationTokens = new List<string>();
        }

        public string MessageHeading { get; set; }

        public string MessageContent { get; set; }

        public string ImgUrl { get; set; }

        public List<string> RegistrationTokens { get; set; }

        public string Topic { get; set; }

        public int OpenType { get; set; }

        public string OpenValue { get; set; }
    }
}
