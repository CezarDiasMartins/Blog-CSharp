namespace Blog.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de roles");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar roles");
            Console.WriteLine("2 - Cadastrar roles");
            Console.WriteLine("3 - Atualizar role");
            Console.WriteLine("4 - Excluir role");
            Console.WriteLine("5 - Voltar ao menu");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option){
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}