using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um Post");
            Console.WriteLine("-----------------");
            Console.Write("Qual id do Post que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("User excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}