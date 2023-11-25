using Blog.Repositories;

namespace Blog.Screens.TagPostScreens
{
    public class ListTagPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar vínculo de tag com post");
            Console.WriteLine("------------------------------");

            ListTagPost();

            Console.ReadKey();
            MenuTagPostScreen.Load();
        }

        private static void ListTagPost()
        {
            var repository = new TagRepository(Database.Connection);
            var items = repository.ListTagPost();

            foreach (var item in items)
            {
                Console.WriteLine($"({item.Id}){item.Name}");

                foreach (var post in item.Posts)
                {
                    Console.WriteLine($" - {post.Title}");
                }

                Console.WriteLine();
            }
        }
    }
}