using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorys");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.Get();

            var repository2 = new Repository<Post>(Database.Connection);
            var posts = repository2.Get();

            foreach (var item in categories)
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