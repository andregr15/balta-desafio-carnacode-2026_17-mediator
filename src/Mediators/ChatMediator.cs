using src.Interfaces;
using src.Models;

namespace src.Mediators;

public class ChatMediator : IChatMediator
{
    private List<User> _users = new();

    public void JoinGroup(User newUser)
    {
        _users.Add(newUser);
        foreach (var user in _users.Where(u => u != newUser))
            user.ReceiveNotification($"{newUser.Name} entrou no grupo");
    }

    public void LeaveGroup(User leavingUser)
    {
        _users.Remove(leavingUser);

        foreach (var user in _users)
            user.ReceiveNotification($"{leavingUser.Name} saiu do grupo");

        Console.WriteLine($"[{leavingUser.Name}] Saiu do grupo");
    }

    public void MuteUser(User target, bool muted)
    {
        target.IsMuted = muted;
        foreach (var user in _users.Where(u => u != target))
            user.ReceiveNotification($"{target.Name} foi mutado");
    }

    public void SendMessage(User sender, string message)
    {
        foreach (var user in _users.Where(u => u != sender))
            user.ReceiveMessage(sender.Name, message);
    }

    public void SendPrivateMessage(User recipient, User sender, string message)
    {
        recipient.ReceivePrivateMessage(sender.Name, message);
    }
}
