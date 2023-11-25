using Blog.Repositories;

namespace Blog.Screens.TagPostScreens
{
    public class DeleteTagPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir vínculo de tag com post");
            Console.WriteLine("--------------------------------");
            
            Console.Write("Qual Id da tag deseja, para excluir o vínculo? ");
            var idTag = Console.ReadLine();

            Console.Write("Qual Id do post deseja, para excluir o vínculo? ");
            var idPost = Console.ReadLine();

            DeleteTagPost(int.Parse(idTag), int.Parse(idPost));

            Console.ReadKey();
            MenuTagPostScreen.Load();
        }

        public static void DeleteTagPost(int idTag, int idPost)
        {
            try
            {
                var repository = new TagRepository(Database.Connection);
                repository.DeleteTagPost(idTag, idPost);
                Console.WriteLine("TagPost excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir TagPost");
                Console.WriteLine(ex.Message);
            }
        }
    }
}