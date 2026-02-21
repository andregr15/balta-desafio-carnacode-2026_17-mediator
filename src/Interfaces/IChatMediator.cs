using src.Models;

namespace src.Interfaces;

public interface IChatMediator
{
    void JoinGroup(User newUser);
    void LeaveGroup(User leavingUser);
    void MuteUser(User target, bool muted);
    void SendMessage(User sender, string message);
    void SendPrivateMessage(User recipient, User sender, string message);
}
