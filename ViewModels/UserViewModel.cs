using Data.DTOs;

namespace TpIntegradorSofttekFront.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator UserViewModel(UserDto dto)
        {
            var userViewModel = new UserViewModel();
            userViewModel.Id = dto.Id;
            userViewModel.Name = dto.Name;
            userViewModel.Dni = dto.Dni;
            userViewModel.Email = dto.Email;
            userViewModel.Password = dto.Password;
            userViewModel.Type = dto.Type;
            return userViewModel;
        }
    }
}
