using System.ComponentModel;
using Microsoft.VisualBasic;

namespace SocialMedia;

internal class Program
{
    static void Main(string[] args)
    {
        var UsersList = new List<User>();

        UsersList.Add(new User("BlazejM", 200));
        UsersList.Add(new User("Jakkob22", 201));
        UsersList.Add(new User("Frankyyyy", 202));
        UsersList.Add(new User("Mollyy2", 203));
        var MainUser = UsersList[0];
        while (true)
        {
            //Console.WriteLine("FriendFace\n");
            //Console.WriteLine("Logged inn as {0}\n\n", UsersList[0].Username);

            Console.WriteLine(
                $"1. Show Friend list ({MainUser.Friends.Count})\n2. Add Friend/Inspect\n3. Clear Console");
            var userInp = Console.ReadKey().Key;

            switch (userInp)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    MainUser.ShowFriends();
                    Console.WriteLine("1. Remove friend \n2. Main menu");
                    var choice1 = Console.ReadKey().Key;

                    if (choice1 == ConsoleKey.D1){ RemoveFriend(UsersList, MainUser); Console.Clear(); }
                    else if (choice1 == ConsoleKey.D2)
                    {
                        Console.Clear();
                        continue;
                    }


                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    ShowAllUser(UsersList);
                    Console.WriteLine("1. Add (ID)\n2. Inspect user (ID) ");
                    var choice = Console.ReadKey().Key;

                    Console.WriteLine();

                    if (choice == ConsoleKey.D1)
                    {
                        AddNewFriend(UsersList, MainUser);
                        Console.Clear();
                    }
                    else if (choice == ConsoleKey.D2) InspectUser(UsersList, MainUser);
                    
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    break;
            }
        }
    }

    private static void AddNewFriend(List<User> UsersList, User MainUser)
    {
        var friend = FindUserObj(UsersList, MainUser);
        MainUser.AddFriend(friend);
    }

    private static void InspectUser(List<User> UsersList, User MainUser)
    {
        var friend = FindUserObj(UsersList, MainUser);
        friend.showInfo();
    }

    private static void RemoveFriend(List<User> UsersList, User MainUser)
    {
        var friend = FindUserObj(UsersList, MainUser);
        MainUser.RemoveFriend(friend);
    }

    private static User FindUserObj(List<User> UsersList, User MainUser)
    {   
        Console.WriteLine();
        Console.Write("User ID :");
        var id = Console.ReadLine();
        var FriendID = Convert.ToInt32(id);
        var friend = (User)findUser(FriendID, UsersList);
        return friend;
    }

    private static object findUser(int friendId, List<User> usersList)
    {
        int find = 0;
        int found = 0;
        foreach (var user in usersList)
        {
            if (user.Id == friendId)
            {
                found = find;
                break;
            }

            ;
            find++;
        }

        User him = usersList[found];

        return him;
    }


    static void ShowAllUser(List<User> Users)
    {
        foreach (var user in Users)
        {
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine($"{user.Id}: {user.Username} ");
            Console.WriteLine("..................");
        }
    }
}