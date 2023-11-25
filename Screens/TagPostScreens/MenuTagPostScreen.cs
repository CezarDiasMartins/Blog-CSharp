namespace Blog.Screens.TagPostScreens
{
    public class MenuTagPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular post/tag");
            Console.WriteLine("-------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar vínculo de tag com post");
            Console.WriteLine("2 - Cadastrar vínculo de tag com post");
            Console.WriteLine("3 - Atualizar vínculo de tag com post");
            Console.WriteLine("4 - Excluir vínculo de tag com post");
            Console.WriteLine("5 - Voltar ao menu");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option){
                case 1:
                    ListTagPostScreen.Load();
                    break;
                case 2:
                    CreateTagPostScreen.Load();
                    break;
                case 3:
                    UpdateTagPostScreen.Load();
                    break;
                case 4:
                    DeleteTagPostScreen.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}