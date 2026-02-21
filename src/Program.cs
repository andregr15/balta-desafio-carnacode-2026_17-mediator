using src.Mediators;
using src.Models;

Console.WriteLine("=== Sistema de Chat em Grupo ===\n");

var mediator = new ChatMediator();

// Criando usuários
var alice = new User(mediator, "Alice");
var bob = new User(mediator, "Bob");
var carlos = new User(mediator, "Carlos");
var diana = new User(mediator, "Diana");

// Problema: Precisa gerenciar lista manualmente
var groupMembers = new List<User>();

Console.WriteLine("=== Usuários Entrando no Grupo ===");
alice.JoinGroup();
bob.JoinGroup();
carlos.JoinGroup();
diana.JoinGroup();

Console.WriteLine("\n=== Conversação ===");
alice.SendMessage("Olá, pessoal!");
bob.SendMessage("Oi, Alice!");
carlos.SendMessage("E aí!");

Console.WriteLine("\n=== Mensagem Privada ===");
alice.SendPrivateMessage(bob, "Bob, você viu o relatório?");

Console.WriteLine("\n=== Moderação ===");
alice.MuteUser(carlos);
carlos.SendMessage("Ainda posso falar?"); // Não será enviado

Console.WriteLine("\n=== Saindo do Grupo ===");
diana.LeaveGroup();
alice.SendMessage("Diana saiu");

// Console.WriteLine("\n=== PROBLEMAS ===");
// Console.WriteLine("✗ Acoplamento alto: cada usuário conhece todos os outros");
// Console.WriteLine("✗ Comunicação M×N: cada usuário envia para N-1 outros");
// Console.WriteLine("✗ Lógica de notificação duplicada em cada método");
// Console.WriteLine("✗ Usuários modificam estado de outros usuários diretamente");
// Console.WriteLine("✗ Difícil adicionar regras centralizadas (moderação, filtros)");
// Console.WriteLine("✗ Não há lugar único para implementar log de mensagens");
// Console.WriteLine("✗ Difícil adicionar novos tipos de interação");
// Console.WriteLine("✗ Gerenciamento de grupo espalhado entre usuários");

// Console.WriteLine("\n=== Requisitos Não Atendidos ===");
// Console.WriteLine("• Moderação centralizada com permissões");
// Console.WriteLine("• Log centralizado de todas as mensagens");
// Console.WriteLine("• Filtro de palavras proibidas");
// Console.WriteLine("• Rate limiting (limite de mensagens por minuto)");
// Console.WriteLine("• Histórico de mensagens");
// Console.WriteLine("• Notificações inteligentes");

// Perguntas para reflexão:
// - Como desacoplar objetos que precisam se comunicar?
// - Como centralizar lógica de comunicação complexa?
// - Como evitar comunicação direta entre muitos objetos?
// - Como facilitar manutenção de interações entre componentes?