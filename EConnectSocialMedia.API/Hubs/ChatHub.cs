namespace EConnectSocialMedia.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UnitOfWork _UnitOfWork;

        public ChatHub(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task SendMessage(string ConnectionId, string Message)
        {
            await Clients.All.SendAsync("ReceiveMessage", ConnectionId, Message);
        }

        public async Task JoinRoom(string ConnectionId, string GroupName)
        {
            await Groups.AddToGroupAsync(ConnectionId, GroupName);

            string Message = $"{ConnectionId} Join Room {GroupName}";

            await Clients.Group(GroupName).SendAsync("ReceiveMessage", ConnectionId, Message);
        }

        public async Task ExitRoom(string ConnectionId, string GroupName)
        {
            await Groups.RemoveFromGroupAsync(ConnectionId, GroupName);

            string Message = $"{ConnectionId} Exit Room {GroupName}";

            await Clients.Group(GroupName).SendAsync("ReceiveMessage", ConnectionId, $"{ConnectionId} Exit Room {GroupName}");
        }

        public async Task SendToRoom(string ConnectionId, string GroupName, string Message)
        {
            await Clients.Group(GroupName).SendAsync("ReceiveMessage", ConnectionId, Message);
        }

        public override Task OnConnectedAsync()
        {
            if (!string.IsNullOrEmpty(Context.ConnectionId) &&
               _UnitOfWork.Account.Any(a => a.ConnectionId == Context.ConnectionId))
            {
                Account Account = _UnitOfWork.Account.GetFirst(a => a.ConnectionId == Context.ConnectionId).Result;
                if (Account != null)
                {
                    Account.IsOnline = true;
                    _UnitOfWork.Account.UpdateEntity(Account);
                    _UnitOfWork.Save().Wait();
                }
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (!string.IsNullOrEmpty(Context.ConnectionId) &&
                _UnitOfWork.Account.Any(a => a.ConnectionId == Context.ConnectionId))
            {
                Account Account = _UnitOfWork.Account.GetFirst(a => a.ConnectionId == Context.ConnectionId).Result;
                if (Account != null)
                {
                    Account.IsOnline = false;
                    _UnitOfWork.Account.UpdateEntity(Account);
                    _UnitOfWork.Save().Wait();
                }
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
