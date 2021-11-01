using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiceBot
{
    class Program
    {
        //Token - Токен
        private static string Token { get; set; } = "TOKEN/ТОКЕН";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            Console.Title = "DiceBot Consol v1.3";
            Console.WriteLine("#####  ######  ####  #####  #####   ####  ######");
            Console.WriteLine("##  ##   ##   ##  ## ##     ##  ## ##  ##   ##");
            Console.WriteLine("##  ##   ##   ##     ####   #####  ##  ##   ##");
            Console.WriteLine("##  ##   ##   ##  ## ##     ##  ## ##  ##   ##");
            Console.WriteLine("#####  ######  ####  #####  #####   ####    ##\n");

            Console.WriteLine("#####  ##  ##");
            Console.WriteLine("##  ##  ####");
            Console.WriteLine("#####    ##");
            Console.WriteLine("##  ##   ##");
            Console.WriteLine("#####    ##\n");

            Console.WriteLine("##   # ##   # ##  ## #####  ###### ##  ## ##  ##");
            Console.WriteLine("##   # ##   #  ####  ##  ##   ##    ####   ####");
            Console.WriteLine("## # # ## # #   ##   #####    ##     ##     ##");
            Console.WriteLine("###### ######  ####  ##  ##   ##     ##     ##");
            Console.WriteLine(" ## ##  ## ## ##  ## ##  ## ######   ##     ##\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бот успешно запущен!");
            Console.ForegroundColor = ConsoleColor.Gray;
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }
        //Reply to buttons - Ответ на кнопки
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");

                switch (msg.Text)
                {
                    case "1 Кубик":
                        Random Dice = new Random();
                        int dice = Dice.Next(1, 6);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice);
                        break;
                    case "2 Кубика":
                        Random Dice1 = new Random();
                        int dice1 = Dice1.Next(2, 12);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice1 + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice1);
                        break;
                    case "3 Кубика":
                        Random Dice2 = new Random();
                        int dice2 = Dice2.Next(3, 18);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice2 + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice2);
                        break;
                    case "4 Кубика":
                        Random Dice3 = new Random();
                        int dice3 = Dice3.Next(4, 24);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice3 + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice3);
                        break;
                    case "5 Кубиков":
                        Random Dice4 = new Random();
                        int dice4 = Dice4.Next(5, 30);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice4 + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice4);
                        break;
                    case "6 Кубиков":
                        Random Dice5 = new Random();
                        int dice5 = Dice5.Next(6, 36);
                        client.SendTextMessageAsync(msg.Chat.Id, "Выпало число " + dice5 + " 🎲", replyToMessageId: msg.MessageId);
                        Console.WriteLine("Выпало число " + dice5);
                        break;
                    case "Информация":
                        client.SendTextMessageAsync(msg.Chat.Id, "Бот создан в развликательных целях.");
                        client.SendTextMessageAsync(msg.Chat.Id, "При неполадке бота писать администратору https://www.instagram.com/wwxriyy/ 🤍");
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Пожалуйста выберите что-то из кнопок: ", replyMarkup: GetButtons());
                        break;
                }
            }
        }
        //Buttons - Кнопки 
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "1 Кубик"}, new KeyboardButton { Text = "2 Кубика"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "3 Кубика"}, new KeyboardButton { Text = "4 Кубика"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "5 Кубиков"}, new KeyboardButton { Text = "6 Кубиков"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Информация"} }
                }
            };
        }
    }
}