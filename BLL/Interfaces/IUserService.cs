using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using System.Security.Claims;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        string GetCurrentUserEmail(UserDTO user);
    }
    //Через объекты данного интерфейса уровень представления будет взаимодействовать с уровнем доступа к данным. 
     //Здесь определены только три метода: Create (создание пользователей), Authenticate (аутентификация пользователей)
    //и SetInitialData (установка начальных данных в БД - админа и списка ролей).
}
