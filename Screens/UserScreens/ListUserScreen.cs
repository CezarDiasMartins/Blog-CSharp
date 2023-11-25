using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Users");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.Get();

            var repository2 = new Repository<Post>(Database.Connection);
            var posts = repository2.Get();

            foreach (var item in users)
            {
                Console.WriteLine($"({item.Id}) {item.Name} - {item.Slug}");

                foreach (var post in posts)
                {
                    if (item.Id == post.CategoryId)
                    {
                        Console.WriteLine($"    -->({post.Id}) {post.Title}");
                    }
                }
                
                Console.WriteLine();
            }
        }
    }
}