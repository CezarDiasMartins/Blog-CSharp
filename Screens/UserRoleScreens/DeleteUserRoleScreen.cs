using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public class DeleteUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir vínculo de user com role");
            Console.WriteLine("--------------------------------");
            
            Console.Write("Qual Id do usuário(User) deseja, para excluir o vínculo? ");
            var idUser = Console.ReadLine();

            Console.Write("Qual Id do perfil(Role) deseja, para excluir o vínculo? ");
            var idRole = Console.ReadLine();

            DeleteUserRole(int.Parse(idUser), int.Parse(idRole));

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static void DeleteUserRole(int idUser, int idRole)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.DeleteUserRole(idUser, idRole);
                Console.WriteLine("UserRole excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir UserRole");
                Console.WriteLine(ex.Message);
            }
        }
    }
}