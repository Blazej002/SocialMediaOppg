using Console = System.Console;

namespace SocialMedia
{
    internal class User
    { 
        public int Id { get;private set; }
        public string Username { get; private set; }
        public List<User> Friends { get; private set; }
        public User(string name, int id)
        {
            Username = name;
            Friends = new List<User>();
            Id = id;
        }

        public void AddFriend(User friend)
        {
            Friends.Add(friend);
        }

        public void RemoveFriend(User friend)
        {
            Friends.Remove(friend);
        }

        public void ShowFriends()
        {
            foreach (var friend in Friends)
            {
                Console.WriteLine("----------");   
                Console.WriteLine($"Id : {friend.Id} - {friend.Username}");   
                Console.WriteLine("----------");   
            }
        }

        public void showInfo()
        {
            Console.WriteLine($"Name : {Username}\nID : {Id}");
            if (Friends.Count < 0) Console.WriteLine("No friends found");
            else
            {
                foreach (var friend in Friends)
                {
                    Console.WriteLine($"{friend.Username}");
                }
            }
        }

    }
}
