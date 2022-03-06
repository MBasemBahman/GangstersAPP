using GangstersAPP.Common;

namespace GangstersAPP.Repository.PostEntity
{
    public class NotificationRepository : AppBaseRepository<Notification>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public NotificationRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task SendNotification(Notification notification)
        {
            if (notification.IsPublic && notification.IsActive)
            {
                FirebaseAdmin.Messaging.Message message = NotificationManager.CreateMessage(new FirebaseNotificationModel
                {
                    OpenType = (int)notification.OpenType,
                    OpenValue = notification.OpenValue,
                    MessageContent = notification.Description,
                    MessageHeading = notification.Title,
                    ImgUrl = notification.ImageURL,
                    Topic = "all"
                });

                await NotificationManager.SendToTopic(message);
            }
            else
            {
                List<string> tokens = _DBContext.AccountDevice
                                                .Where(a => !string.IsNullOrWhiteSpace(a.NotificationToken) &&
                                                             a.Account.NotificationAccounts.Any(b => b.Fk_Notification == notification.Id))
                                                .Select(a => a.NotificationToken)
                                                .ToList();

                if (tokens.Any())
                {
                    FirebaseAdmin.Messaging.MulticastMessage message = NotificationManager.CreateMulticastMessage(new FirebaseNotificationModel
                    {
                        OpenType = (int)notification.OpenType,
                        OpenValue = notification.OpenValue,
                        MessageContent = notification.Description,
                        MessageHeading = notification.Title,
                        ImgUrl = notification.ImageURL,
                        RegistrationTokens = tokens
                    });

                    await NotificationManager.SendMulticast(message);
                }
            }
        }

    }
}
