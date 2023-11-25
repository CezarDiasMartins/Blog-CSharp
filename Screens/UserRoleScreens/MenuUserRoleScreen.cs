namespace Blog.Screens.UserRoleScreens
{
    public class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular perfil/usuário");
            Console.WriteLine("-----------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar vínculo de user com role");
            Console.WriteLine("2 - Cadastrar vínculo de user com role");
            Console.WriteLine("3 - Atualizar vínculo de user com role");
            Console.WriteLine("4 - Excluir vínculo de user com role");
            Console.WriteLine("5 - Voltar ao menu");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option){
                case 1:
                    ListUserRoleScreen.Load();
                    break;
                case 2:
                    CreateUserRoleScreen.Load();
                    break;
                case 3:
                    UpdateUserRolecreen.Load();
                    break;
                case 4:
                    DeleteUserRoleScreen.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}