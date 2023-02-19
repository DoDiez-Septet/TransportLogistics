using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportLogistics.Domain.Interfaces.Users.Repository;
using TransportLogistics.Domain.Models.Users;
using UserService.DataAccess.ModelDb;

namespace UserService.DataAccess.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext userDbContext, IMapper mapper)
        {
            _context = userDbContext;
            _mapper = mapper;
        }

        public void Delete(string userId)
        {
            if (Guid.TryParse(userId, out Guid Id))
            {
                var userToDelete = _context.Users.Find(Id);
                if (userToDelete is not null)
                {
                    _context.Entry(userToDelete).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
        }

        public void Edit(string userId, User user)
        {
            if (Guid.TryParse(userId, out Guid Id))
            {
                if (_context.Users.Find(Id) is UserDb userInDb)
                {
                    userInDb.FirstName = user.FirstName;
                    userInDb.LastName = user.LastName;
                    userInDb.Email = user.Email;
                    userInDb.Role = user.Role;

                    _context.Entry(userInDb).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        public User? Get(string userId)
        {
            if (Guid.TryParse(userId, out Guid Id))
            {
                var userDb = _context.Users.FirstOrDefault(x => x.Id == Id);
                return _mapper.Map<User?>(userDb);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            var usersDb = _context.Users.ToList();
            return _mapper.Map<IReadOnlyCollection<User>>(usersDb);
        }

        public string New(User user)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var result = _context.Users.Add(userDb);
            _context.SaveChanges();

            return result.Entity.Id.ToString();
        }
    }
}
