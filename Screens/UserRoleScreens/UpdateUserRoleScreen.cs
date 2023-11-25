using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public class UpdateUserRolecreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar vínculo de user com role");
            Console.WriteLine("----------------------------------");
            
            Console.Write("Id de usuário(User) atual: ");
            var idUser = Console.ReadLine();

            Console.Write("Id de usuário(User) novo: ");
            var novoIdUser = Console.ReadLine();

            Console.Write("Id de perfil(Role) atual: ");
            var idRole = Console.ReadLine();

            Console.Write("Id de perfil(Role) novo: ");
            var novoIdRole = Console.ReadLine();

            UpdateUserRole(int.Parse(idUser), int.Parse(novoIdUser), int.Parse(idRole), int.Parse(novoIdRole));

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static void UpdateUserRole(int idUser, int novoIdUser, int idRole, int novoIdRole)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.UpdateUserRole(idUser, novoIdUser, idRole, novoIdRole);
                Console.WriteLine("UserRole atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar UserRole");
                Console.WriteLine(ex.Message);
            }
        }
    }
}