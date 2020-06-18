using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using smiqs.Model;
using smiqs.ViewModel.Helpers;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(smiqs.Droid.Dependencies.Firestore))]

namespace smiqs.Droid.Dependencies
{
    public class Firestore : IFirestore
    {
        public Firestore()
        {

        }
        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool InsertSubscription(Subscription subscription)
        {
            try { 
           var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
                var subscriptionDocument = new Dictionary<string, Java.Lang.Object>
            {
                {"author",Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                {"name",subscription.Name },
                {"isActive",subscription.isActive },
                {"subscribedDate",DateTimeToNativeDate(subscription.SubscribedDate) }
            };
            collection.Add(subscriptionDocument);
            return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Task<IList<Subscription>> ReadSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        private static Date DateTimeToNativeDate(DateTime date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }
    }
}