using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
namespace CH.Web
{
    [HubName("UsersListHub")]
    public class UserListHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        private static List<UserEntity> users = new List<UserEntity>();


        public void Join(string UserId, string nickName)
        {
            UserEntity userEntity = new UserEntity
            {
                UserId = UserId,
                NickName = nickName,
                ConnectionId = Context.ConnectionId
            };

            users.Add(userEntity);
            //通知所有
            Clients.All.NotifyUserEnter(nickName, users);
        }

        public void SendMessage(string nickName, string message)
        {
            Clients.All.NotifySendMessage(nickName, message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var currentUser = users.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
            if (currentUser != null)
            {
                users.Remove(currentUser);
                //下线
                Clients.Others.NotifyUserLeft(currentUser.NickName, users);
            }
            return base.OnDisconnected(stopCalled);
        }
    }


    public class UserEntity
    {
        public string UserId { get; set; }

        public string NickName { get; set; }

        public string ConnectionId { get; set; }
    }
}