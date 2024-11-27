namespace QuizGame.Models
{
    public class User
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid ActivationCode { get; set; } // Mã kích hoạt
        public bool IsActivated { get; set; }    // Trạng thái kích hoạt
        public Guid ResetToken { get; set; } // Mã reset mật khẩu
        public DateTime? ResetTokenExpiry { get; set; } // Thời gian hết hạn của token

        // Constructor for registration (no reset token)
        public User(string fullName, DateTime dateOfBirth, string gender, string email, string password, string role, Guid activationCode, bool isActivated)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            Password = password;
            Role = role;
            ActivationCode = activationCode;
            IsActivated = isActivated;
        }

        // Constructor for forgot password (with reset token)
        public User(string email, Guid resetToken, DateTime? resetTokenExpiry)
        {
            Email = email;
            ResetToken = resetToken;
            ResetTokenExpiry = resetTokenExpiry;
        }
    }
}
