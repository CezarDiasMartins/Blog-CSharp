using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma Role");
            Console.WriteLine("-----------------");
            Console.Write("Qual id da Role que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Role excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a role");
                Console.WriteLine(ex.Message);
            }
        }
    }
}