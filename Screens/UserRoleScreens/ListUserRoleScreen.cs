using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public class ListUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar vínculo de user com role");
            Console.WriteLine("-------------------------------");

            ListUserRole();

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void ListUserRole()
        {
            var repository = new UserRepository(Database.Connection);
            var items = repository.ListUserRole();

            foreach (var item in items)
            {
                Console.WriteLine($"({item.Id}){item.Name}");

                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }

                Console.WriteLine();
            }
        }
    }
}