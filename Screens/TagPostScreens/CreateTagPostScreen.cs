using Blog.Repositories;

namespace Blog.Screens.TagPostScreens
{
    public class CreateTagPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar vínculo de tag com post");
            Console.WriteLine("----------------------------------");

            Console.Write("Id da tag: ");
            int idTag = short.Parse(Console.ReadLine());

            Console.Write("Id do post: ");
            int idPost = short.Parse(Console.ReadLine());

            CreateTagPost(idTag, idPost);

            Console.ReadKey();
            MenuTagPostScreen.Load();
        }

        public static void CreateTagPost(int idTag, int idPost)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                repository.CreateTagPost(idTag, idPost);
                Console.WriteLine("TagPost vinculada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular TagPost");
                Console.WriteLine(ex.Message);
            }
        }
    }
}