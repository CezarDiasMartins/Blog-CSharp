using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma Post");
            Console.WriteLine("-----------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Qual Id de Categoria pertence o Post: ");
            var categoryId = Console.ReadLine();

            Console.Write("Qual Id de Usuário pertence o Post: ");
            var authorId = Console.ReadLine();

            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Summary: ");
            var summary = Console.ReadLine();

            Console.Write("Texto: ");
            var body = Console.ReadLine();
            
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Console.Write("Data de criação(dd-mm-yyyy hh:mm:ss): ");
            var createDate = Console.ReadLine();

            Console.Write("Última data de atualização(dd-mm-yyyy hh:mm:ss): ");
            var lastUpdateDate = Console.ReadLine();

            Update(new Post
            {
                Id = int.Parse(id),
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = lastUpdateDate
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}