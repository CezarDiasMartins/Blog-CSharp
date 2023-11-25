namespace Blog.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categories");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar categories");
            Console.WriteLine("2 - Cadastrar categories");
            Console.WriteLine("3 - Atualizar category");
            Console.WriteLine("4 - Excluir category");
            Console.WriteLine("5 - Voltar ao menu");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option){
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}