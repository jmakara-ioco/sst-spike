using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface IProfileService
    {
        Task<ScreenSubmitResult> UpdateProfile(ProfileModel profileModel);
        public Task<ProfileModel> GetProfile();

        Task<ScreenSubmitResult> UpdatePassword(ChangePasswordModel changePasswordModel);

        Task<ScreenSubmitResult> RemovePassword(ForgotPasswordModel forgotPasswordModel);

        Task<ScreenSubmitResult> AddPassword(NewPasswordModel newPasswordModel);
    }
}
