using System.Data.Common;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public void CreateUserRole(int idUser, int idRole)
        {
            var insert = @"
                INSERT INTO
	                [UserRole]
                VALUES
                    (@IdUser, @IdRole)";

            _connection.Execute(insert, new
            {
                IdUser = idUser,
                IdRole = idRole
            });
        }

        public List<User> ListUserRole()
        {
            var query = @"
                SELECT
	                [User].*,
	                [Role].*
                FROM
	                [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return usr;
                }, splitOn: "Id");

            return users;
        }

        public void DeleteUserRole(int idUser, int idRole)
        {
            var delete = @"
                DELETE FROM
                    [UserRole] 
                WHERE
                    [UserRole].[UserId] = @IdUser 
                AND
                    [UserRole].[RoleId] = @IdRole";

            _connection.Execute(delete, new
            {
                IdUser = idUser,
                IdRole = idRole
            });
        }

        public void UpdateUserRole(int idUser, int novoIdUser, int idRole, int novoIdRole)
        {
            var delete = @"
                UPDATE
                    [UserRole]
                SET
                    [UserRole].[UserId] = @NovoIdUser,
                    [UserRole].[RoleId] = @NovoIdRole
                WHERE
                    [UserRole].[UserId] = @IdUser 
                AND
                    [UserRole].[RoleId] = @IdRole";

            _connection.Execute(delete, new
            {
                NovoIdUser = novoIdUser,
                NovoIdRole = novoIdRole,
                IdUser = idUser,
                IdRole = idRole
            });
        }
    }
}