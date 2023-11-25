using Blog.Repositories;

namespace Blog.Screens.TagPostScreens
{
    public class UpdateTagPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar vínculo de tag com post");
            Console.WriteLine("----------------------------------");
            
            Console.Write("Id da tag atual: ");
            var idTag = Console.ReadLine();

            Console.Write("Id da tag nova: ");
            var novoIdTag = Console.ReadLine();

            Console.Write("Id do post atual: ");
            var idPost = Console.ReadLine();

            Console.Write("Id do post novo: ");
            var novoIdPost = Console.ReadLine();

            UpdateTagPost(int.Parse(idTag), int.Parse(novoIdTag), int.Parse(idPost), int.Parse(novoIdPost));

            Console.ReadKey();
            MenuTagPostScreen.Load();
        }

        public static void UpdateTagPost(int idTag, int novoIdTag, int idPost, int novoIdPost)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                repository.UpdateTagPost(idTag, novoIdTag, idPost, novoIdPost);
                Console.WriteLine("TagPost atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar TagPost");
                Console.WriteLine(ex.Message);
            }
        }
    }
}