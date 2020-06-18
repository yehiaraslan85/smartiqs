using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using smiqs.iOS.Dependencies;
using smiqs.ViewModel.Helpers;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(smiqs.iOS.Dependencies.Auth))]
namespace smiqs.iOS.Dependencies
{
    class Auth : IAuth
    {
        public Auth()
        {

        }
        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try { 
                await  Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch (NSErrorException ex)
            {
                string message = ex.Message.Substring(ex.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                message += ".";
                throw new Exception(message);
            }
            catch (Exception)
            {
                throw new Exception("An unknown error occurred, please try agian.");
            }
        }

        public string GetCurrentUserId()
        {
           return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public async Task<bool> RegisterUser(string name, string email, string password)
        {
            try { 
          await  Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
            var changeRequest = Firebase.Auth.Auth.DefaultInstance.CurrentUser.ProfileChangeRequest();
            changeRequest.DisplayName = name;
            await changeRequest.CommitChangesAsync();
            return true;
            }
            catch(NSErrorException ex)
            {
                string message = ex.Message.Substring(ex.Message.IndexOf("NSLocalizedDescription=",StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                message += ".";
                throw new Exception(message);
            }
            catch(Exception)
            {
                throw new Exception("An unknown error occurred, please try agian.");
            }
        }
    }
}