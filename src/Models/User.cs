
using src.Interfaces;

namespace src.Models;

public class User(IChatMediator mediator, string name)
{
    private readonly IChatMediator _mediator = mediator;
    public string Name { get; } = name;
    public bool IsMuted { get; set; }

    public void MuteUser(User user) =>
        _mediator.MuteUser(user, true);

    public void JoinGroup() =>
        _mediator.JoinGroup(this);

    public void LeaveGroup() =>
        _mediator.LeaveGroup(this);

    public void SendMessage(string message)
    {
        if (IsMuted)
        {
            Console.WriteLine($"[{Name}] ❌ Você está mutado");
            return;
        }

        Console.WriteLine($"{Name} enviou: {message}");
        _mediator.SendMessage(this, message);
    }

    public void SendPrivateMessage(User recipient, string message)
    {
        if (IsMuted)
        {
            Console.WriteLine($"[{Name}] ❌ Você está mutado");
            return;
        }

        Console.WriteLine($"[{Name}] Enviou mensagem privada para {recipient.Name}");
        _mediator.SendPrivateMessage(recipient, this, message);
    }

    public void ReceiveMessage(string senderName, string message) =>
        Console.WriteLine($"  → [{Name}] Recebeu de {senderName}: {message}");

    public void ReceivePrivateMessage(string senderName, string message) =>
       Console.WriteLine($"  → [{Name}] 🔒 Mensagem privada de {senderName}: {message}");

    public void ReceiveNotification(string notification) =>
        Console.WriteLine($"  → [{Name}] ℹ️ {notification}");
}
