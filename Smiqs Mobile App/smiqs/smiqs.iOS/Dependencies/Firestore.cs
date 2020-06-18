using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using smiqs.Model;
using smiqs.ViewModel.Helpers;
using Xamarin.Forms;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(smiqs.iOS.Dependencies.Firestore))]
namespace smiqs.iOS.Dependencies
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
            var keys = new[]
            {
                new NSString("author"),
                new NSString("name"),
                new NSString("isActive"),
                new NSString("subscribedDate"),
            };
            var values = new NSObject[]
                {
                new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                new NSString(subscription.Name),
                new NSNumber(subscription.isActive),
                DateTimetoNSDate(subscription.SubscribedDate)
            };
            var subscriptionDocument = new NSDictionary<NSString, NSObject>(keys, values);
            Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("subscriptions").AddDocument(subscriptionDocument);
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
        private static NSDate DateTimetoNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Local);
            return (NSDate)date;
        }
    }
}