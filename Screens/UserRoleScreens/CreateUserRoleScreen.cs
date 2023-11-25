using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar vínculo de user com role");
            Console.WriteLine("----------------------------------");

            Console.Write("Id do usuário(User): ");
            int idUser = short.Parse(Console.ReadLine());

            Console.Write("Id do perfil(Role): ");
            int idRole = short.Parse(Console.ReadLine());

            CreateUserRole(idUser, idRole);

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static void CreateUserRole(int idUser, int idRole)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.CreateUserRole(idUser, idRole);
                Console.WriteLine("UserRole vinculada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular UserRole");
                Console.WriteLine(ex.Message);
            }
        }
    }
}