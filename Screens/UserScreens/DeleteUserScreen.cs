using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um User");
            Console.WriteLine("-----------------");
            Console.Write("Qual id do User que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("User excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o user");
                Console.WriteLine(ex.Message);
            }
        }
    }
}