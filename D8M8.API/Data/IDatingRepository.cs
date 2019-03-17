using System.Collections.Generic;
using System.Threading.Tasks;
using D8M8.API.Helpers;
using D8M8.API.Models;

namespace D8M8.API.Data
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         Task<Like> GetLike(int userId, int recipientId);
         Task<Message> GetMessage(int id);
         Task<PagedList<Message>> GetMessagesForUser(MessageParams  messageParams);
         
         // Conversation b/w 2 users
         Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}