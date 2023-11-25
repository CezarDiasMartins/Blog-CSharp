using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public void CreateTagPost(int idTag, int idPost)
        {
            var insert = @"
                INSERT INTO
	                [PostTag]
                VALUES
                    (@IdPost, @IdTag)";

            _connection.Execute(insert, new
            {
                IdPost = idPost,
                IdTag = idTag
            });
        }
        
        public List<Tag> ListTagPost()
        {
            var query = @"
                SELECT
	                [Post].*,
	                [Tag].*
                FROM
	                [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var tags = new List<Tag>();
            var items = _connection.Query<Post, Tag, Tag>(
                query,
                (post, tag) =>
                {
                    var tag2 = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tag2 == null)
                    {
                        tag2 = tag;
                        if(post != null)
                        {
                            tag2.Posts.Add(post);
                        }
                        
                        tags.Add(tag2);
                    }
                    else
                        tag2.Posts.Add(post);
                    
                    return tag2;
                }, splitOn: "Id");

            return tags;
        }
    
        public void DeleteTagPost(int idTag, int idPost)
        {
            var delete = @"
                DELETE FROM
                    [PostTag] 
                WHERE
                    [PostTag].[PostId] = @IdPost 
                AND
                    [PostTag].[TagId] = @IdTag";

            _connection.Execute(delete, new
            {
                IdPost = idPost,
                IdTag = idTag
            });
        }
    
        public void UpdateTagPost(int idTag, int novoIdTag, int idPost, int novoIdPost)
        {
            var delete = @"
                UPDATE
                    [PostTag]
                SET
                    [PostTag].[PostId] = @NovoIdPost,
                    [PostTag].[TagId] = @NovoIdTag
                WHERE
                    [PostTag].[PostId] = @IdPost 
                AND
                    [PostTag].[TagId] = @IdTag";

            _connection.Execute(delete, new
            {
                NovoIdPost = novoIdPost,
                NovoIdTag = novoIdTag,
                IdPost = idPost,
                IdTag = idTag
            });
        }
    }
}